using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjBiblio.Domain.Entities;

namespace ProjBiblio.Infrastructure.Data.Context.Config
{
  public class CampanhaMarketingLivroConfiguration : IEntityTypeConfiguration<CampanhaMarketingLivro>
  {
    public void Configure(EntityTypeBuilder<CampanhaMarketingLivro> builder)
    {
      builder.HasKey(cam => new { cam.CampanhaId, cam.LivroId });

      builder.HasOne(cam => cam.Livro)
             .WithMany(liv => liv.LivCampanha)
             .HasForeignKey(cam => cam.LivroId);

        builder.HasOne(cam => cam.CampanhaMarketing)
               .WithMany(mkt => mkt.LivroCampanha)
               .HasForeignKey(cam => cam.CampanhaId);
    }
  }
}