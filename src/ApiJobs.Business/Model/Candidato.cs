namespace ApiJobs.Business.Model
{
    public class Candidato : Entity
    {
        public DateTime DataCadastro { get; set; }

        public Guid VagaId { get; set; }

        public Guid UserId { get; set; }
    }
}
