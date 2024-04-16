using Microsoft.EntityFrameworkCore;

public class myDbContext : DbContext
{
    public myDbContext(DbContextOptions<myDbContext> options) : base(options)
    {
    }

    public DbSet<Book> Books { get; set; }
    public DbSet<Authors> Authors { get; set; }
    public DbSet<Publisher> Publishers { get; set; }
    public DbSet<BookAuthor> BookAuthors { get; set; }  // Junction table

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>()
          .ToTable("Books")
          .HasKey(b => b.Id);

        modelBuilder.Entity<Authors>()
          .ToTable("Authors")
          .HasKey(a => a.Id);

        modelBuilder.Entity<Publisher>()
          .ToTable("Publishers")
          .HasKey(p => p.Id);

        // Bảng trung gian BookAuthor
        modelBuilder.Entity<BookAuthor>()
          .HasKey(ba => new { ba.BookId, ba.AuthorId });

        modelBuilder.Entity<BookAuthor>()
          .HasOne(ba => ba.Book)
          .WithMany(b => b.BookAuthors)
          .HasForeignKey(ba => ba.BookId);

        modelBuilder.Entity<BookAuthor>()
          .HasOne(ba => ba.Author)
          .WithMany(a => a.BookAuthors)
          .HasForeignKey(ba => ba.AuthorId);

        // Định nghĩa mối quan hệ one-to-many giữa Publisher và Book
        modelBuilder.Entity<Publisher>()
            .HasMany(p => p.Books) // Đây là phần gây lỗi
            .WithOne(b => b.Publisher) // Nếu mối quan hệ là one-to-many, bạn cần sử dụng WithOne()
            .HasForeignKey(b => b.PublisherId); // Khóa ngoại của Book
    }
}

public class BookAuthor
{
    public int BookId { get; set; }
    public int AuthorId { get; set; }

    public Book Book { get; set; }
    public Authors Author { get; set; }
}
