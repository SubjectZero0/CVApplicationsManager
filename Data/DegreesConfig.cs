using CVApplicationsManager.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CVApplicationsManager.Data
{
    public class DegreesConfig : IEntityTypeConfiguration<DegreesModel>
    {
        public void Configure(EntityTypeBuilder<DegreesModel> builder)
        {
            builder.HasData
            (
                new DegreesModel
                {
                    Id = 1,
                    DegreeName = "Secondary"
                },
                new DegreesModel
                {
                    Id = 2,
                    DegreeName = "Bachelor's"
                },
                new DegreesModel
                {
                    Id = 3,
                    DegreeName = "Master's"
                },
                new DegreesModel
                {
                    Id = 4,
                    DegreeName = "PhD"
                }
            );
        }
    }
}
