using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio_GSO_Medicina_Ocupacional_1.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Cpf { get; set; }
        public DateTime DataNascimento { get; set; }

        /// <summary>
        /// Representa o construtor do Cliente (O id não é obrigatorio pois ele é auto_increment chave primaria)
        /// </summary>
        public Cliente(string nome, int cpf, DateTime dataNascimento)
        {
            Nome = nome;
            Cpf = cpf;
            DataNascimento = dataNascimento;
        }
    }
}