using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio_GSO_Medicina_Ocupacional_1.Context;
using Desafio_GSO_Medicina_Ocupacional_1.Models;
using Microsoft.AspNetCore.Mvc;
using Desafio_GSO_Medicina_Ocupacional_1.Util;
namespace Desafio_GSO_Medicina_Ocupacional_1.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ClienteContext context;

        public ClienteController(ClienteContext context)
        {
            this.context = context;

        }

        /// <summary>
        /// Representa um registro de cliente
        /// </summary>
        /// <param name = "nome">Representa o nome do Cliente - É obrigatorio</param>
        /// <param name = "cpf">Representa o cpf do Cliente - É obrigatorio</param>
        /// <param name = "data">Representa a data do Cliente - É obrigatorio</param>
        [HttpPost("RegistrarCliente {nome} {cpf} {data}")]
        public ActionResult RegistrarCliente(string nome, string cpf, DateTime data)
        {

            // Tem que arrumar a data -- Validação do CPF do registro
            Cliente c = new Cliente(nome, cpf, data);

            this.context.Clientes.Add(c);
            this.context.SaveChanges();

            Console.WriteLine(cpf);

            return Ok($"Cliente cadastrado com sucesso | Dados: {c.DataNascimento}");
        }

        /// <summary>
        /// Representa a alteração de dados de um cliente
        /// </summary>
        /// <param name = "id">Representa o ID do Cliente para poder achar no banco de dados - É obrigatorio</param>
        /// <param name = "nome">Representa o nome do Cliente - Não é obrigatorio</param>
        /// <param name = "cpf">Representa o cpf do Cliente - Não é obrigatorio</param>
        /// <param name = "data">Representa a data do Cliente - Não é obrigatorio</param>
        [HttpPut("EditarCliente {id}")]
        public ActionResult EditarCliente(int id, string nome, string cpf, DateTime data)
        {
            var cliente = this.context.Clientes.Find(id);
            Utilities Util = new Utilities();

            cliente.Nome = Util.ValidarNome(cliente.Nome, nome);
            cliente.Cpf = Util.ValidarCPF(cliente.Cpf, cpf);
            cliente.DataNascimento = data;

            this.context.Clientes.Update(cliente);
            this.context.SaveChanges();

            return Ok("Cliente editado com sucesso");
        }

        /// <summary>
        /// Representa a exclusão do cliente
        /// </summary>
        /// <param name = "id">Representa o ID do Cliente para poder achar no banco de dados - É obrigatorio</param>
        [HttpDelete("ExcluirCliente {id}")]
        public ActionResult ExcluirCliente(int id)
        {
            var cliente = this.context.Clientes.Find(id);
            string nome = cliente.Nome;

            this.context.Clientes.Remove(cliente);
            this.context.SaveChanges();

            return Ok($"Cliente {nome} foi removido com sucesso!");
        }

        /// <summary>
        /// Representa a a listagem de todos os clientes através de uma lista dinamica para formatação dos dados
        /// </summary>
        [HttpGet("ListarCliente")]
        public ActionResult ListarCliente()
        {
            List<dynamic> c = new List<dynamic>();

            foreach (var item in this.context.Clientes.ToList())
            {
                string dataFormatada = item.DataNascimento.ToString("dd/MM/yyyy");
                c.Add(new { item.Id, item.Nome, item.Cpf, dataFormatada });
            }
            return Ok(c.ToList());
        }
    }
}