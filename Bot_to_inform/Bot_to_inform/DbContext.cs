using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Bot_to_inform
{
    internal class ApplicationContext: DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Tg_user> Tg_Users { get; set; }


        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=512server.ru;Port=5434;Database=postgres;Username=postgres;Password=to_inform_serv");
        }
    }
}
