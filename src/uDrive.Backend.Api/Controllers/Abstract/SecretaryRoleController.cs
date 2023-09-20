using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using uDrive.Backend.Model;
using static System.Net.Mime.MediaTypeNames;

namespace uDrive.Backend.Api.Controllers.Abstract;

[Authorize(Roles = $"{UDriveRoles.Secretary},{UDriveRoles.Administrator}")]
public class SecretaryRoleController<TEntity> : DriverRoleController<TEntity>
    where TEntity : class, IEntity
{


    public SecretaryRoleController(ILogger<SecretaryRoleController<TEntity>> logger, ApplicationDbContext context) 
        : base(logger, context)
    {
       
    }

}
