using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ProyectoSGShoots6.Areas.Identity.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    public string nombre { get; set; }
    public string apellidoPaterno { get; set; }
    public string apellidoMaterno { get; set; }
    public string celular { get; set; }
    public string carnet { get; set; }
    public bool estado { get; set; }
    
}

