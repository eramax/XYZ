using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity.EntityFramework;

namespace XYZ.DAL.Models
{
    [Table("AdminClaim")]
    public partial class AdminClaim : IdentityUserClaim<string>
    {
      
    }
}