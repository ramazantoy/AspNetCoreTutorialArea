using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project_4.Entities.Domains;

namespace Project_4.DataAccess.Configurations
{
    public class WorkConfiguration : IEntityTypeConfiguration<Work>
    {
        public void Configure(EntityTypeBuilder<Work> builder)
        {
            
            builder.ToTable("works");
            
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("work_id");
            
            
            builder.Property(x => x.Definition).HasColumnName("definition").HasMaxLength(50).IsRequired();

            builder.Property(x => x.IsCompleted).HasColumnName("is_completed").IsRequired();
            
        }
    }
}