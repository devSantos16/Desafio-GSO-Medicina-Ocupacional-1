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
        
        // Falta criar summario 
        public string ValidarNome(string nome, string nomeValidacao)
        {
            if (nomeValidacao == null)
            {
                return nome;
            }

            return nomeValidacao;
        }

        // Falta criar summario
        public string ValidarCPF(string cpf, string cpfValidacao)
        {
            if (cpfValidacao == null)
            {
                return cpf;
            }

            return ValidarCPF(cpfValidacao);
        }
        // Falta criar summario
        public dynamic ValidarData(DateTime data, string dataValidacao)
        {
            if (dataValidacao == null)
            {
                return data;
            }

            return ValidarData(dataValidacao);
        }

        // Falta fazer sumario e invalidar letras e caracteres
        public string ValidarCPF(string cpf)
        {
            if (cpf.Length != 11)
                throw new Exception("Erro, o Cpf deve ter 11 digitos !");
            return cpf;
        }
        // Falta criar summario
        public DateTime ValidarData(string data)
        {
            string dataFormatada = data.Replace("%", "-").Replace("2F", "");
            return Convert.ToDateTime(dataFormatada);
        }

    }
}