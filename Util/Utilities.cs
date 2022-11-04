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
            if (nomeValidacao == String.Empty)
            {
                return nome;
            }
            return nomeValidacao;
        }

        // Falta sumario
        public string ValidarCPF(string cpf, string cpfValidacao)
        {
            if (cpfValidacao == string.Empty)
            {
                Console.WriteLine("Caiu aqui na propriedade");
                ValidarCPF(cpf);
                return cpf;
            }
            ValidarCPF(cpfValidacao);
            return cpfValidacao;
        }

        // Falta fazer sumario e invalidar letras e caracteres
        public void ValidarCPF(string cpf)
        {
            if (cpf.Length != 11)
            {
                throw new Exception("Erro, o Cpf deve ter 11 digitos !");
            }
            return;
        }
    }
}