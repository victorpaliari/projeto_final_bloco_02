using Microsoft.EntityFrameworkCore;
using projeto_final_bloco_02.Data;
using projeto_final_bloco_02.Model;
using projeto_final_bloco_02.Service;

namespace lojadegames.Service.Implements
{
    public class ProdutoService : IProdutoService
    {

        private readonly AppDbContext _context;

        public ProdutoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Produto>> GetAll()
        {
            return await _context.Produtos
               // .Include(p => p.Categoria)
                .ToListAsync();
        }
        public async Task<Produto?> GetById(long id)
        {

            try
            {
                
                var Produto = await _context.Produtos
                  //  .Include(p => p.Categoria)
                    .FirstAsync(i => i.Id == id);
                return Produto;
            }
            catch
            {
                return null;
            }

        }
            public async Task<Produto?> Create(Produto Produto)
            {

                await _context.Produtos.AddAsync(Produto);
                await _context.SaveChangesAsync();

                return Produto;
            }

            public async Task<Produto?> Update(Produto produto)
            {
                var ProdutoUpdate = await _context.Produtos.FindAsync(produto.Id);

                if (ProdutoUpdate is null)
                    return null;

                _context.Entry(ProdutoUpdate).State = EntityState.Detached;
                _context.Entry(produto).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return produto;
            }


        public async Task Delete(Produto Produto)
        {
            _context.Remove(Produto);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Produto>> GetByNome(string nome)
        {
            var Produto = await _context.Produtos
                               // .Include(p => p.Categoria)
                                .Where(p => p.Nome.Contains(nome))
                                .ToListAsync();

            return Produto;
        }

        public async Task<IEnumerable<Produto>> GetByPreco(decimal numero1, decimal numero2)
        {
            var Produtos = await _context.Produtos
                .Where(p => p.Preco >= numero1 && p.Preco <= numero2)
              //  .Include(p => p.Categoria)
                .ToListAsync();

            return Produtos;
        }
    }
}