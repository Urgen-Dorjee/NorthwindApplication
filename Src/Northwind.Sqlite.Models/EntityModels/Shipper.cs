using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Common.Shared;

public class Shipper
{
    public Shipper()
    {
        Orders = new HashSet<Order>();
    }

    [Key] public int ShipperId { get; set; }

    [Required]
    [Column(TypeName = "nvarchar (40)")]
    public string CompanyName { get; set; } = null!;

    [Column(TypeName = "nvarchar (24)")] public string? Phone { get; set; }

    [InverseProperty("ShipViaNavigation")] public virtual ICollection<Order> Orders { get; set; }
}