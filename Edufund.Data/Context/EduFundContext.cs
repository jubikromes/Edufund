using Edufund.Data.EntityMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Edufund.Data.Context
{
    public class EduFundContext : DbContext, IDbContext
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
            modelBuilder.ApplyConfiguration(new BoardConfiguration());
            modelBuilder.ApplyConfiguration(new EduSystemConfiguration());
            modelBuilder.ApplyConfiguration(new MemberWalletConfiguration());
            modelBuilder.ApplyConfiguration(new MemberConfiguration());
            modelBuilder.ApplyConfiguration(new EduWalletConfiguration());
            modelBuilder.ApplyConfiguration(new ReferralConfiguration());
        }
    }
}
