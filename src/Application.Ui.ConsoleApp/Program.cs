using Application.Ui.ConsoleApp.Model;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using static System.Console;

namespace Application.Ui.ConsoleApp
{
    class Program
    {
        private static string _Archive = @"C:\Projetos\Integration\src\Application.Ui.ConsoleApp\Archive\Employee.csv";

        static void Main(string[] args)
        {
            var employee = ReadArchive();

            foreach (var item in employee)
            {
                WriteLine(item.Id + " - " + item.Name);
            }

            ReadKey();
        }

        private static IList<Employee> ReadArchive()
        {
            IList<Employee> employee = new List<Employee>();
            Encoding encoding = Encoding.GetEncoding(new CultureInfo("pt-BR").TextInfo.ANSICodePage);

            using (var streamReader = new StreamReader(_Archive, encoding))
            {
                streamReader.ReadLine();

                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    var (id, name, salary, email) = ReadLines(line);

                    employee.Add(new Employee(id, name, salary, email));
                }
            }

            return employee;
        }

        /// <summary>
        /// Método exemplo com uso de Tupla C# 7+
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private static (string id, string name, string salary, string email) ReadLines(string line)
        {
            string[] attribute = line.Split(',');

            var id = attribute[0];
            var name = attribute[1];
            var salary = attribute[2];
            var email = attribute[3];

            return (id, name, salary, email);
        }
    }
}
