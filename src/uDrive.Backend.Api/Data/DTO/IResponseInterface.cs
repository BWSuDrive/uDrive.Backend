namespace uDrive.Backend.Api.Data.DTO;

public interface IResponseInterface<TEntity> where TEntity : class, IDTO
{
    bool Success { get; set; } 
    TEntity Data { get; set; }
    string Message { get; set; }
}
