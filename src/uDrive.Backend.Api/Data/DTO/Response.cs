namespace uDrive.Backend.Api.Data.DTO
{
    public class Response<TEntity> where TEntity :class, IDTO 
    {
        public bool Success { get; set; } = true;
        public TEntity Data { get ; set ; }
        public string Message { get ; set ; }
    }
}
