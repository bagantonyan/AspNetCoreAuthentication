namespace AspNetCoreAuthentication.BLL.Models.Abstractions
{
    public abstract class BaseResponseDTO
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
