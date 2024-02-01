using System;

namespace Core.Dtos.UserOperations
{
    public class UserDto : BaseDto
    {
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public byte[] PasswordSalt { get; set; }

        public string sPasswordSalt { get; set; }

        public byte[] PasswordHash { get; set; }

        public string sPasswordHash { get; set; }

        public DateTime? ExpirationDate { get; set; }

        public string IdentityNumber { get; set; }

        public string PhotoPath { get; set; }

        public string Title { get; set; }

        public string Phone { get; set; }

        public bool AdminPanel { get; set; }
    }
}