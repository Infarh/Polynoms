using System.Globalization;
using System.Xml;
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

var xml_doc = new XmlDocument();
var students_node = xml_doc.CreateElement("Students");
xml_doc.AppendChild(students_node);

//var student_ivanov_node = xml_doc.CreateElement("Student");
//students_node.AppendChild(student_ivanov_node);

//var last_name_node = xml_doc.CreateElement("LastName");
//last_name_node.InnerText = "Иванов";
//student_ivanov_node.AppendChild(last_name_node);

foreach (var student in students)
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

xml_doc.Save("students.xml");

//Console.ReadLine();