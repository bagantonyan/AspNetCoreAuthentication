namespace AspNetCoreAuthentication.DAL.Entities.Abstractions
{
    public interface IBaseEntity
    {
        long Id { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime ModifiedDate { get; set; }
        DateTime? DeletedDate { get; set; }
    }
}
