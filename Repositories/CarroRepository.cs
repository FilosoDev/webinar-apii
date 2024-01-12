using Oficina.WebApi.Contexts;
using Oficina.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Oficina.WebApi.Repositories
{
    public class CarroRepository
    {
        private readonly OficinaContext _context;
        public CarroRepository(OficinaContext context)
        {
            _context = context;
        }
        public List<Carro> Listar()
        {
            return _context.Carros.ToList();
        }

        public void Cadastrar(Carro carro)
        {
            _context.Carros.Add(carro);
            _context.SaveChanges();
        }

        public void Atualizar(int id, Carro carro)
        {
            Carro carroBuscado = _context.Carros.Find(id);
            if (carroBuscado != null)
            {
                carroBuscado.Modelo = carro.Modelo;
                carroBuscado.Marca = carro.Marca;
                carroBuscado.Ano = carro.Ano;
                carroBuscado.Placa = carro.Placa;
                carroBuscado.Cor = carro.Cor;
            }
            _context.Carros.Update(carroBuscado);
            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            Carro carroBuscado = _context.Carros.Find(id);
            _context.Carros.Remove(carroBuscado);
            _context.SaveChanges();
        }

        public Carro BuscarporId(int id)
        {
            return _context.Carros.Find(id);
        }

    }
}
