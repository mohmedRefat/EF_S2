
public class Badge
{
    public int Id { get; set; }
    public int BadgeNumber { get; set; }
    public DateTime IssuedDate { get; set; }
    public BadgeTier Tier { get; set; }

    public int AttendeeId { get; set; }
    public Attendee Attendee { get; set; } = null!;
}