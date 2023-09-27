namespace uDrive.Backend.Model.DTO;

/// <summary>
/// Response Interface, to send custom data at <see cref="Data"/> as <see cref="IEntity"/> object
/// </summary>
/// <typeparam name="TEntity">The <see cref="IDTO"/></typeparam>
public interface IResponseInterface<TEntity> where TEntity : class, IDTO
{
    /// <summary>
    /// boolean, if the request was successful
    /// </summary>
    bool Success { get; set; }

    /// <summary>
    /// The data, send back
    /// </summary>
    TEntity Data { get; set; }

    /// <summary>
    /// A customized Message
    /// </summary>
    string Message { get; set; }
}
