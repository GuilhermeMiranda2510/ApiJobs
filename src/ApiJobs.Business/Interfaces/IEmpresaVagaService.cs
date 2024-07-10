using ApiJobs.Business.Model;
using ApiJobs.Model;

namespace ApiJobs.Business.Interfaces
{
    public interface IEmpresaVagaService : IDisposable
    {
        Task Adicionar(EmpresaVaga empresa);
        Task Atualizar(EmpresaVaga empresa);
        Task Remover(Guid id);
    }
}
