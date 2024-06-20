using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesApp.Data.Entities
{
    public class Cliente
    {
        #region
        public Guid? IdCliente { get; set; }
        public string? Nome { get; set; }
        public string? Cpf { get; set;}
        public string? Telefone { get; set;}
        public string? Email {  get; set;}
        public DateTime DataNascimento { get; set; }
        #endregion

        //TODO MÉTODO P/CALCULAR A IDADE 

        // Método para calcular a idade do cliente
        public int CalcularIdade()
        {
            DateTime dataAtual = DateTime.Today;
            int idade = dataAtual.Year - DataNascimento.Year;

            // Verifica se já fez aniversário neste ano
            if (DataNascimento.Date > dataAtual.AddYears(-idade))
            {
                idade--;
            }

            return idade;
        }
    }
}

