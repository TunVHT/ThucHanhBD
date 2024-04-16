using Microsoft.EntityFrameworkCore;

public class MigrationService
{
    private readonly myDbContext _context;

    public MigrationService(myDbContext context)
    {
        _context = context;
    }

    public void CreateMigration(string migrationName)
    {
        _context.Database.EnsureCreated(); // Đảm bảo cơ sở dữ liệu được tạo nếu chưa tồn tại
        _context.Database.Migrate(); // Migrate đến phiên bản mới nhất

        // Tạo migration
        _context.Database.GetDbConnection().Open();
        using var command = _context.Database.GetDbConnection().CreateCommand();
        command.CommandText = $"dotnet ef migrations add {migrationName}";
        command.ExecuteNonQuery();
    }
}
