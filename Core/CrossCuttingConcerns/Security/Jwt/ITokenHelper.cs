using Core.CrossCuttingConcerns.Security.Entities;

namespace Core.CrossCuttingConcerns.Security.Jwt
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}
