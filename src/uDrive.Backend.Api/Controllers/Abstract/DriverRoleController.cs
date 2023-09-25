using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using uDrive.Backend.Api.Services.Interfaces;
using uDrive.Backend.Model;
using static System.Net.Mime.MediaTypeNames;

namespace uDrive.Backend.Api.Controllers.Abstract;

/// <summary>
/// Basic Controller for Get,Post,Put,Patch,Delete Methods, which need at least an <see cref="UDriveRoles.Driver"/> Role
/// </summary>
/// <typeparam name="TEntity"></typeparam>
[Authorize(Roles = $"{UDriveRoles.Secretary},{UDriveRoles.Administrator},{UDriveRoles.Person}")]
public class DriverRoleController<TEntity> : PersonRoleController<TEntity>
    where TEntity : class, IEntity
{

    /// <inheritdoc />
    public DriverRoleController(ILogger<DriverRoleController<TEntity>> logger, ApplicationDbContext context, IAuthService authService) 
        : base(logger, context, authService)
    {
       
    }

}
