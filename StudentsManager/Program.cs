

using Microsoft.EntityFrameworkCore;
using StudentsManager;
using StudentsManager.Context;


var connection_string = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Students-DB";

var connection_options = new DbContextOptionsBuilder<StudentsDB>()
   .UseSqlServer(connection_string)
   .Options;

using (var db = new StudentsDB(connection_options))
{
    db.Database.EnsureDeleted();  // удаляет БД в случае её наличия
    db.Database.EnsureCreated();    // создаёт БД в случае её отсутствия

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
}


//Console.ReadLine();