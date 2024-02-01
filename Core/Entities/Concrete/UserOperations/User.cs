namespace Core.Entities.Concrete.UserOperations
{
    public class User : BaseEntity
    {
        public int ID { get; set; }

        public string FIRST_NAME { get; set; }

        public string LAST_NAME { get; set; }

        public string EMAIL { get; set; }

        public bool? STATUS { get; set; }

        public byte[] PASSWORD_SALT { get; set; }

        public byte[] PASSWORD_HASH { get; set; }
    }
}