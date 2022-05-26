using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Y23_DirtDwellers.Models;

public class Plant
{
    public int PlantId { get; set; }
    public string? Name { get; set; }

    public string? Picture { get; set; }
    public string? Description { get; set; }
    public string? Instructions { get; set; }
    public string? GrowingStage { get; set; }

    public string? FloweringStage { get; set; }

    // [Range(0, 20000)]
    // [DataType(DataType.Currency)]
    // [Column(TypeName = "decimal(7,2)")]
    // public decimal? Price { get; set; } = 1000;
}