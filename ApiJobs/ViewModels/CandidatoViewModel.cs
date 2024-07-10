using ApiJobs.Model;
using AutoMapper.Configuration.Annotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiJobs.ViewModels
{
    public class CandidatoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }
        public Guid VagaId { get; set; }
        public Guid UserId { get; set; }
    }
}
