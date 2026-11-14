namespace Api.Models;

public class CreateNewBookCommand
{
    public string? Title { get; set; }
    public int ReleaseYear { get; set; }
    public string? Author { get; set; }
}
