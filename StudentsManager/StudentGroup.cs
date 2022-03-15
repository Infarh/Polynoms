namespace StudentsManager;

public class StudentGroup
{
    public int Id { get; set; }

    public string Name { get; set; }

    public ICollection<Student> Students { get; set; } = new HashSet<Student>();
}
