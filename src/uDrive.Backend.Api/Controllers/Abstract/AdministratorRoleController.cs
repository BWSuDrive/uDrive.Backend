using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using uDrive.Backend.Model;
using static System.Net.Mime.MediaTypeNames;

namespace uDrive.Backend.Api.Controllers.Abstract;

[Authorize(Roles = UDriveRoles.Administrator)]
public class AdministratorRoleController<TEntity> : SecretaryRoleController<TEntity>
    where TEntity : class, IEntity
{


    public AdministratorRoleController(ILogger<AdministratorRoleController<TEntity>> logger, ApplicationDbContext context) 
        : base(logger, context)
    {
       
    }

}
