using Oficina.WebApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;

namespace Oficina.WebApi.Contexts
{
    public class OficinaContext : DbContext
    {
        public OficinaContext()
        {
        }
        public OficinaContext(DbContextOptions<OficinaContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Essa string de conexão foi depende da SUA máquina.
                optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;"
                              + "Database=OficinaCarros;Trusted_Connection=True;");

                // Exemplo 1 de string de conexão:
                // User ID=sa;Password=admin;Server=localhost;Database=OficinaApi;-
                // + Trusted_Connection=False;

                // Exemplo 2 de string de conexão:
                // Server=localhost\\SQLEXPRESS;Database=OficinaApi;Trusted_Connection=True;
            }
        }
        public DbSet<Carro> Carros { get; set; }
    }
}

