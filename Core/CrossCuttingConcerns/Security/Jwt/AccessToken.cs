namespace Core.CrossCuttingConcerns.Security.Jwt
{
    public class AccessToken
    {
        public string Token { get; set; }
        public DateTime Expiration { get; set; }

    }
}
