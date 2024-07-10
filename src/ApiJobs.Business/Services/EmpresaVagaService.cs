using ApiJobs.Business.Interfaces;
using ApiJobs.Business.Model;
using ApiJobs.Business.Services;
using ApiJobs.Model;

namespace ApiJobs.Services
{
    public class EmpresaVagaService : BaseService, IEmpresaVagaService
    {
        private readonly IEmpresaVagaRepository _empresavagaRepository;

        public EmpresaVagaService(IEmpresaVagaRepository empresavagaRepository,
                             INotificador notificador) : base(notificador)
        {
            _empresavagaRepository = empresavagaRepository;
        }

        public async Task Adicionar(EmpresaVaga empresa)
        {
            await _empresavagaRepository.Adicionar(empresa);
        }

        public async Task Atualizar(EmpresaVaga empresa)
        {
            await _empresavagaRepository.Atualizar(empresa);
        }

        public async Task Remover(Guid id)
        {
            await _empresavagaRepository.Remover(id);
        }

        public void Dispose()
        {
            _empresavagaRepository?.Dispose();
        }
    }
}
