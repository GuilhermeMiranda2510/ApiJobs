using ApiJobs.Business.Model;
using ApiJobs.Model;

namespace ApiJobs.Business.Interfaces
{
    public interface ICandidatoService : IDisposable
    {
        Task Adicionar(Candidato candidato);
        Task Atualizar(Candidato candidato);
        Task Remover(Guid id);
    }
}
