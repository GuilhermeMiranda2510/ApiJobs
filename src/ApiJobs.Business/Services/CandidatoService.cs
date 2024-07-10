using ApiJobs.Business.Interfaces;
using ApiJobs.Business.Model;
using ApiJobs.Business.Services;
using ApiJobs.Model;

namespace ApiJobs.Services
{
    public class CandidatoService : BaseService, ICandidatoService
    {
        private readonly ICandidatoRepository _candidatoRepository;

        public CandidatoService(ICandidatoRepository candidatoRepository,
                             INotificador notificador) : base(notificador)
        {
            _candidatoRepository = candidatoRepository;
        }

        public async Task Adicionar(Candidato candidato)
        {
            await _candidatoRepository.Adicionar(candidato);
        }

        public async Task Atualizar(Candidato candidato)
        {
            await _candidatoRepository.Atualizar(candidato);
        }

        public async Task Remover(Guid id)
        {
            await _candidatoRepository.Remover(id);
        }

        public void Dispose()
        {
            _candidatoRepository?.Dispose();
        }
    }
}
