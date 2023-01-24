using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PollingApp.Entities;

namespace PollingApp.Application.ModelConfigurations;

public class AnswerModelConfiguration : IEntityTypeConfiguration<Answer>
{
    public void Configure(EntityTypeBuilder<Answer> builder)
    {
        builder.ToTable("Answers");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).IsRequired();
        builder.Property(x => x.Title).HasMaxLength(512);
        builder.Property(x => x.Votes);
        builder.Property(x => x.Percents);
    }
}