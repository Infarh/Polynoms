namespace StudentsManager;

[Serializable]
public class Student
{
    public int Id { get; set; }

    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string Patronymic { get; set; }

    public double Rating { get; set; }
}