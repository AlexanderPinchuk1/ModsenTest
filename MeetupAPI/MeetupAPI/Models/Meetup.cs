using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text.Json;

namespace MeetupAPI.Models
{
    public class Meetup
    {
        public Guid Id { get; set; }

        public string? Theme { get; set; }

        public string? Description { get; set; }

        public List<string>? Speakers { get; set; }

        public DateTime Date { get; set; }

        public string? Place { get; set; }
    }



    public class MeetupConfig : IEntityTypeConfiguration<Meetup>
    {
        public void Configure(EntityTypeBuilder<Meetup> builder)
        {
            builder.HasKey(meetup => meetup.Id);
            builder.Property(meetup => meetup.Id).HasDefaultValueSql("newsequentialid()");

            builder.Property(meetup => meetup.Speakers)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, null as JsonSerializerOptions),
                    v => JsonSerializer.Deserialize<List<string>>(v, null as JsonSerializerOptions),
                    new ValueComparer<List<string>>((c1 , c2) => (c1 == null || c2 == null) ? c1 == c2 : c1.SequenceEqual(c2), 
                    c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),c => c.ToList()))
                .IsRequired();
        
            builder.Property(meetup => meetup.Theme).IsRequired().HasMaxLength(100);
            builder.Property(meetup => meetup.Place).IsRequired().HasMaxLength(100);
            builder.Property(meetup => meetup.Description).IsRequired().HasMaxLength(300);
            builder.ToTable(name: "Meetup");
        }
    }
}