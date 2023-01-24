using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PollingApp.Entities;

namespace PollingApp.Application.ModelConfigurations;

public class PollModelConfiguration : IEntityTypeConfiguration<Poll>
{
    public void Configure(EntityTypeBuilder<Poll> builder)
    {
        builder.ToTable("Polls");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Id).IsRequired();
        builder.Property(x => x.QuestionText).HasMaxLength(512);

        builder.HasMany(x => x.Answers);
    }
}