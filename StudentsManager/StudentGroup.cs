using System.ComponentModel.DataAnnotations.Schema;

namespace StudentsManager;

[Table("StudentsGroup")]
public class StudentGroup
{
    public int Id { get; set; }

    [Column("GroupName")]
    public string Name { get; set; }

    public ICollection<Student> Students { get; set; } = new HashSet<Student>();
}
