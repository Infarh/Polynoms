

using Microsoft.EntityFrameworkCore;

using StudentsManager;
using StudentsManager.Context;


var connection_string = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Students-DB";

var connection_options = new DbContextOptionsBuilder<StudentsDB>()
   .UseSqlServer(connection_string)
   //.LogTo(str => Console.WriteLine(str))
   .Options;

using (var db = new StudentsDB(connection_options))
{
    //db.Database.EnsureDeleted();  // удаляет БД в случае её наличия
    db.Database.EnsureCreated();    // создаёт БД в случае её отсутствия

    //if (db.Groups.Count() == 0)
    if (!db.Groups.Any())
    {
        Console.WriteLine("Создание групп студентов в БД...");

        var groups = new StudentGroup[10];
        var n = 0;

        var rnd = new Random();
        for (var i = 0; i < groups.Length; i++)
        {
            var group = new StudentGroup
            {
                Name = $"Группа #{i + 1}"
            };

            groups[i] = group;

            for (var j = 0; j < 10; j++)
            {
                n++;
                var student = new Student
                {
                    LastName = $"Фамилия-{n}",
                    FirstName = $"Имя-{n}",
                    Patronymic = $"Отчество-{n}",
                    Rating = rnd.NextDouble() * 100,
                };

                group.Students.Add(student);
            }
        }

        db.Groups.AddRange(groups);

        db.SaveChanges();

        Console.WriteLine("Создание групп студентов в БД выполнено успешно");
    }
    else
        Console.WriteLine("В БД есть данные");
}

//Console.ReadLine();
//Console.Clear();

using (var db = new StudentsDB(connection_options))
{
    var best_students = db.Students
       .Where(student => student.Rating > 50)
       .Where(student => student.LastName.EndsWith("5"))
       .ToArray();

    foreach (var student in best_students)
        Console.WriteLine($"[id:{student.Id}] {student.LastName} {student.FirstName} {student.Patronymic} - {student.Rating}");

}

Console.WriteLine();


using (var db = new StudentsDB(connection_options))
{
    var first_top5_students = db.Students
       .OrderByDescending(student => student.Rating)
       .Take(5);

    Console.WriteLine();
    Console.WriteLine("Первая 5-ка лучших студентов");
    foreach (var student in first_top5_students)
        Console.WriteLine($"[id:{student.Id}] {student.LastName} {student.FirstName} {student.Patronymic} - {student.Rating}");

    var first_top5_students_average_rating = first_top5_students.Average(student => student.Rating);
    Console.WriteLine("Средний балл: {0}", first_top5_students_average_rating);

    var second_top5_students = db.Students
       .OrderByDescending(student => student.Rating)
       .Skip(5)
       .Take(5);

    Console.WriteLine();
    Console.WriteLine("Вторая 5-ка лучших студентов");
    foreach (var student in second_top5_students)
        Console.WriteLine($"[id:{student.Id}] {student.LastName} {student.FirstName} {student.Patronymic} - {student.Rating}");

    var second_top5_students_average_rating = second_top5_students.Average(student => student.Rating);
    Console.WriteLine("Средний балл: {0}", second_top5_students_average_rating);

}