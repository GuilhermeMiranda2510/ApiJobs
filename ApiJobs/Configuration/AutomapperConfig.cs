using ApiJobs.Business.Model;
using ApiJobs.Model;
using ApiJobs.ViewModels;
using AutoMapper;

namespace ApiJobs.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<EmpresaVagaViewModel, EmpresaVaga>().ReverseMap();
            CreateMap<CandidatoViewModel, Candidato>().ReverseMap();
            CreateMap<EmpresaVaga, EmpresaVagaViewModel>()
                .ForMember(dest => dest.UserID, opt => opt.MapFrom(src => src.UserID));
        }
    }
}
