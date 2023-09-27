namespace uDrive.Backend.Model.DTO
{
    /// <summary>
    /// Response Object, to send custom data at <see cref="Data"/> as <see cref="IEntity"/> object
    /// </summary>
    /// <typeparam name="TEntity">The <see cref="IDTO"/></typeparam>
    public class Response<TEntity> where TEntity : class, IDTO
    {
        /// <summary>
        /// boolean, if the request was successful
        /// </summary>
        public bool Success { get; set; } = true;

        /// <summary>
        /// The data, send back
        /// </summary>
        public TEntity Data { get; set; }

        /// <summary>
        /// A customized Message
        /// </summary>
        public string Message { get; set; }
    }
}
