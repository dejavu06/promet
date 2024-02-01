namespace Core.Entities.Concrete.UserOperations
{
    public class UserOperationClaim : BaseEntity
    {
        public int ID { get; set; }

        public int? USER_ID { get; set; }
        
        public int? OPERATION_CLAIMS_ID { get; set; }
    }
}