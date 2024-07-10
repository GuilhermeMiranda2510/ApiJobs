using ApiJobs.Business.Interfaces;
using ApiJobs.Business.Model;
using ApiJobs.Extensions;
using ApiJobs.Model;
using ApiJobs.Repository;
using ApiJobs.ViewModels;
using AutoMapper;
using k8s.KubeConfigModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiJobs.Controllers
{
    [Authorize]
    public class EmpresaController : MainController
    {
        private readonly IEmpresaVagaRepository _empresavagaRepository;
        private readonly IEmpresaVagaService _empresavagaService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public EmpresaController(INotificador notificador,
                                IEmpresaVagaRepository empresavagaRepository,
                                IEmpresaVagaService empresavagaService,
                                IMapper mapper,
                                IUser user,
                                IHttpContextAccessor httpContextAccessor) : base(notificador, user)
        {
            _empresavagaRepository = empresavagaRepository;
            _empresavagaService = empresavagaService;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        [Authorize(Roles = "Administrador,Adm Empresa,RH Empresa")]
        [ClaimsAuthorize("Empresa", "ListarTudo")]
        [HttpGet("full-vagas")]
        public async Task<IEnumerable<EmpresaVagaViewModel>> FullVagas()
        {
            return _mapper.Map<IEnumerable<EmpresaVagaViewModel>>(await _empresavagaRepository.ObterTodos());
        }


        [Authorize(Roles = "Administrador,Adm Empresa")]
        [ClaimsAuthorize("Empresa", "Adicionar")]
        [HttpPost("nova-vaga")]
        public async Task<ActionResult<EmpresaVagaViewModel>> CriarVaga(EmpresaVagaViewModel empresaViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            empresaViewModel.DataCadastro = DateTime.Now;

            await _empresavagaService.Adicionar(_mapper.Map<EmpresaVaga>(empresaViewModel));

            return CustomResponse(empresaViewModel);
        }

        [Authorize(Roles = "Administrador,Adm Empresa")]
        [ClaimsAuthorize("Empresa", "EncerrarVaga")]
        [HttpPut("encerra-vaga/{id:guid}")]
        public async Task<ActionResult<EmpresaVagaViewModel>> EncerrarVaga(Guid id, EmpresaVagaViewModel empresaViewModel)
        {
            if (id != empresaViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(empresaViewModel);
            }

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _empresavagaService.Atualizar(_mapper.Map<EmpresaVaga>(empresaViewModel));

            return CustomResponse(empresaViewModel);
        }

        [Authorize(Roles = "Administrador,RH Empresa")]
        [ClaimsAuthorize("Empresa", "ListaCandidatosPorVaga")]
        [HttpGet("busca-candidato-por-vaga/{id:guid}")]
        public async Task<ActionResult<IEnumerable<CandidatoVagaModel>>> ObterCanditatosporVaga(Guid id)
        {
            var candidatos = (await ObterCandidatos(id));

            if (candidatos == null) return NotFound();

            return candidatos.ToList();
        }

        private async Task<IEnumerable<CandidatoVagaModel>> ObterCandidatos(Guid id)
        {
            return await _empresavagaRepository.ObterVagasPorCandidato(id);
        }
    }
}
