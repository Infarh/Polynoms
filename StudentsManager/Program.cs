using StudentsManager;

var students = new Student[]
{
    new Student
    {
        LastName = "Иванов",
        FirstName = "Иван",
        Patronymic = "Иванович",
        Rating = 3.14,
    },
    new Student
    {
        Id = 1,
        LastName = "Петров",
        FirstName = "Пётр",
        Patronymic = "Петрович",
        Rating = 42,
    },
    new Student
    {
        Id = 1,
        LastName = "Сидоров",
        FirstName = "Сидор",
        Patronymic = "Сидорович",
        Rating = 83,
    },
};

XmlDocumentExamples.WriteDocument(students, "students.xml");

//Console.ReadLine();