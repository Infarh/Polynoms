using System.Text.RegularExpressions;

const string data_file_path = "Data.txt";

/*
 * Спецсимволы синтаксиса регулярного выражения
 * . - любой символ (повторённый 1 раз)
 * [...] - класс символов
 *      [аоеёуияю] - гласная буква кирилического алфавита в нижнем регистре
 *      [А-ЯЁ] - все русские буквы верхнего регистра
 *      [A-Za-z] - любые латинские буквы в любом регистре
 * \w - любая буква и цифра в латинском и русском алфавите
 * \d - любая цифра (аналог [0-9])
 * \W - любой символ не принадлежащий слову (пунктуация, переносы строк, пробелы)
 * \D - любая нецифра
 *
 * Условия повторения
 * * - любое количество раз от 0 и больше
 * + - любое ненулевое количество раз (от 1 и больше)
 * ? - 0, или 1 раз
 * {5} - 5 раз
 * {2,7} - от 2 до 7 раз
 * {5,} - от 5 раз и более
 * {,7} - от 0 до 7 раз (эквивалент {0,7})
 *
 * (...) - группа символов (правил)
 *      (\w{5}[0-5]){5} - ищем любую букву, или цифру, повторёную 5 раз и в конце цифра в диапазоне от 0 до 5. И это должно повторяться 5 раз
 *
 * Пред- и пост-условия
 * (?<=УСЛОВИЕ) - предусловие - устанавливает требование наличия выражения "УСЛОВИЕ" перед искомым текстом
 *      (?<=телефон:)\+\d{1,3}\(\d+\)\d{2,}(-\d{2}){2} - ищет телефонный номер, перед которым стоит текст "телефон:"
 *
 * (?=УСЛОВИЕ) - постусловие - устанавливает требование наличия выражения "УСЛОВИЕ" после искомого текста
 *      \w+(\.\w+)*@\w+(\.\w+)+(?=,) - ищет адреса электронной почты, после которых стоит символ ',' - "запятая"
 */

var file_text = File.ReadAllText(data_file_path);

Console.WriteLine("Содержимое файла:");
Console.WriteLine(file_text);
Console.WriteLine();

Console.WriteLine("Телефонные номера, содержащиеся в файле:");

var phone_number_regex = new Regex(@"\+\d{1,3}\(\d+\)\d{2,}(-\d{2}){2}");

var phone_matches = phone_number_regex.Matches(file_text);

foreach (Match match in phone_matches)
{
    Console.WriteLine("- телефон: {0}", match.Value);
}

Console.WriteLine();
Console.WriteLine("Адреса электронной почты, содержащиеся в файле:");

var email_number_regex = new Regex(@"\w+(\.\w+)*@\w+(\.\w+)+");

var email_matches = email_number_regex.Matches(file_text);

foreach (Match match in email_matches)
{
    Console.WriteLine("- эл.почта: {0}", match.Value);
}

Console.WriteLine();

var test_string1 = "Ivanov";
var test_string2 = "Ivanov@yandex.ru";

if (email_number_regex.IsMatch(test_string1))
{
    Console.WriteLine("Текст {0} является адресом электронной почты", test_string1);
}
else
{
    Console.WriteLine("Текст {0} не является адресом электронной почты", test_string1);
}

if (email_number_regex.IsMatch(test_string2))
{
    Console.WriteLine("Текст {0} является адресом электронной почты", test_string2);
}
else
{
    Console.WriteLine("Текст {0} не является адресом электронной почты", test_string2);
}

var is_correct = Regex.IsMatch(test_string2, @"\w+(\.\w+)*@\w+(\.\w+)+");

Console.WriteLine("{0} is email - {1}", test_string2, is_correct);

Console.ReadLine();

