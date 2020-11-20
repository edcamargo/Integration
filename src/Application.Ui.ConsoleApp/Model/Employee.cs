﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Ui.ConsoleApp.Model
{
    public class Employee
    {
        public Employee(string id, string name, string salary, string email)
        {
            Id = id;
            Name = name;
            Salary = salary;
            Email = email;
        }

        public string Id { get; private set; }
        public string Name { get; private set; }
        public string Salary { get; private set; }
        public string Email { get; private set; }
    }
}
