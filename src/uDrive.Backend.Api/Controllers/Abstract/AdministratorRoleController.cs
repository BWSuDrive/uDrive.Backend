using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using uDrive.Backend.Api.Services.Interfaces;
using uDrive.Backend.Model;
using static System.Net.Mime.MediaTypeNames;

namespace uDrive.Backend.Api.Controllers.Abstract;
/// <summary>
/// Basic Controller for Get,Post,Put,Patch,Delete Methods, which need at least an <see cref="UDriveRoles.Administrator"/> Role
/// </summary>
/// <typeparam name="TEntity"></typeparam>
[Authorize(Roles = UDriveRoles.Administrator)]
public abstract class AdministratorRoleController<TEntity> : SecretaryRoleController<TEntity>
    where TEntity : class, IEntity
{

    /// <inheritdoc />
    public AdministratorRoleController(ILogger<AdministratorRoleController<TEntity>> logger, ApplicationDbContext context, IAuthService authService) 
        : base(logger, context, authService)
    {
       
    }

}
