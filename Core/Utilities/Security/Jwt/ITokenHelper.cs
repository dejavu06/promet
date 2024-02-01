using Core.Dtos.UserOperations;
using Core.Entities.Concrete.UserOperations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Security.Jwt
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(UserDto user, List<OperationClaimDto> operationClaims);
    }
}