using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_C07.Models;

[Table("Components"), ForeignKey()]
public class Components
{
    
    [Key] 
    [Column(TypeName = "char(10)")]
    public string Code { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
    
    public int ComponentManufacturersId { get; set; }
}