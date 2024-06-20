using ClientesApp.Data.Entities;
using ClientesApp.Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaClientesApp.Services.Models;
using System.ComponentModel.DataAnnotations;

namespace SistemaClientesApp.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {

        /// <summary>
        /// MÉTODO P/ CRIAR [POST]:
        /// -Modificador de visibilidade: public
        /// -Declaração de método: IActionResult
        /// -Ação: Post()
        /// </summary>
        [HttpPost]
        public IActionResult Post(ClientePostRequestModel model)
        {
            try
            {
                //Criando objeto Cliente(entidade)
                var cliente = new Cliente()
                {
                    IdCliente = Guid.NewGuid(),
                    Nome = model.Nome,
                    Cpf = model.Cpf,
                    Telefone = model.Telefone,
                    Email = model.Email,
                    DataNascimento = (DateTime)model.DataNascimento
                };
                //gravar produto no bnco de dados
                var clienteRepository = new ClienteRepository();
                clienteRepository.Inserir(cliente);

                //retornar sucesso HTTP 201 (CREATED)
                return StatusCode(201, new
                {
                    Message = "Cliente cadastrado com sucesso",
                    cliente.IdCliente
                });
            }
            catch (Exception e)
            {
                //Erro do servidor (INTERNAL SERVER ERROR) HTTP 500
                return StatusCode(500, new { e.Message });
            }
        }
        /// <summary>
        /// MÉTODO P/ ALTERAR [PUT]:
        /// -Modificador de visibilidade: public
        /// -Declaração de método: IActionResult
        /// -Ação: Put()
        /// </summary>
        [HttpPut]
        //ClientePostRequestModel model
        public IActionResult Put(ClientePutRequestModel model)
        {
            try  //Programo  caminho feliz
            {
                //pesquisar cliente no banco de dados através do ID (IDCliente)
                var clienteRepository = new ClienteRepository();
                var cliente = clienteRepository.ObterPorId(model.IdCliente.Value);

                if (cliente == null)  //verificar se cliente não foi encontrado
                    return StatusCode(400, new { Message = "Cliente não encontrado. Verifique o ID informado." });

                //alterar dados do cliente
                cliente.Nome = model.Nome;
                cliente.Cpf = model.Cpf;
                cliente.Telefone = model.Telefone;
                cliente.Email = model.Email;
                cliente.DataNascimento = (DateTime)model.DataNascimento;

                //atualizar no banco de dados
                clienteRepository.Alterar(cliente);

                //retornar sucesso HTTP 200 (OK)
                return StatusCode(200, new
                {
                    Message = "Cliente atualizado com sucesso",
                    cliente.IdCliente
                });
            }
            catch (Exception e) //Programo Erro ( não entrou no caminho feliz)
            {
                return StatusCode(500, new { e.Message }); //Erro do servidor (INTERNAL SERVER ERROR) HTTP 500
            }
        }

        /// <summary>
        /// MÉTODO P/ EXCLUIR [DELETE]:
        /// -Modificador de visibilidade: public
        /// -Declaração de método: IActionResult
        /// -Ação: Delete()
        /// </summary>

        [HttpDelete("{idCliente}")]
        public IActionResult Delete(Guid idCliente) 
        {
            try 
            {
                //pesquisar cliente no banco de dados através do id
                var clienteRepository = new ClienteRepository();
                var cliente = clienteRepository.ObterPorId(idCliente);

                //verificar se o produto não foi encontrado
                if (cliente == null)
                    return StatusCode(400, new { Message = "Cliente não encontrado.Verifique  o Id informado." });
                
                //Excluir cliente
                clienteRepository.Excluir(cliente);

                //retornar sucesso HTTP 200 (OK)
                return StatusCode(200, new
                {
                    Message = "Cliente excluído com sucesso",
                    cliente.IdCliente
                });
            }
            catch(Exception e)
            { 
               // Erro do servidor (INTERNAL SERVER ERROR ) HTTP 500
               return StatusCode(500, new {e.Message});
            }
        }






        /// <summary>
        /// MÉTODO P/ CONSULTAR TODOS [GET]:
        /// -Modificador de visibilidade: public
        /// -Declaração de método: IActionResult
        /// -Ação: Get()
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(List<ClientesGetResponseModel>),200)]
        public IActionResult GetAll() 
        {
            try
            {
                //consultando cliente no banco de dados
                var clienteRepository = new ClienteRepository();
                var cliente = clienteRepository.ObterTodos();
               

                //criando lista  de classe modelo de dados
                var response = new List<ClientesGetResponseModel>();

                //percorrer todas categorias obtidas no banco
                foreach (var item in cliente)
                {
                    response.Add(new ClientesGetResponseModel
                    {
                        IdCliente = item.IdCliente,
                        Nome = item.Nome,
                        Cpf = item.Cpf,
                        Telefone = item.Telefone,
                        DataNascimento = item.DataNascimento,
                        Idade = item.CalcularIdade(),
                    });
                    
                }
                //HTTP 200 (OK)
                return StatusCode(200, response);

            }
            catch (Exception e)
            {
                return StatusCode(500, new { e.Message });
            }
        }

        [HttpGet("{idCliente}")]
        public IActionResult GetById(Guid idCliente)
        {
            try 
            {
                //pesquisar cliente por Id
                //Pesquisar no banco através do id
                var clienteRepository = new ClienteRepository();
                var cliente = clienteRepository.ObterPorId(idCliente);

                //verificar se nenhum produto foi encontrado
                if (cliente == null)
                    return NoContent(); //HTTP 204 (Não encontrado)

                //retornar dados do produto]
                var model = new ClientesGetResponseModel
                {
                    IdCliente = cliente.IdCliente,
                    Nome = cliente.Nome,
                    Cpf = cliente.Cpf,
                    Telefone = cliente.Telefone,
                    DataNascimento = cliente.DataNascimento,
                    Idade = cliente.CalcularIdade(),
                };

                return StatusCode(200, model);


            }
            catch(Exception e)
            {
                //INTERNAL SERVER ERROR -> HTTP 500
                return StatusCode(500, new {e.Message});
            }
        }
    }
}
