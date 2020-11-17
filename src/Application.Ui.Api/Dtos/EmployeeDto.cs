using System.ComponentModel.DataAnnotations;

namespace Application.Ui.Api.Dtos
{
    public class EmployeeDto
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        //[StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {100} caracteres", MinimumLength = 2)]
        public string Name { get; private set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Salary { get; private set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Email { get; private set; }
    }
}
