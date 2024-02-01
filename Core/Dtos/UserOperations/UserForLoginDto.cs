namespace Core.Dtos.UserOperations
{
    public class UserForLoginDto : BaseDto
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public bool IsAdmin { get; set; }
    }
}