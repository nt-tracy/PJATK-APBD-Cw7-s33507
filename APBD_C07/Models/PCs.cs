using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_C07.Models;

[Table("PCs")]
public class PCs
{
    [Key]
    public int Id { get; set; }

    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;

    [Column(TypeName = "float(5)")]
    public double Weight { get; set; }
    
    public int Warranty { get; set; }
    
    public DateTime CreatedAt { get; set; }
    
    public int Stock { get; set; }

    public IEnumerable<PCComponents> PcComponents { get; set; } = [];
}