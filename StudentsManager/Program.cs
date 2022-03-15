

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
    db.Database.EnsureDeleted();  // удаляет БД в случае её наличия
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
    if (!db.Groups.Any(group => group.Name == "Best group"))
    {
        var group = new StudentGroup
        {
            Name = "Best group"
        };

        var ivanov = new Student
        {
            LastName = "Иванов",
            FirstName = "Иван",
            Patronymic = "Иванович",
            Rating = 146,
            Group = group,
        };

        var petrov = new Student
        {
            LastName = "Петров",
            FirstName = "Пётр",
            Patronymic = "Петрович",
            Rating = 132,
            Group = group,
        };

        var sidorov = new Student
        {
            LastName = "Сидоров",
            FirstName = "Сидор",
            Patronymic = "Сидорович",
            Rating = 200,
            Group = group,
        };

        db.Students.AddRange(ivanov, petrov, sidorov);

        db.SaveChanges();
    }
}

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

Console.WriteLine();
Console.Clear();

using (var db = new StudentsDB(connection_options))
{
    var best_groups = db.Groups
       .Include(group => group.Students) // получить данные также из таблицы Students - формирует запрос JOIN
       .OrderByDescending(group => group.Students.Average(student => student.Rating))
       .Take(3);

    foreach (var group in best_groups)
    {
        Console.WriteLine("Группа [id:{0}] {1} : {2}",
            group.Id, group.Name, group.Students.Average(s => s.Rating));

        foreach (var student in group.Students.OrderByDescending(s => s.Rating).Take(3))
            Console.WriteLine($"    [id:{student.Id}] {student.LastName} {student.FirstName} {student.Patronymic} - {student.Rating}");
    }
}

Console.WriteLine("Работа программы завершена. Готов к очистке данных.");
Console.ReadLine();

using (var db = new StudentsDB(connection_options))
{
    //var group = db.Groups.First(group => group.Name == "Best group");            // генерирует ошибку если группа не найдена
    //var group = db.Groups.FirstOrDefault(group => group.Name == "Best group");   // если не найдено,то возвращает null
    var group = db.Groups
       .Include(g => g.Students)
       .Single(g => g.Name == "Best group");           // Если не найдено, то ошибка, а также если в БД более одной такой группы
    //var group = db.Groups.SingleOrDefault(group => group.Name == "Best group");    // если не найдено, то null, а также если в БД более одной такой группы, то это ошибка   

    foreach (var student in group.Students)
        student.Group = null;

    db.Groups.Remove(group); // Удаление объекта локально в памяти программы

    db.SaveChanges();   // передача изменений в БД
}

Console.WriteLine("Очистка данных выполнена");