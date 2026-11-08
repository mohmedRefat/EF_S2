using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


[Table("EventOrganizers")]
public class Organizer
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = null!;

    [MaxLength(150)]
    public string? CompanyName { get; set; }

    public bool IsVerified { get; set; }

    // Navigation properties
    public OrganizerProfile? Profile { get; set; }
    public List<Event> Events { get; set; } = new();
}