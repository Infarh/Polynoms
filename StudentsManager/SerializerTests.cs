using System.Runtime.Serialization.Formatters.Binary;
using System.Xml.Serialization;

namespace StudentsManager;

public static class SerializerTests
{
    public static void Run()
    {
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
        var new_students = XmlDocumentExamples.ReadDocument("students.xml");

        XDocumentExamples.WriteXML(students, "stud.xml");
        XDocumentExamples.WriteXMLSimple(students, "stud-simple.xml");

        var new_students2 = XDocumentExamples.ReadXML("stud.xml");
        var new_students3 = XDocumentExamples.ReadXML("stud.xml");

        var xml_serializer = new XmlSerializer(typeof(Student[]));

        using (var xml_file = File.Create("stud-serialized.xml"))
            xml_serializer.Serialize(xml_file, students);

        Student[] new_students4;
        using (var xml_file = File.OpenRead("stud-serialized.xml"))
            new_students4 = (Student[])xml_serializer.Deserialize(xml_file)!;

        var bin_serializer = new BinaryFormatter();
        using (var bin_file = File.Create("stud-serialized.bin"))
            bin_serializer.Serialize(bin_file, students);

        Student[] new_students5;
        using (var bin_file = File.OpenRead("stud-serialized.bin"))
            new_students5 = (Student[])bin_serializer.Deserialize(bin_file)!;
    }
}