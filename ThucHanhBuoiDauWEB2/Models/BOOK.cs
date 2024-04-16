public class Book
{
    public ICollection<BookAuthor> BookAuthors { get; set; }


    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsRead { get; set; }
    public DateTime? DateRead { get; set; }
    public int Rating { get; set; }
    public int Genre { get; set; }
    public string CoverUrl { get; set; }
    public DateTime DateAdded { get; set; }
    public int PublisherId { get; set; }
    public Publisher Publisher { get; set; }
    public object Authors { get; internal set; }
}

public class Authors
{
    public int Id { get; set; }
    public string FullName { get; set; }
    public ICollection<BookAuthor> BookAuthors { get; set; }  // Danh sách các thực thể BookAuthor
}

public class Publisher
{
    public int Id { get; set; }
    public string Name { get; set; }
    public List<Book> Books { get; set; }
}
