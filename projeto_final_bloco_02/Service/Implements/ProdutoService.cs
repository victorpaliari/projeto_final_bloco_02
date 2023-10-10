using Microsoft.EntityFrameworkCore;
using projeto_final_bloco_02.Data;
using projeto_final_bloco_02.Model;

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
            return await _context.Produtos.ToListAsync();
        }

        public Task<Produto?> Create(Produto Produto)
        {
            
        }

        public Task Delete(Produto Produto)
        {
            throw new NotImplementedException();
        }

        public Task<Produto?> GetById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Produto>> GetByNome(string nome)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Produto>> GetByPreco(decimal numero1, decimal numero2)
        {
            throw new NotImplementedException();
        }

        public Task<Produto?> Update(Produto Produto)
        {
            throw new NotImplementedException();
        }
    }
}
