using ExaminantionSystem_R3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ExaminantionSystem_R3.Data.EntityMapping
{
    public class ChoiceMapping : IEntityTypeConfiguration<Choice>
    {
        public void Configure(EntityTypeBuilder<Choice> builder)
        {
            builder.Property(choice => choice.Text)
              .IsRequired()
              .HasMaxLength(200);

            builder.Property(choice => choice.IsCorrect)
                .HasDefaultValue(false);

            builder.Property(choice => choice.isDeleted)
              .HasDefaultValue(false);
        }
    }
}
