using Data;
using Microsoft.EntityFrameworkCore;

using var context = new EventHubContext();

Console.WriteLine($"Can connect: {context.Database.CanConnect()}");

if (!context.Organizers.Any())
{
    var organizer = new Organizer
    {
        Name = "Mohamed Khaled",
        CompanyName = "Mo tech",
        IsVerified = true,
        Profile = new OrganizerProfile
        {
            Biography = "Organizer of tech and community events",
            WebsiteUrl = "https://MOtech.com",
            LogoUrl = "https://MOtech.com/logo.png"
        }
    };

    organizer.Events.Add(new Event
    {
        Title = "Spring Tech Conference",
        Description = "Conference about software development",
        StartDate = DateTime.Now.AddDays(10),
        EndDate = DateTime.Now.AddDays(11),
        MaxAttendees = 50
    });

    organizer.Events.Add(new Event
    {
        Title = "Community Meetup",
        Description = "Monthly networking meetup",
        StartDate = DateTime.Now.AddDays(30),
        MaxAttendees = 100
    });

    var attendee = new Attendee
    {
        FullName = "Hasan Mansour",
        Email = "Hasan@example.com",
        Street = "25 Main Street",
        City = "Alexandria",
        Country = "Egypt",
        PostalCode = "21500",
        Badge = new Badge
        {
            BadgeNumber = 2001,
            IssuedDate = DateTime.Now,
            Tier = BadgeTier.VIP
        }
    };

    context.Organizers.Add(organizer);
    context.Attendees.Add(attendee);
    context.SaveChanges();
    Console.WriteLine("Sample data inserted.");
}

Console.WriteLine("\n--- Organizers ---");
foreach (var o in context.Organizers.Include(o => o.Profile).Include(o => o.Events))
{
    Console.WriteLine($"{o.Name} ({o.CompanyName}) | Verified: {o.IsVerified} | Website: {o.Profile?.WebsiteUrl}");
    foreach (var e in o.Events)
        Console.WriteLine($"   - {e.Title} | {e.StartDate:d} | Max: {e.MaxAttendees}");
}

Console.WriteLine("\n--- Attendees ---");
foreach (var a in context.Attendees.Include(a => a.Badge))
{
    Console.WriteLine($"{a.FullName} | {a.Email} | {a.FullAddress} | Badge #{a.Badge?.BadgeNumber} ({a.Badge?.Tier})");
}