using ClientesApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ClientesApp.Data.Mappings
{
    /// <summary>
    ///1º-ClienteMap : IEntityTypeConfiguration<Cliente> = Acontecendo uma herança 
    /// a Classe ClienteMap está recebendo tudo da classe IEntityTypeConfiguration<Cliente>
    /// 2ºusing Microsoft.EntityFrameworkCore; =Adiciono com  ctrl + ponto em IEntityTypeConfiguration<Cliente>
    /// 3ºusing ClientesApp.Data.Entities; =Adiciono com  ctrl + ponto em IEntityTypeConfiguration<Cliente>
    /// 
    /// 4ºImplementar interface = Adiciono com  ctrl + ponto em IEntityTypeConfiguration<Cliente>
    /// </summary>
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            //5ºNome da tabela
            builder.ToTable("CLIENTE");

            //6º Campo chave primária
            builder.HasKey(c => c.IdCliente);

            //7º Mapeamento do campo 'Idcliente'
            builder.Property(c => c.IdCliente)
            .HasColumnName("IDCLIENTE");

            //8ºMapeamento do campo 'Nome'
            builder.Property(p => p.Nome)
                .HasColumnName("NOME") // NOME DA COLUNA
                .HasMaxLength(100)//QUANTIDADE MAXIMA DE CARACTERES
                .IsRequired();// OBRIGATÓRIO

            //9ºMapeamento do campo 'Cpf'
            builder.Property(p => p.Cpf)
                .HasColumnName("CPF")
                .HasMaxLength(11)
                .IsRequired();

            //10ºMapeamento do campo 'Telefone'
            builder.Property(p => p.Telefone)
                .HasColumnName("TELEFONE")
                .HasMaxLength(9)
                .IsRequired();

            //11ºMapeamento do campo 'Email'
            builder.Property(p => p.Email)
                .HasColumnName("EMAIL") // NOME DA COLUNA
                .HasMaxLength(256)//QUANTIDADE MAXIMA DE CARACTERES
                .IsRequired();// OBRIGATÓRIO

            //12ºMapeamento do campo 'Data de nascimento'
            builder.Property(p => p.DataNascimento)
                .HasColumnName("DATA DE NASCIMENTO") // NOME DA COLUNA
                .HasMaxLength(256)//QUANTIDADE MAXIMA DE CARACTERES
                .IsRequired();// OBRIGATÓRIO



        }
    }
}
