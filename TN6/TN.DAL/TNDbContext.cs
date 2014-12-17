using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TN.Models;

namespace TN.DAL
{
    public class TNDbContext : DbContext
    {
        public TNDbContext()
            : base("TN")
        {

        }




        public DbSet<AnonymousSubscription> AnonymousSubscriptions { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Comment> Comments { get; set; }

        

    }
}
