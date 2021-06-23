using System.Collections.Generic;
using System.Threading.Tasks;

namespace TcheAlerta.Data.Repositories.Interfaces
{
    public interface IRepository<T> 
    {
        //Task<IEnumerable<T>> GetAllAsync();
        List<T> GetListAsync();
        T GetAsync(int id);
        void AddAsync(T entity);
        void UpdateAsync(T entity);
        void DeleteAsync(T entity);

        //Doc Microsoft
        //Task<List<T>> GetListAsync();
        //Task<List<T>> GetListNotDoneAsync();
        //Task<T> GetAsync(int id);
        //Task<int> SaveAsync(T entity);
        //Task<int> DeleteItemAsync(T entity);

        //List<Contato> ObterTodosContatos();
        //List<Contato> PesquisarContato(string filtro);
        //Contato ObterContato(int contatoId);
        //void AdicionarContato(Contato contato);
        //void EditarContato(Contato contato);
        //void DeletarContato(int contatoId);
        //void DeletarTodosContatos();
    }
}
