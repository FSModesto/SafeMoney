namespace Application.ViewModel.Request.User
{
    public class ResetPasswordEmailRequest
    {
        public string NewPassword { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
