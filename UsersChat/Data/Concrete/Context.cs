using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using UsersChat.Data.Entities;

namespace UsersChat.Data.Concrete
{
    public class Context:IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-JI387RJ\\SQLEXPRESS;initial catalog=UserMessageDB;integrated security=true");

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<UserMessage>().HasOne(x => x.SenderUser)
                .WithMany(y => y.SenderUsers)
                .HasForeignKey(z => z.SenderUserID)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Entity<UserMessage>().HasOne(x => x.ReceiverUser)
                .WithMany(y => y.ReceiverUsers)
                .HasForeignKey(z => z.ReceiveUserID)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Entity<Draft>().HasOne(x => x.SenderUser)
                .WithMany(y => y.SenderUsersDraft)
                .HasForeignKey(z => z.SenderUserID)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.Entity<Draft>().HasOne(x => x.ReceiverUser)
                .WithMany(y => y.ReceiverUsersDraft)
                .HasForeignKey(z => z.ReceiveUserID)
                .OnDelete(DeleteBehavior.ClientSetNull);
            base.OnModelCreating(builder);
        }

        public DbSet<UserMessage> UserMessages { get; set; }
        public DbSet<Draft> Drafts{ get; set; }
        public DbSet<Important> Importants{ get; set; }
        public DbSet<Trash> Trashes{ get; set; }
    }
}
