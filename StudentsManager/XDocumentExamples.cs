using System.Globalization;
using System.Xml.Linq;

namespace StudentsManager;

public static class XDocumentExamples
{
    public static void WriteXML(IEnumerable<Student> Students, string FileName)
    {
        var xml = new XDocument();
        var students = new XElement("Students");
        xml.Add(students);

        foreach (var student in Students)
        {
            students.Add(new XElement("Student",
                new XAttribute("id", student.Id),
                new XElement("LastName", student.FirstName),
                new XElement("FirstName", student.FirstName),
                new XElement("Patronymic", student.Patronymic),
                new XElement("Rating", student.Rating)));
        }

        xml.Save(FileName);
    }

    public static void WriteXMLSimple(IEnumerable<Student> Students, string FileName)
    {
        new XDocument(
            new XElement("Students",
                Students.Select(stud => new XElement("Student",
                    new XAttribute("id", stud.Id),
                    new XElement("LastName", stud.FirstName),
                    new XElement("FirstName", stud.FirstName),
                    new XElement("Patronymic", stud.Patronymic),
                    new XElement("Rating", stud.Rating)))))
           .Save(FileName);
    }

    public static Student[] ReadXML(string FileName)
    {
        var students = new List<Student>();

        var xml = XDocument.Load(FileName);

        var students_node = xml.Element("Students");

        foreach (var student_node in students_node.Elements("Student"))
        {
            var id = (int)student_node.Attribute("id");

            var last_name = (string?)student_node.Element("LastName");
            var first_name = (string?)student_node.Element("FirstName");
            var patronymic = (string?)student_node.Element("patronymic");

            var rating = (double)student_node.Element("Rating");

            var student = new Student
            {
                Id = id,
                LastName = last_name,
                FirstName = first_name,
                Patronymic = patronymic,
                Rating = rating,
            };

            students.Add(student);
        }


        return students.ToArray();
    }

    private static Student[] ReadXMLSimple(string FileName)
    {
        return XDocument.Load(FileName)
           .Element("Students")!
           .Elements("Student")
           .Select(student_node => new Student
            {
                Id = (int)student_node.Attribute("id")!,
                LastName = (string)student_node.Element("LastName")!,
                FirstName = (string)student_node.Element("FirstName")!,
                Patronymic = (string)student_node.Element("Patronymic")!,
                Rating = (double)student_node.Element("Rating")!,
            })
           .ToArray();
    }
}