using Core.Entities.Concrete;

using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.jwt
{
    public interface ITokenHelper
    {//KUllanici bilgisi ve rolleri lazim bana burda token olustrmak icin...
        AccessToken CreateToken(UserTest user, List<OperationClaimTest> operationClaimsTest);
    }
}
