namespace uDrive.Backend.Model.DTO;

public interface IResponseInterface<TEntity> where TEntity : class, IDTO
{
    bool Success { get; set; }
    TEntity Data { get; set; }
    string Message { get; set; }
}
