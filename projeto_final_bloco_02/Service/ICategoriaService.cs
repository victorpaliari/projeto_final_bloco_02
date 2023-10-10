using projeto_final_bloco_02.Model;

namespace projeto_final_bloco_02.Service
{
    public interface ICategoriaService
    {
        Task<IEnumerable<Categoria>> GetAll();

        Task<Categoria?> GetById(long id);

        Task<IEnumerable<Categoria>> GetByTipo(string tipo);

        Task<Categoria?> Create(Categoria Categoria);

        Task<Categoria?> Update(Categoria Categoria);

        Task Delete(Categoria Categoria);

    }
}
