using Edufund.Data.EntityMapper;
using Edufund.Data.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Edufund.Data.Context
{
    public class EduFundContext : IdentityDbContext<
        EduUser, EduRole, int,
        EduUserClaim, EduUserRole, EduUserLogin,
        EduRoleClaim, EduUserToken>, IDbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EduFundContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public EduFundContext(DbContextOptions<EduFundContext> options)
            : base(options)
        {
            // TODO: Comment below this if you are running migrations commands
            // TODO: uncomment below line of you are running the application for the first time
            //this.Database.EnsureCreated();
        }

        /// <summary>
        /// Get or sets the devices data model
        /// </summary>

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<EduUser>(b =>
            {
                // Each User can have many UserClaims
                b.HasMany(e => e.Claims)
                    .WithOne(p => p.User)
                    .HasForeignKey(uc => uc.UserId)
                    .IsRequired().OnDelete(DeleteBehavior.Cascade);
                // Each User can have many UserLogins
                b.HasMany(e => e.Logins)
                    .WithOne(p => p.User)
                    .HasForeignKey(ul => ul.UserId)
                    .IsRequired().OnDelete(DeleteBehavior.Cascade);

                // Each User can have many UserTokens
                b.HasMany(e => e.Tokens)
                    .WithOne(p => p.User)
                    .HasForeignKey(ut => ut.UserId)
                    .IsRequired().OnDelete(DeleteBehavior.Cascade);

                // Each User can have many entries in the UserRole join table
                b.HasMany(e => e.UserRoles)
                    .WithOne(p => p.User)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired().OnDelete(DeleteBehavior.Cascade);

                //b.HasMany(e => e.UserRoles)
                //    .WithOne(e => e.User)
                //    .HasForeignKey(ur => ur.UserId)
                //    .IsRequired().OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<EduRole>(b =>
            {
                // Each Role can have many entries in the UserRole join table
                b.HasMany(e => e.UserRoles)
                    .WithOne(e => e.Role)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                // Each Role can have many associated RoleClaims
                b.HasMany(e => e.RoleClaims)
                    .WithOne(e => e.Role)
                    .HasForeignKey(rc => rc.RoleId)
                    .IsRequired();
            });
            modelBuilder.ApplyConfiguration(new BoardConfiguration());
            modelBuilder.ApplyConfiguration(new EduSystemConfiguration());
            modelBuilder.ApplyConfiguration(new MemberWalletConfiguration());
            modelBuilder.ApplyConfiguration(new MemberConfiguration());
            modelBuilder.ApplyConfiguration(new EduWalletConfiguration());
            modelBuilder.ApplyConfiguration(new ReferralConfiguration());
        }
    }
}
