namespace AspNetCoreAuthentication.DAL.Entities.Abstractions
{
    public class BaseEntity : IBaseEntity
    {
        public long Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
