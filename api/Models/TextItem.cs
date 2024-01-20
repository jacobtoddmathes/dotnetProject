namespace WebApi.Models;

public class TextItem
{
    public long Id { get; set; }
    public DateOnly Date { get; set; }

    public string? Text { get; set; }
}