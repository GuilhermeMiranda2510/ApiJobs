using System.ComponentModel.DataAnnotations;

namespace ApiJobs.Business.Model
{
    public class CandidatoVagaModel
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime DataCandidatura { get; set; }
        public Guid VagaID { get; set; }
        public DateTime DataAbertura { get; set; }
        public string TituloVaga { get; set; }
        public string DescricaoVaga { get; set; }
        public string SalarioVaga { get; set; }
        public string Empresa { get; set; }
        public string EmailCandidato { get; set; }
    }
}
