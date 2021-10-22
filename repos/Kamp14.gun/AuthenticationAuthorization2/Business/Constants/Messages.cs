using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
      
        public static string ProductAdded="Product Added Successfully";
        public static string ProductDeleted= "Product Deleted Successfully";
        public static string ProductUpdated= "Product Updated Successfully";
        public static string ProductDetailListed= "ProductDetail Listed Successfully";
        public static string ProductsListed= "Product Added Successfully";
        public static string ProductListedByCategory="Product Listed By Category";
        public static string ProductDetailDtoListed="ProductDetailDto Listed";
        public static string CategoryAdded="Category Added";
        public static string CategoryDeleted="Category Deleted";
        public static string CategoryDetailListed="Category Detail Listed";
        public static string CategoriesListed="Categories Listed";
        public static string CategoryUpdated="Category Updated";
        public static string AccessTokenCreated="AccessToken Created";
        public static string UserNotFound="User Not Found";
        public static string PasswordError="Password Error";
        public static string SuccesfulLogin="Logged in successfully";
        public static string UserRegistered = "User Registered";
        public static string UserAlreadyRegistered = "User Already Registered";
        public static string AuthorizationDenied="You are not authorized";
        public static string ProductAlleredeExist="Product Allerede Exist";
        internal static string CategoryLimitExceded;
    }
}
