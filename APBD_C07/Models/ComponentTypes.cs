using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APBD_C07.Models;

[Table("ComponentTypes")]
public class ComponentTypes
{
    [Key]
    public int Id { get; set; }

    [Column(TypeName = "nvarchar(30)")]
    public string Abbreviation { get; set; } = string.Empty;

    [Column(TypeName = "nvarchar(150)")]
    public string Name { get; set; } = string.Empty;
}