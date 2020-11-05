using System;
using System.Collections.Generic;
using System.Linq;
using api.Models;
using Microsoft.EntityFrameworkCore;

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
            var messages = Messages.ToList();
            messages.Reverse();
            return messages.ToList();
        }

        internal Message GetMessage(int id)
        {
            var message = Messages.FirstOrDefault(m => m.Id == id);
            return message;
        }

        internal void CreateMessage(Message message)
        {
            message.DatePublished = DateTime.Now;
            Messages.Add(message);
            SaveChanges();
        }
    }
}