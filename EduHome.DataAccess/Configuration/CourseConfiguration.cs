using EduHome.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EduHome.DataAccess.Configuration
{
    public class CourseConfiguration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.Property(x => x.Name).IsRequired(true).HasMaxLength(64);
            builder.Property(x => x.Description).HasMaxLength(200);
            builder.Property(x => x.Image).IsRequired(true);
        }
    }
}
