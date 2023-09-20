using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using uDrive.Backend.Model;
using static System.Net.Mime.MediaTypeNames;

namespace uDrive.Backend.Api.Controllers.Abstract;

[Authorize(Roles = $"{UDriveRoles.Secretary},{UDriveRoles.Administrator},{UDriveRoles.Driver},{UDriveRoles.Person}")]
public class DriverRoleController<TEntity> : PersonRoleController<TEntity>
    where TEntity : class, IEntity
{


    public DriverRoleController(ILogger<DriverRoleController<TEntity>> logger, ApplicationDbContext context) 
        : base(logger, context)
    {
       
    }

}
