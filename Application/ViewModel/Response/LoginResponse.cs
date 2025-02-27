namespace Application.ViewModel.Response
{
    public class LoginResponse
    {
        public string? Token { get; set; }
        public TimeSpan Expiration { get; set; }
        public UserData? User { get; set; }

        public class UserData
        {
            public int? Id { get; set; }
            public string? Name { get; set; }
        }
    }
}
