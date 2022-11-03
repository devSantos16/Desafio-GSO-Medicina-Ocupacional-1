using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio_GSO_Medicina_Ocupacional_1.Context;
using Desafio_GSO_Medicina_Ocupacional_1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Desafio_GSO_Medicina_Ocupacional_1.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ClienteContext context;

        public ClienteController(ClienteContext context)
        {
            this.context = context;
        }

        [HttpPost("RegistrarCliente")]
        public ActionResult RegistrarCliente(string nome, int cpf, DateTime data)
        {
            // Formatar a data padrão
            string dataFormatada = data.ToString("yyyy/dd/MM");
            Cliente c = new Cliente(nome, cpf, Convert.ToDateTime(dataFormatada));

            this.context.Clientes.Add(c);
            this.context.SaveChanges();

            return Ok("Cliente cadastrado com sucesso");
        }

        [HttpPost("EditarCliente")]
        public ActionResult EditarCliente(int id, string nome, int cpf, DateTime data)
        {
            var cliente = this.context.Clientes.Find(id);

            cliente.Nome = nome;
            cliente.Cpf = cpf;
            cliente.DataNascimento = data;

            this.context.Clientes.Update(cliente);
            this.context.SaveChanges();

            return Ok("Cliente editado com sucesso");
        }

        [HttpPost("ExcluirCliente")]
        public ActionResult ExcluirCliente(int id)
        {
            var cliente = this.context.Clientes.Find(id);
            string nome = cliente.Nome;

            this.context.Clientes.Remove(cliente);
            this.context.SaveChanges();

            return Ok($"Cliente {nome} foi removido com sucesso!");
        }

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