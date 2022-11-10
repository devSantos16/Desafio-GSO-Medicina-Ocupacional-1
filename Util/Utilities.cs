using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio_GSO_Medicina_Ocupacional_1.Models;

namespace Desafio_GSO_Medicina_Ocupacional_1.Util
{
    public class Utilities
    {
        public Utilities()
        {
        }

        /// <summary>
        /// Representa a Validação do nome, este metodo serve pra verificar se o nome da edição é null, se não
        /// for, o valor já armazenado no banco de dados não é alterado 
        /// </summary>
        /// <param name = "nome">Representa o Nome do Cliente para poder achar no banco de dados</param>
        /// <param name = "nomeValidacao">Representa o Nome do Cliente inserido na edição da Api</param>
        public string ValidarNome(string nome, string nomeValidacao)
        {
            if (nomeValidacao == null)
                return nome;

            return nomeValidacao;
        }

        /// <summary>
        /// Representa a Validação do nome, este metodo serve pra verificar se o cpf da edição é null, se não
        /// for, o valor já armazenado no banco de dados não é alterado 
        /// </summary>
        /// <param name = "cpf">Representa o Cpf do Cliente para poder achar no banco de dados</param>
        /// <param name = "cpfValidacao">Representa o Cpf do Cliente inserido na edição da Api</param>
        public string ValidarCPF(string cpf, string cpfValidacao)
        {
            if (cpfValidacao == null)
            {
                return cpf;
            }

            return ValidarCPF(cpfValidacao);
        }

        /// <summary>
        /// Representa a Validação da Data, este metodo serve pra verificar se a Data da edição é null, se não
        /// for, o valor já armazenado no banco de dados não é alterado 
        /// </summary>
        /// <param name = "data">Representa a Data do Cliente para poder achar no banco de dados</param>
        /// <param name = "dataValidacao">Representa a Data do Cliente inserido na edição da Api</param>
        public dynamic ValidarData(DateTime data, string dataValidacao)
        {
            if (dataValidacao == null)
            {
                return data;
            }

            return ValidarData(dataValidacao);
        }

        /// <summary>
        /// Representa a Validação do CPF, verifica se cpf possui um numero diferente de 11 caracteres e se contem letras, simbolos e pontuações
        /// </summary>
        /// <param name = "cpf">Representa o Cpf para validação </param>
        public string ValidarCPF(string cpf)
        {
            if (cpf.Where(c => char.IsLetter(c)).Count() > 0 ||
            cpf.Where(c => char.IsSymbol(c)).Count() > 0 ||
            cpf.Where(c => char.IsPunctuation(c)).Count() > 0)
                throw new Exception("Erro, o Cpf não pode conter Pontuacao, Letras ou Simbolos !");

            if (cpf.Length != 11)
                throw new Exception("Erro, o Cpf deve ter 11 digitos !");
            return cpf;
        }
        
        /// <summary>
        /// Representa a Validação da Data, formata a Data inserida na Api
        /// </summary>
        /// <param name = "data">Representa a Data para validação </param>
        public DateTime ValidarData(string data)
        {
            string dataFormatada = data.Replace("%", "-").Replace("2F", "");
            return Convert.ToDateTime(dataFormatada);
        }

    }
}