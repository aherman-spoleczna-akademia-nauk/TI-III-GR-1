using Api.Models;

namespace Api.Service;

public class BookService
{
    private List<Book> _books = new List<Book>();

    public BookService()
    {
        _books.Add(new Book { Title = "The Great Gatsby", ReleaseYear = 1925, Author = "F. Scott Fitzgerald" });
        _books.Add(new Book { Title = "To Kill a Mockingbird", ReleaseYear = 1960, Author = "Harper Lee" });
        _books.Add(new Book { Title = "1984", ReleaseYear = 1949, Author = "George Orwell" });
        _books.Add(new Book { Title = "Pride and Prejudice", ReleaseYear = 1813, Author = "Jane Austen" });
        _books.Add(new Book { Title = "The Catcher in the Rye", ReleaseYear = 1951, Author = "J.D. Salinger" });
        _books.Add(new Book { Title = "Ogniem i mieczem", ReleaseYear = 1919, Author = "H.Sienkiewicz" });
    }
    public List<Book> GetBooks(string? name)
    {
        if (!string.IsNullOrWhiteSpace(name))
            return _books.Where(b => b.Title.StartsWith(name)).ToList();
        else
            return _books;
    }

    public ApiResult AddNewBook(CreateNewBookCommand command)
    {
        var errors = new List<string>();
        if (string.IsNullOrWhiteSpace(command.Title))
            errors.Add("Brak tytułu");
        if (string.IsNullOrWhiteSpace(command.Author))
            errors.Add("Brak autora");
        if (command.ReleaseYear == 0)
            errors.Add("Brak roku wydania");

        if (errors.Any())
        {
            return new ApiResult
            {
                Success = false,
                Error = string.Join(", ", errors)
            };
        }

        var book = new Book
        {
            Title = command.Title,
            ReleaseYear = command.ReleaseYear,
            Author = command.Author
        };
        _books.Add(book);
        return new ApiResult
        {
            Success = true,
            Data = book.BookId.ToString()
        };
    }
}
