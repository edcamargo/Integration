using Integration.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Ui.Api.Dtos
{
    //[FluentValidation.Attributes.Validator(typeof(EmployeeValidator))]
    public class EmployeeDto
    {
        //[Required(ErrorMessage = "O campo {0} é obrigatório")]
        //[StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {100} caracteres", MinimumLength = 2)]
        public string Name { get; private set; }

        //[Required(ErrorMessage = "O campo {1} é obrigatório")]
        public string Salary { get; private set; }

        //[Required(ErrorMessage = "O campo {2} é obrigatório")]
        public string Email { get; private set; }
    }
}
