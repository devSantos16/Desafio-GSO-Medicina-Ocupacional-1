using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Desafio_GSO_Medicina_Ocupacional_1.Models;
using Microsoft.EntityFrameworkCore;

namespace Desafio_GSO_Medicina_Ocupacional_1.Context
{
    public class ClienteContext : DbContext
    {
        public ClienteContext(DbContextOptions<ClienteContext> options) : base(options)
        {
        }
        public DbSet<Cliente> Clientes { get; set; }
    }
}