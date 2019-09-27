namespace AuthenticationUser.Domain.Models.Request.Login
{
    public class LoginModelRequest
    {
        public string GrantType { get; set; }
        public string RefreshToken { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
