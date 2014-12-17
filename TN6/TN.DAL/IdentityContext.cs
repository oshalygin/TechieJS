using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

using TN.Models;


namespace TN.DAL
{
    public class IdentityContext : IdentityDbContext<CustomUser>
    {
        public IdentityContext()
            : base("TN")
        {


        }

        public DbSet<SocialMediaReference> SocialMediaReferences { get; set; }
    }
}
