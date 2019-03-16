using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace PainGuestApplication.Model.EFConfig
{
    public class ApplicationUserEFConfig : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasOne(a => a.Language).WithMany(b => b.Users);
            builder.HasIndex(a => a.B2CObjectId).IsUnique();
        }
    }
}
