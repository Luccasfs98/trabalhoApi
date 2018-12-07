using System.Threading.Tasks;
using Associados.Domain.UsuarioRoot;

namespace Associados.Domain.Interfaces
{
    public interface IUsuarioRepository : IRepositoryBase<Usuario>
    {
            Task <Usuario> AuthUser(Usuario user);
    }
}