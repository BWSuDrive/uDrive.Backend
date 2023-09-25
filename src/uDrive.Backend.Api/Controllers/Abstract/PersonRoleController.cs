using Microsoft.AspNetCore.Authorization;
using uDrive.Backend.Api.Services.Interfaces;
using uDrive.Backend.Model;

namespace uDrive.Backend.Api.Controllers.Abstract;

/// <summary>
/// Basic Controller for Get,Post,Put,Patch,Delete Methods, which need at least an <see cref="UDriveRoles.Person"/> Role
/// </summary>
/// <typeparam name="TEntity"></typeparam>
[Authorize(Roles = $"{UDriveRoles.Secretary},{UDriveRoles.Administrator},{UDriveRoles.Driver},{UDriveRoles.Person}")]

public class PersonRoleController<TEntity> : AnonymousController<TEntity>
    where TEntity : class, IEntity
{

    /// <inheritdoc />
    public PersonRoleController(ILogger<PersonRoleController<TEntity>> logger, ApplicationDbContext context, IAuthService authService) 
        : base(logger, context,authService)
    {
       
    }

}
