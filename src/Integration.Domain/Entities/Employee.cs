using FluentValidation;
using FluentValidation.Results;

namespace Integration.Domain.Entities
{
    public class Employee : Entity
    {
        public Employee(string name, double salary, string email)
        {
            Name = name;
            Salary = salary;
            Email = email;
        }

        public string Name { get; private set; }
        public double Salary { get; private set; }
        public string Email { get; private set; }

        public bool UpdateSalary(double valorPercent)
        {
            Salary *= valorPercent;
            return true;
        }

        public ValidationResult EhValido()
        {
            return new EmployeeValidation().Validate(this);
        }
    }

    internal class EmployeeValidation : AbstractValidator<Employee>
    {
        public static string NameErroMsg => "Nome inválido.";
        public static string SalaryErroMsg => "Salario inválido.";
        public static string EmailErroMsg => "E-mail inválido";

        public EmployeeValidation()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage(NameErroMsg);

            RuleFor(c => c.Salary)
                .GreaterThan(0)
            .WithMessage(SalaryErroMsg);

            RuleFor(c => c.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage(EmailErroMsg);
        }
    }
}