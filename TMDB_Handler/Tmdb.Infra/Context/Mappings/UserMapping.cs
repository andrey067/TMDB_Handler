﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tmdb.Domain.Entities;

namespace Tmdb.Infra.Context.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Ignore(p => p.IsValid);
            builder.Ignore(p => p.Errors);
            builder.Ignore(p => p.Password);

            builder.OwnsMany(x => x.Profiles, a =>
            {
                a.WithOwner().HasForeignKey(u => u.UserId);
                a.Property<int>("Id");
                a.HasKey("Id");
            });
        }
    }
}
