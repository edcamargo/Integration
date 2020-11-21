using Application.Ui.ConsoleApp.Models;
using Application.Ui.ConsoleApp.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Application.Ui.ConsoleApp
{
    internal class Program
    {
        private static readonly string _archive = @ConfigurationManager.AppSettings["PATH_FILE"].ToString();

        private static void Main(string[] args)
            => Run(new EmployeeService()).GetAwaiter().GetResult();

        public static async Task Run(IEmployeeService _employeeService)
        {
            try
            {
                var employee = ReadArchive();

                foreach (var item in employee)
                {
                    var _response = await _employeeService.PostAsync(item);

                    if (_response != null && _response.IsSuccessStatusCode)
                    {
                        WriteLine("-----------------------------------------------");
                        WriteLine("Employee inserted : " + item.Name);
                        WriteLine("-----------------------------------------------");
                    }
                    else
                        WriteLine("Error insert register.");
                }

                WriteLine("-----------------------------------------------");
                WriteLine("Method Get");
                WriteLine("-----------------------------------------------");

                var _responseGet = _employeeService.GetAsync();

                WriteLine(_responseGet.Result);

                ReadKey();
            }
            catch (Exception ex)
            {
                WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Method Read Archive
        /// </summary>
        /// <returns></returns>
        private static IList<Employee> ReadArchive()
        {
            IList<Employee> employee = new List<Employee>();
            Encoding encoding = Encoding.GetEncoding(new CultureInfo("pt-BR").TextInfo.ANSICodePage);

            using (var streamReader = new StreamReader(_archive, encoding))
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
        /// Example method using C# 7+ Tuple
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