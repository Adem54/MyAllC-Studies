using Core.DataAccess.EntityFramework;

using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete
{
    public class EfUserDal : EfEntityRepostoryBase<User, NorthwindContext>, IUserDal
    {
        //Buraya bir join atalim.Claim ile user tablosunun birlesmis hali 
        //Buraya neden ihtiyacim var cunku biz token uretecegimiz methodu yazarken parametre olarak bize
        //users ve claims ler gerekiyor ve bizde o kullanicinin claims lerini bulmamiz lazm
        //Normalde dogrudan claims tablosunda sadece claimId ve claimName var ve biz hangi user a
        //ait olduklarini bilmiyoruz...
        public List<OperationClaim> GetUserClaimDto(User user)
        {
            using (NorthwindContext context=new NorthwindContext())
            {
               var result = from oC in context.OperationClaims2
                             join uOC in context.UserOperationClaims2
                             on oC.Id equals uOC.OperationClaimId
                             where uOC.UserId == user.Id
                             select new OperationClaim
                             {
                                Id=oC.Id,
                                Name=oC.Name
                             };
                return result.ToList();

                           
            }
        }
    }
}
//var result = from oCT in context.OperationClaimsTest
//             join uOCT in context.UserOperationClaimsTest
//             on oCT.Id equals uOCT.OperationClaimId
//             where uOCT.UserId == userTest.Id
//             select new OperationClaimTest
//             {
//                 Id = oCT.Id,
//                 Name = oCT.Name
//             };
//return result.ToList();