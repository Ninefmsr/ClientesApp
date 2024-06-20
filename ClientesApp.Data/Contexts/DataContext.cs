using ClientesApp.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientesApp.Data.Contexts
{
    /// <summary>
    /// Classe p/ conexão c/banco de dados através do EntityFramework
    ///1ºModifico a visibilidade p/ = public
    ///2º Coloco herança para = :DbContext
    ///3º using Microsoft.EntityFrameworkCore;= Ctrl + ponto em DbContex
    /// </summary>
    public class DataContext : DbContext
    {
        /// <summary>
        ///Método p/ incluir string conexão do banco de dados:
        ///4º Digito: protected override void
        ///5º Seleciono: OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        /// </summary>
        protected override void OnConfiguring
            (DbContextOptionsBuilder optionsBuilder)
        {
            /// <summary>
            ///6ºApago:  base.OnConfiguring(optionsBuilder);
            ///7ºNo lugar digito options + tab para completar = optionsBuilder.UseSqlServer() coloco no final ponto e vírgula
            ///8ºColoco aspas duplas entre parenteses = ("")
            ///8º Vou no banco e copio a connection string
            ///9º Dentro de Aspas duplas e entre parenteses ("") Colo connection string até o  =True;
            /// </summary>
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BDSistemaClientes;Integrated Security=True;");

        }
        /// <summary>
        /// Método para adicionar as classes de mapeamento
        /// 10º Digito: protected override void
        /// 11º Escolho: OnModelCreating(ModelBuilder modelBuilder)
        /// 12º Apago: base.OnModelCreating(modelBuilder);
        /// 13ºNo lugar digito: modelBuilder.ApplyConfiguration(new ClasseDeMapeamento());
        /// Ex.:   modelBuilder.ApplyConfiguration(new ClienteMap());
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteMap());
        }


    }
}
