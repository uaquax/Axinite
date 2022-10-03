using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Axinite.Web.Areas.Identity.Data;

public class AxiniteWebUser : IdentityUser
{
    [PersonalData]
    [Column(TypeName = "nvarchar(100)")]
    public string? Name { get; set; }

    [PersonalData]
    [Column(TypeName = "nvarchar(100)")]    
    public string? Email { get; set; }
}

