using projeto_final_bloco_02.Model;
using projeto_final_bloco_02.Data;
using Microsoft.EntityFrameworkCore;
namespace projeto_final_bloco_02.Service.Implements
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
                .Include(p => p.Categoria)
                .ToListAsync();
        }
        public async Task<Produto?> GetById(long id)
        {

            try
            {
                var Produto = await _context.Produtos
                    .Include(p => p.Categoria)
                    .FirstAsync(i => i.Id == id);
                return Produto;
            }
            catch
            {
                return null;
            }

        }

        public async Task<Produto?> Create(Produto produto)
        {

            if (produto.Categoria is not null)
            {
                var BuscaCategoria = await _context.Categorias.FindAsync(produto.Categoria.Id);

                if (BuscaCategoria is null)
                    return null;
            }

            produto.Categoria = produto.Categoria is not null ? _context.Categorias.FirstOrDefault(t => t.Id == produto.Categoria.Id) : null;
            await _context.AddAsync(produto);
            await _context.SaveChangesAsync();

            return produto;
        }


        public async Task Delete(Produto Produto)
        {
            _context.Remove(Produto);
            await _context.SaveChangesAsync();
        }



        public async Task<Produto?> Update(Produto Produto)
        {
            var PostagemUpdate = await _context.Produtos.FindAsync(Produto.Id);

            if (PostagemUpdate is null)
                return null;

            if (Produto.Categoria is not null)
            {
                var BuscaCategoria = await _context.Categorias.FindAsync(Produto.Categoria.Id);

                if (BuscaCategoria is null)
                    return null;

                Produto.Categoria = BuscaCategoria;
            }

            _context.Entry(PostagemUpdate).State = EntityState.Detached;
            _context.Entry(Produto).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return Produto;
        }

        public async Task<IEnumerable<Produto>> GetByNome(string nome)
        {
            var Produto = await _context.Produtos
                                .Include(p => p.Categoria)
                                .Where(p => p.Nome.Contains(nome))
                                .ToListAsync();

            return Produto;
        }

        public async Task<IEnumerable<Produto>> GetByPreco(decimal numero1, decimal numero2)
        {
            var Produtos = await _context.Produtos
                .Where(p => p.Preco >= numero1 && p.Preco <= numero2)
                .Include(p => p.Categoria)
                .ToListAsync();

            return Produtos;
        }
    }
}