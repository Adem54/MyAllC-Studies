using Business.Abstract;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.Business;
using Core.CrossCuttingConcerns.Validation;
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
    public class ProductManager : IProductService//Burda DataAccess class indan bir method kulanacagiz
                                                 //Dependency Injection
    {
        IProductDal _productDal;
        // ILogger _logger;
        ICategoryService _categoryService;

        public ProductManager(IProductDal productDal,ICategoryService categoryService )//ILogger logger
        {
            _productDal = productDal;
            _categoryService = categoryService;
            //_logger = logger;
        }

        [ValidationAspect(typeof(ProductValidator))]
        //Add methodunu ProductValidator daki kurallara gore dogrula diyoruz
        //Iste bunun kodu Core-Aspect-Autofac-Validation-ValidationAspect te yaziliyor
        //ValidationAspect te constructor da parametreye Type validatorType verilerek 
        //Attribute old icin Type ile gecmek zorundayiz herhangi bir nesneyi
        //iste ValidationAspect attribut unde typeof(ProductValidator) yazabiliyoruz
        public IResult Add(Product product)
        {
            //var context = new ValidationContext<Product>(product);
            //ProductValidator productValidator = new ProductValidator();
            //ProductValidator un validation kurallarinin calismasi icin new lenmek zorundadir.Cunku biz
            //validation kurallarini ProductValidator da  constructor icerisine yazdik
            //var result = productValidator.Validate(context);

            //if (!result.IsValid)
            //{
            //    throw new ValidationException(result.Errors);
            //}
            //Ustteki kodlari alttaki tek satira indirgedik ama AOP ile attribute ile 
            //Add methdounun ustune   // [ValidatonAspect(typeof(ProductValidator))]
            //ProductValidator u kullanarak bu methodu deriz
            //dogrula demektir
            //  ValidationTool.Validate(new ProductValidator(), product);//Tek satir da yapmis olduk
            //ProductValidator un validation kurallarinin calismasi icin new lenmek zorundadir.Cunku biz
            //validation kurallarini ProductValidator da  constructor icerisine yazdik
            //ORNEK LOGLAMA DENEMESI
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

            //if (CheckIfCountOfCategoryCorrect(product.CategoryId).Success)
            //{

            //    if (CheckIfProductNameExist(product.ProductName).Success)
            //    {
            //        //Yeni bir if buraya yazilir
            //        _productDal.Add(product);
            //        return new SuccessResult(Messages.ProductAdded);
            //        //Kod bu satira inerse zaten return den sonra
            //        //method biter..                                               
            //    }
            //}

            //return new ErrorResult();


            //BU YAPILAN GERCEK HAYATTA POLIMORFIZM DIR....

            IResult result = BusinessRule.Run(CheckIfCategoryLimitedExceded(), CheckIfProductNameExist(product.ProductName),
                CheckIfCountOfCategoryCorrect(product.CategoryId)
              );
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

        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour == 23)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);//


        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)

        {

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id), Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetAllByUnitPrice(decimal min, decimal max)
        {

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice > min && p.UnitPrice < max), Messages.ProductsListed);
        }

        public IDataResult<Product> GetById(int id)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == id),
                Messages.ProductDetail);
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductsDetails());
            //Mesaj vermek istemiyoruz mesaela burada da
        }

        public IResult Update(Product product)
        {

            _productDal.Update(product);
            return new SuccessResult(Messages.ProductUpdated);
        }

        private IResult CheckIfCountOfCategoryCorrect(int categoryId)
        {
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }
            return new SuccessResult();//Birsey donmene gerek yok cunku is kuralina uyuyor ve ekleyebiliyor
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

        private  IResult CheckIfCategoryLimitedExceded()
        {
            var result = _categoryService.GetAll();
            if (result.Data.Count > 15)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }
              return new SuccessResult();
        }
    }
}
