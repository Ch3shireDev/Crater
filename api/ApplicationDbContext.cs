using api.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace api
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        internal List<Message> GetMessages()
        {
            return Messages.ToList();
        }

        internal Message GetMessage(int id)
        {
            var message = Messages.FirstOrDefault(m => m.Id == id);
            return message;
        }

        internal void CreateMessage(Message message)
        {
            Messages.Add(message);
            SaveChanges();
        }
    }
}