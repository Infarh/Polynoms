﻿using StudentsManager;

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

Console.ReadLine();