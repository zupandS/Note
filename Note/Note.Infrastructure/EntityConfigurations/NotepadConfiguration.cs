using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Note.Core;
using Note.Core.Entities;

namespace Note.Infrastructure.EntityConfigurations
{
    public class NotepadConfiguration : IEntityTypeConfiguration<Notepad>
    {
        public void Configure(EntityTypeBuilder<Notepad> builder)
        {
            builder.Property(prop => prop.Id).ValueGeneratedOnAdd();
            builder.Property(prop => prop.Title).HasMaxLength(100);
        }

    }
}