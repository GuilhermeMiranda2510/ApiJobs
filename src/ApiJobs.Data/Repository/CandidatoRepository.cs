using ApiJobs.Business.Interfaces;
using ApiJobs.Business.Model;
using ApiJobs.Context;
using ApiJobs.Repository;
using Microsoft.EntityFrameworkCore;


namespace ApiJobs.Data.Repository
{
    public class CandidatoRepository : Repository<Candidato>, ICandidatoRepository
    {
        public CandidatoRepository(DbJobsContext context) : base(context) { }

        public async Task<IEnumerable<EmpresaVaga>> ObterVagasPorCandidato(Guid candidatoID)
        {
            var vagas = await (from v in Db.Vagas
                               join c in Db.Candidatos on v.Id equals c.VagaId
                               where c.UserId == candidatoID
                               select  v
                               ).ToListAsync();
            return vagas;
        }

        public async Task<IEnumerable<EmpresaVaga>> ObterVagasDisponiveis()
        {
            var vagasAbertas = await (from v in Db.Vagas
                                where v.StatusVaga == "Aberta"
                               select v
                               ).ToListAsync();
            return vagasAbertas;
        }
    }
}
