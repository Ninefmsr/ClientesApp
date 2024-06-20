namespace SistemaClientesApp.Services.Models
{
    //Modelo de dados para consulta lista  de categorias
    public class ClientesGetResponseModel
    {
        public Guid? IdCliente {  get; set; }
        public string? Nome { get; set; }
        public string? Cpf { get; set; }
        public string? Telefone {  get; set; }
        //public string? Email { get; set; }
        public DateTime? DataNascimento { get; set; }
        public int? Idade { get; set; }

        

       


    }
}
