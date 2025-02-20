using ExaminantionSystem_R3.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace ExaminantionSystem_R3.Data.EntityMapping
{
    public class QuestionMapping : IEntityTypeConfiguration<Question>
    {
        public void Configure(EntityTypeBuilder<Question> builder)
        {
            builder.Property(question => question.Head)
                .HasColumnType("varchar")
                .IsRequired()
                .HasMaxLength(500);

            builder.Property(question => question.isDeleted)
              .HasDefaultValue(false);
            builder.HasOne(q => q.Course);
        }

    }
    //public class BaseModelMapping : IEntityTypeConfiguration<BaseModel>
    //{
    //    public void Configure(EntityTypeBuilder<BaseModel> builder)
    //    {
    //        builder.Property(baseModel => baseModel.isDeleted)
    //          .HasDefaultValue(false);
    //    }
    //}
}
