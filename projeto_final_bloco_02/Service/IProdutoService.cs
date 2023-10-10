﻿using projeto_final_bloco_02.Model;

namespace projeto_final_bloco_02.Service
{
    public interface IProdutoService
    {
        Task<IEnumerable<Produto>> GetAll();

        Task<Produto?> GetById(long id);

        Task<IEnumerable<Produto>> GetByNome(string nome);

        Task<IEnumerable<Produto>> GetByPreco(decimal numero1, decimal numero2);

        Task<Produto?> Create(Produto Produto);

        Task<Produto?> Update(Produto Produto);

        Task Delete(Produto Produto);
    }
}
