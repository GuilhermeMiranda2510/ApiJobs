using ApiJobs.Business.Model;
using ApiJobs.Model;

namespace ApiJobs.Business.Interfaces
{
    public interface IEmpresaVagaRepository : IRepository<EmpresaVaga>
    {
        Task<IEnumerable<CandidatoVagaModel>> ObterVagasPorCandidato(Guid userId);
    }
}
