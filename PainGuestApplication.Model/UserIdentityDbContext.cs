using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PainGuestApplication.Model.EFConfig;
using System;
using System.Collections.Generic;
using System.Text;

namespace PainGuestApplication.Model
{
    public class UserIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public UserIdentityDbContext(DbContextOptions<UserIdentityDbContext> options) : base(options)
        {

        }

        public DbSet<AccessLog> AccessLogs { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<B2BAccount> B2BAccounts { get; set; }
        public DbSet<B2BAccountRoom> B2BAccountRooms { get; set; }
        public DbSet<BankAccountInformation> B2BAccountInformations { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<PainGuestAgreement> PainGuestAgreements { get; set; }
        public DbSet<PainGuestRoomAllotment> PainGuestRoomAllotments { get; set; }
        public DbSet<RentTransaction> RentTransactions { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<TermsAndConditions> TermsAndConditions { get; set; }
        public DbSet<UserTermsAcceptance> UserTermsAcceptances { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration<ApplicationUser>(new ApplicationUserEFConfig());
        }
    }
}
