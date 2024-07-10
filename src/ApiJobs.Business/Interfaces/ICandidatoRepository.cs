using ApiJobs.Business.Model;
using ApiJobs.Model;

namespace ApiJobs.Business.Interfaces
{
    public interface ICandidatoRepository : IRepository<Candidato>
    {
        Task<IEnumerable<EmpresaVaga>> ObterVagasPorCandidato(Guid candidatoID);
        Task<IEnumerable<EmpresaVaga>> ObterVagasDisponiveis();
    }
}
