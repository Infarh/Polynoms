using Microsoft.EntityFrameworkCore;

namespace StudentsManager.Context;

public class StudentsDB : DbContext
{
    public DbSet<Student> Students { get; set; }

    public DbSet<StudentGroup> Groups { get; set; }

    public StudentsDB(DbContextOptions<StudentsDB> options) : base(options)
    {
        
    }
}
