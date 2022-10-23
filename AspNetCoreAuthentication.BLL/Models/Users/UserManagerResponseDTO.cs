namespace AspNetCoreAuthentication.BLL.Models.Users
{
    public class UserManagerResponseDTO
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
