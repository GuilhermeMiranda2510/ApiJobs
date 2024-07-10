using ApiJobs.Business.Interfaces;
using ApiJobs.Business.Model;
using ApiJobs.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ApiJobs.Repository
{
    public class EmpresaVagaRepository : Repository<EmpresaVaga>, IEmpresaVagaRepository
    {
        public EmpresaVagaRepository(DbJobsContext context) : base(context) { }

        public async Task<IEnumerable<CandidatoVagaModel>> ObterVagasPorCandidato(Guid vagaID)
        {
            var parameters = new[]
              {
                  new SqlParameter("@VagaID", vagaID)
              };

            var vagas = Db.Set<CandidatoVagaModel>()
                    .FromSqlRaw("PROC_BUSCACANDIDATOPORVAGA @VagaID", parameters)
                    .ToList();
            return vagas.ToList();
        }
    }
}
