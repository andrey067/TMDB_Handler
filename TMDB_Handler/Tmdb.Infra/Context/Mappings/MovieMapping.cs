using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Tmdb.Domain.Entities;
using Tmdb.Domain.ValueObject;

namespace Tmdb.Infra.Context.Mappings
{
    public class MovieMapping : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.Ignore(p => p.IsValid);
            builder.Ignore(p => p.Errors);
        }
    }
}
