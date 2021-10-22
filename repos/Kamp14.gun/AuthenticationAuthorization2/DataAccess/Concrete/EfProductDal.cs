using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete
{
    public class EfProductDal : EfEntityRepostoryBase<Product, NorthwindContext>, IProductDal
    {
        //Burda bir dto yazalim Product bilgileri ve Category isim bilgisi birlikte gelsin
        //Bunun icin hangi verileri istiyorsak once istediigmiz verilerin ooldugu bir 
        //property Dto class i olusturalim
        //ProductName,CategoryName,UnitPrice
        public List<ProductDetailDto> GetProductDetailDtos()
        {
            using (NorthwindContext context=new NorthwindContext())
            {
                var result = from p in context.Products
                             join c in context.Categories
                             on p.CategoryId equals c.CategoryId
                             select new ProductDetailDto
                             {
                                 Id = p.ProductId,
                                 ProductName = p.ProductName,
                                 CategoryName = c.CategoryName,
                                 UnitPrice = p.UnitPrice
                             };
                return result.ToList();
            }
        }
    }
}
