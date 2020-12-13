using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjBiblio.Domain.Entities;

namespace ProjBiblio.Infrastructure.Data.Context.Config
{
    public class CampanhaMarketingConfiguration: IEntityTypeConfiguration<CampanhaMarketing>
    {
        public void Configure(EntityTypeBuilder<CampanhaMarketing> builder) {
            builder.HasKey(cam => cam.CampanhaMarketingId);
            builder.Property(cam => cam.Descricao).IsRequired().HasMaxLength(100);
            builder.Property(cam => cam.DataInicio).IsRequired();
            
        }
    }
}