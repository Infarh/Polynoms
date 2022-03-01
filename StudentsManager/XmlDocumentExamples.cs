using System.Globalization;
using System.Xml;

namespace StudentsManager;

public static class XmlDocumentExamples
{
    public static void WriteDocument(IEnumerable<Student> Students, string FileName)
    {
        var xml_doc = new XmlDocument();
        var students_node = xml_doc.CreateElement("Students");
        xml_doc.AppendChild(students_node);

        //var student_ivanov_node = xml_doc.CreateElement("Student");
        //students_node.AppendChild(student_ivanov_node);

        //var last_name_node = xml_doc.CreateElement("LastName");
        //last_name_node.InnerText = "Иванов";
        //student_ivanov_node.AppendChild(last_name_node);

        foreach (var student in Students)
        {
            var student_node = xml_doc.CreateElement("Student");
            if (student.Id > 0)
            {
                var id_attribute = xml_doc.CreateAttribute("id");
                id_attribute.InnerText = student.Id.ToString();
                student_node.Attributes.Append(id_attribute);
            }

            students_node.AppendChild(student_node);

            var last_name_node = xml_doc.CreateElement("LastName");
            var first_name_node = xml_doc.CreateElement("FirstName");
            var patronymic_node = xml_doc.CreateElement("Patronymic");
            var rating_node = xml_doc.CreateElement("Rating");

            last_name_node.InnerText = student.LastName;
            first_name_node.InnerText = student.FirstName;
            patronymic_node.InnerText = student.Patronymic;
            rating_node.InnerText = student.Rating.ToString(CultureInfo.InvariantCulture);

            student_node.AppendChild(last_name_node);
            student_node.AppendChild(first_name_node);
            student_node.AppendChild(patronymic_node);
            student_node.AppendChild(rating_node);
        }

        xml_doc.Save(FileName);
    }

    public static Student[] ReadDocument(string FileName)
    {
        var doc = new XmlDocument();

        doc.Load(FileName);

        var students_node = doc.FirstChild;

        var students = new List<Student>();

        foreach (XmlElement student_node in students_node.ChildNodes)
        {
            //var id_str = student_node.Attributes["id"]?.Value;
            var id_str = student_node.GetAttribute("id");

            var last_name = student_node.GetElementsByTagName("LastName")[0].InnerText;
            var first_name = student_node.GetElementsByTagName("FirstName")[0].InnerText;
            var patronymic = student_node.GetElementsByTagName("Patronymic")[0].InnerText;
            var rating_text = student_node.GetElementsByTagName("Rating")[0].InnerText;

            var student = new Student
            {
                Id = int.TryParse(id_str, out var id) ? id : 0,
                LastName = last_name,
                FirstName = first_name,
                Patronymic = patronymic,
                Rating = double.TryParse(rating_text, NumberStyles.Any, CultureInfo.InvariantCulture, out var rating) ? rating : 0,
            };

            students.Add(student);
        }

        return students.ToArray();
    }
}