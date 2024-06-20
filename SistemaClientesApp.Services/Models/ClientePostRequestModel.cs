using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
namespace SistemaClientesApp.Services.Models
{
    //Modelo de dados para a requisição POST de cadastro de cliente
    public class ClientePostRequestModel
    {
        [RegularExpression("^[A-Za-z'À-Üà-ü0-9\\s]{8,100}$",
        ErrorMessage = "Por favor, informe um nome válio de 8 a 100 caracteres.")]
        //Campo obrigatório
        [Required(ErrorMessage = "Por favor, informe o nome do cliente.")]
        public string? Nome { get; set; }

        //Campo obrigatório
        [Required(ErrorMessage = "Por favor, informe o Cpf do cliente.")]
        //Aceitar 11 caracteres numéricos(expressão)
        [RegularExpression("^[0-9\\s]{11,11}$",
            ErrorMessage = "Por favor, informe um CPF válio com 11 caracteres.")]
        public string? Cpf { get; set; }

        //Campo obrigatório
        [Required(ErrorMessage = "Por favor, informe o telefone do cliente.")]
        //Aceitar 9 caracteres numéricos(expressão)
        [RegularExpression("^[0-9\\s]{9,9}$",
            ErrorMessage = "Por favor, informe um telefone válido com até 9 caracteres.")]
        public string? Telefone { get; set; }

        //Mínimo de caracteres
         [MinLength(8,ErrorMessage ="Informe no mínimo 8 de caractes")]
         //Máximo de caracteres
         [MaxLength(100,ErrorMessage = "Informe no máximo 256 d caractes")]
        public string? Email { get; set; }

        public DateTime? DataNascimento { get; set; }
    }
}
