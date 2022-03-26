namespace Core.CrossCuttingConcerns.Security.Jwt
{
    public partial class JwtHelper
    {
        public class TokenOptions
        {
            public string Audience { get; set; }
            public string Issuer { get; set; }
            public int AccessTokenExpiration { get; set; }
            public string SecurityKey { get; set; }
        }
    }
}
