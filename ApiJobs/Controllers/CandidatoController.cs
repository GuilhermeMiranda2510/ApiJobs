using ApiJobs.Business.Interfaces;
using ApiJobs.Business.Model;
using ApiJobs.Extensions;
using ApiJobs.Model;
using ApiJobs.Repository;
using ApiJobs.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiJobs.Controllers
{
    [Authorize]
    public class CandidatoController : MainController
    {

        private readonly ICandidatoRepository _candidatoRepository;
        private readonly IEmpresaVagaRepository _empresavagaRepository;
        private readonly ICandidatoService _candidatoService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CandidatoController(INotificador notificador,
                                ICandidatoRepository candidatoRepository,
                                IEmpresaVagaRepository empresavagaRepository,
                                ICandidatoService candidatoService,
                                IMapper mapper,
                                IUser user,
                                IHttpContextAccessor httpContextAccessor) : base(notificador, user)
        {
            _candidatoRepository = candidatoRepository;
            _candidatoService = candidatoService;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _empresavagaRepository = empresavagaRepository;
        }

        [Authorize(Roles = "Administrador,Candidato")]
        [ClaimsAuthorize("Candidato", "Adicionar")]
        [HttpPost("registrar-na-vaga")]
        public async Task<ActionResult<CandidatoViewModel>> Registrar(CandidatoViewModel candidatoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _candidatoService.Adicionar(_mapper.Map<Candidato>(candidatoViewModel));

            return CustomResponse(candidatoViewModel);
        }

        [HttpGet("busca-vaga-candidato/{id:guid}")]
        public async Task<ActionResult<IEnumerable<EmpresaVaga>>> ObterPorId(Guid id)
        {
            var produtoViewModel = (await ObterVagas(id));

            if (produtoViewModel == null) return NotFound();

            return produtoViewModel.ToList();
        }

        [Authorize(Roles = "Administrador, Candidato")]
        [ClaimsAuthorize("Candidato", "FullVagasDisponiveis")]
        [HttpGet("full-vagas-disponiveis")]
        public async Task<ActionResult<IEnumerable<EmpresaVaga>>> FullVagasDisponiveis()
        {
            var produtoViewModel = await _candidatoRepository.ObterVagasDisponiveis();
            if (produtoViewModel == null) return NotFound();

            return produtoViewModel.ToList();
        }

        private async Task<IEnumerable<EmpresaVaga>> ObterVagas(Guid id)
        {
            return await _candidatoRepository.ObterVagasPorCandidato(id);
        }
    }
}
