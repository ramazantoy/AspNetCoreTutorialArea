using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Project_3.Web.Data.Configurations
{
    public abstract class ConfigureEntities<T> : IEntityTypeConfiguration<T> where T : class
    {
        public  abstract  void Configure(EntityTypeBuilder<T> builder);
    }
}