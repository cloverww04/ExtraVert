#pragma warning disable CA1050
public class Plant {
    public string? Species { get; set; }
    public int LightNeeds { get; set; }
    public decimal AskingPrice { get; set; }
    public string? City { get; set; }
    public bool Sold { get; set; }
    public string? Zip { get; set; }
    public DateTime AvailableUntil { get; set; }

}