﻿using Microsoft.EntityFrameworkCore;
using projeto_final_bloco_02.Data;
using projeto_final_bloco_02.Model;

namespace projeto_final_bloco_02.Service.Implements
{
    public class CategoriaService : ICategoriaService
    {
        private readonly AppDbContext _context;

        public CategoriaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Categoria?> Create(Categoria Categoria)
        {
            await _context.Categorias.AddAsync(Categoria);
            await _context.SaveChangesAsync();

            return Categoria;
        }

        public async Task Delete(Categoria Categoria)
        {
            _context.Remove(Categoria);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Categoria>> GetAll()
        {
            return await _context.Categorias
                .Include(t => t.Produto)
                .ToListAsync();
        }

        public async Task<Categoria?> GetById(long id)
        {
            try
            {

                var Categoria = await _context.Categorias
                    .Include(t => t.Produto)
                    .FirstAsync(i => i.Id == id);

                return Categoria;

            }
            catch
            {
                return null;
            }
        }

        public async Task<IEnumerable<Categoria>> GetByTipo(string tipo)
        {
            var Categoria = await _context.Categorias
                .Include(t => t.Produto)
                .Where(p => p.Tipo.Contains(tipo))
                .ToListAsync();

            return Categoria;
        }

        public async Task<Categoria?> Update(Categoria Categoria)
            {
                var CategoriaUpdate = await _context.Categorias.FindAsync(Categoria.Id);

                if (CategoriaUpdate is null)
                    return null;

                _context.Entry(CategoriaUpdate).State = EntityState.Detached;
                _context.Entry(Categoria).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return Categoria;
            }
        }
    }
