using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_C07.Models;

[Table("ComponentManufacturers")]
public class ComponentManufacturers
{
    [Key]
    public int Id { get; set; }

    [Column(TypeName = "nvarchar(30)")]
    public string Abbreviation { get; set; } = string.Empty;

    [Column(TypeName = "nvarchar(300")]
    public string FullName { get; set; } = string.Empty;
    
    public DateTime FoundationDate { get; set; }
}