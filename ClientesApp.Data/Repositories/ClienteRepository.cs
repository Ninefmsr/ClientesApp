using ClientesApp.Data.Contexts;
using ClientesApp.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesApp.Data.Repositories
{
    /// <summary>
    ///  Classe repositório de dados para cliente
    ///  1º public class ClienteRepository
    /// </summary>
    public class ClienteRepository
    {
        //private Guid? idCliente;

        //2ºMétodo p/ inserir cliente no banco de dados
        //3ºCtrl + ponto em Cliente p/ colocar o = using ClientesApp.Data.Entities;
        public void Inserir(Cliente cliente) 
        { 
            //4º P/ acessar DataContext
            using (var dataContext = new DataContext()) 
            {
                dataContext.Add(cliente);//5ºAtualizando banco de dados
                dataContext.SaveChanges(); //6ºexecutando operação
            }
        }

        /// <summary>
        /// Método p/ atualizar cliente no banco de dados 
        /// 7º  public void Alterar(Cliente cliente) 
        /// </summary>
        public void Alterar(Cliente cliente) 
        {
            //8º P/ acessar DataContext
            using (var dataContext = new DataContext())
            {
                dataContext.Update(cliente); //9ºatualizando no banco de dados
                dataContext.SaveChanges(); //10ºExecutando operação
            }
        }

        /// <summary>
        /// Método p/ excluir cliente no banco de dados 
        /// 11º  public void Excluir (Cliente cliente) 
        /// </summary>
        public void Excluir(Cliente cliente) 
        {
            //12ºP/ acessar DataContext
            using (var dataContext = new DataContext()) 
            {
                dataContext.Remove(cliente);//13ºexcluir no banco de dados
                dataContext.SaveChanges(); //14ºExecutando operação
            }
            
        }
        /// <summary>
        /// Método p/consultar todos os produtos cadastrados
        /// 
        /// 15ºpublic List<Cliente> ObeterTodos()
        /// //Obs.:Método ObterTodos vai ficar sublinhado de vermelho,
        /// sairá o sublinhado quando  terminar de digitar o código
        /// </summary>
        public List<Cliente> ObterTodos()
        { 
            //16ºp/ acessar DataContext
            
            using (var dataContext = new DataContext())
            {
               return dataContext
               .Set<Cliente>()
               .OrderBy(c => c.Nome)
               .ToList();
            }
        }

        /// <summary>
        /// Método p/ consultar 1 cliente através do ID
        /// //17º
        /// </summary>
        public Cliente? ObterPorId(Guid? idCliente) 
        {
            using (var dataContext = new DataContext())
            {
                return dataContext
                    .Set<Cliente>()//consulta tabela cliente]
                    .Where(c => c.IdCliente == idCliente)
                    .FirstOrDefault();
            }
        }


    }
}
