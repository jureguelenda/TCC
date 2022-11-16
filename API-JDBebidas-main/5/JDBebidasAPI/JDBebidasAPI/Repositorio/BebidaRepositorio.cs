using JDBebidasAPI.Model;
using JDBEBIDASAPI.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace JDBEBIDASAPI.Repositorio
{
    public class BebidaRepositorio : IBebidaRepositorio
    {
        public readonly BebidaMap _context;

        public BebidaRepositorio(BebidaMap context)
        {
            _context = context;
        }
        public async Task<Bebida> Create(Bebida bebida)
        {
            _context.Bebidas.Add(bebida);
            await _context.SaveChangesAsync();

            return bebida;
        }

        public Task<Bebida> Create(Bebida bebida)
        {
            throw new System.NotImplementedException();
        }

        public async Task Delete(int Id)
        {
            var bebidaToDelete = await _context.Bebidas.FindAsync(Id);
            _context.Bebidas.Remove(bebidaToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Bebida>> Get()
        {
            return await _context.Bebidas.ToListAsync();
        }

        public async Task<Bebida> Get(int Id)
        {
            return await _context.Bebidas.FindAsync(Id);
        }

        public async Task Update(Bebida bebida)
        {
            _context.Entry(bebida).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public Task Update(Bebida bebida)
        {
            throw new System.NotImplementedException();
        }

        Task<IEnumerable<Bebida>> IBebidaRepositorio.Get()
        {
            throw new System.NotImplementedException();
        }

        Task<Bebida> IBebidaRepositorio.Get(int Id)
        {
            throw new System.NotImplementedException();
        }
    }
}
