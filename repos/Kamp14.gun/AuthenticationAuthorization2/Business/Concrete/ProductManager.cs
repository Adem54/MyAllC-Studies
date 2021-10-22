using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidatoinRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Logging;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Logging.Log4Net.Loggers;
using Core.Extensions;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;//Icerisinde Product operasyonlarini tasiyor linq ile birlikte
                                //onun icin bize sorgu imkani veriyor
        ICategoryService _categoryService;
        public ProductManager(IProductDal productDal,ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
           
            
        }

       [ValidationAspect(typeof(ProductValidator), Priority = 1)]
        [CacheRemoveAspect(pattern:"IProductService.Get")]
        public IResult Add(Product product)
        {
            var result=BusinessRules.Run(CheckIfProductNameExist(product.ProductName),
                CheckIfCategoryIsEnable());
            if (result!=null)
            {
                return result;
            }
           
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IResult Delete(Product product)
        {
            _productDal.Delete(product);
            return new SuccessResult(Messages.ProductDeleted);
        }

        [LogAspect(typeof(FileLogger))]
        public IDataResult<Product> Get(int productId)
        {
           return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId),
               Messages.ProductDetailListed);
        }

       [PerformanceAspect(interval:5)]
   //     [SecuredOperation("Product.GetAll,Admin")]
        public IDataResult<List<Product>> GetAll()
        {
            Thread.Sleep(millisecondsTimeout: 5000);
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),
                Messages.ProductsListed);
        }

        [LogAspect(typeof(DatabaseLogger))]
        [CacheAspect(duration: 10)]
        public IDataResult<List<Product>> GetAllByCategory(int categoryId)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == categoryId),
                Messages.ProductListedByCategory) ;
        }

        [SecuredOperation("Admin")]
        public IDataResult<List<ProductDetailDto>> GetProductDtos()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetailDtos(),
                Messages.ProductDetailDtoListed);
        }

        [TransactionScopeAspect]
        public IResult TransactionalOperation(Product product)
        {
            _productDal.Update(product);//Basarili olsun
         //   _productDal.Add(product);//Basarisiz olsun
            return new SuccessResult(Messages.ProductUpdated);
        }

        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult(Messages.ProductUpdated);
        }

        private IResult CheckIfCategoryIsEnable()
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count>10)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }
            return new SuccessResult();
        }
        

        private IResult CheckIfProductNameExist(string productName)
        {
            var result = _productDal.Get(p => p.ProductName == productName);
            if (result!=null)
            {
                return new ErrorResult(Messages.ProductAlleredeExist);
            }
            return new SuccessResult();
        }
    }
}
