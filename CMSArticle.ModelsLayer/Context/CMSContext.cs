using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace CMSArticle.ModelsLayer.Context
{
    public class CMSContext : DbContext
    {
        public DbSet<Category>categories { get; set; }
        public DbSet<Article>articles { get; set; }
        public DbSet<Admin>admins { get; set; }
        public DbSet<Comment>comments { get; set; }
    }
}
