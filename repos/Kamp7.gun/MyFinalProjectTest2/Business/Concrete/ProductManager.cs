using Business.Abstract;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
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
        // ILogger _logger;
        ICategoryService _categoryService;
        public ProductManager(IProductDal productDal,ICategoryService categoryService)//ILogger logger
        {
            _productDal = productDal;
            //   _logger = logger;
            _categoryService = categoryService;
        }

      [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
            //var context = new ValidationContext<Product>(product);
            //ProductValidator productValidator = new ProductValidator();
            //var result = productValidator.Validate(context);
            //if (!result.IsValid)
            //{
            //    throw new ValidationException(result.Errors);
            //}
            //ProductValidator un validation kurallarinin calismasi icin new lenmek zorundadir.Cunku biz
            //validation kurallarini ProductValidator da  constructor icerisine yazdik
            // ValidationTool.Validate(new ProductValidator(), product);

            //Loglama Ornegi
            //_logger.Log();
            //try
            //{
            //    _productDal.Add(product);
            //    return new SuccessResult(Messages.ProductAdded);
            //}
            //catch (Exception)
            //{

            //    _logger.Log();
            //}
            //return new ErrorResult(Messages.ProductNameInvalid);

            IResult result = BusinessRules.Run(CheckIfProductCountOfCategory(product.CategoryId),
              CheckIfProductNameExist(product.ProductName),
              CheckIfCategoryLimitedExceded());

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

        public IDataResult <Product> Get(int id)
        {
            if (DateTime.Now.Hour==23)
            {
                return new ErrorDataResult<Product>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == id),
                Messages.ProductDetailListed);
        }

        public IDataResult <List<Product>> GetAll()//DataAccess nesnesinden bir method kullanmaliyiz ama DataAccess e de bagimli
            //olmamaliyiz...Dependency injection
        {
            if (DateTime.Now.Hour==11)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);
        }

        public IDataResult <List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id), 
                Messages.ProductsListed);
        }

        public IDataResult <List<Product>> GetAllByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max),
                Messages.ProductsListed);
        }

        public IDataResult <List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails(), Messages.ProductsListed);
        }

        public IResult Update(Product product)
        {
            _productDal.Update(product);
            return new SuccessResult(Messages.ProductUpdated);
        }

        private IResult CheckIfProductCountOfCategory(int categoryId)
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

        private IResult CheckIfCategoryLimitedExceded() {

            var result = _categoryService.GetAll();
            if (result.Data.Count>15)
            {
                return new ErrorResult(Messages.CategoryLimitedExceded);
            }
            return new SuccessResult();
        
        }




    }
}
