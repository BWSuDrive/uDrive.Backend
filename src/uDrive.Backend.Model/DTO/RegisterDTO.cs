using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uDrive.Backend.Model.DTO;

public class RegisterDTO : SignInUserDTO
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }

}
