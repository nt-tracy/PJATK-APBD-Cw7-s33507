using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace APBD_C07.Models;

[Table("PCComponents"), PrimaryKey(nameof(PCId), nameof(ComponentCode))]
public class PCComponents
{
    public int PCId { get; set; }

    [Column(TypeName = "char(10)")]
    public string ComponentCode { get; set; }
    
    public int Amount { get; set; }

}