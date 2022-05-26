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
    public string? SuggustedProduct {get;set;}
}