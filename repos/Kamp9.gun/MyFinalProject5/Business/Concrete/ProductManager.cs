using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidaton;
using Core.Aspect.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ICategoryService _categoryService;
        public ProductManager(IProductDal productDal,ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }
        
        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            //  var context = new ValidationContext<Product>(product);
            //  ProductValidator productValidator = new ProductValidator();
            ////  ProductValidator un validation kurallarinin calismasi icin new lenmek zorundadir.Cunku biz
            // // validation kurallarini ProductValidator da  constructor icerisine yazdik
            //  var result = productValidator.Validate(context);

            //  if (!result.IsValid)
            //  {
            //      throw new ValidationException(result.Errors);
            //  }

            //  ValidationTool.Validate(new ProductValidator(), product);

            IResult result = BusinessRules.Run(CheckIfProductNameExist(product.ProductName),
                CheckIfProductOfCategoryCorrect(product.CategoryId),
                CheckIfCategoryLimitedExceded());
            if (result!=null)
            {
                return result;
            }
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult <Product> GetById(int productId)
        {
            if (DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<Product>(Messages.ProductNameInvalid);
            }
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductID == productId),
                Messages.ProductsListed);
        }

        public IDataResult <List<Product>> GetByIdCategory(int categoryId)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == categoryId),
                Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice <= max && p.UnitPrice >= min),
                Messages.ProductsListed);
        }

        public IDataResult <List<ProductDetailDto>> GetPDetailsDto()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetAllDetailDto(),Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetProducts()
        {
            if (DateTime.Now.Hour==22)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductsListed);
        }

        private IResult CheckIfProductOfCategoryCorrect(int categoryId)
        {
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result>10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult();
        }

        private IResult CheckIfProductNameExist(string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExist);
            }
            return new SuccessResult();
        }

        private IResult CheckIfCategoryLimitedExceded()
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count>15)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }
            return new SuccessResult();
        }

    }
}
