using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace ApiJobs.Business.Model
{
    public class EmpresaVaga : Entity
    {
        public Guid UserID { get; set; }

        public DateTime DataCadastro { get; set; }

        public string TituloVaga { get; set; }

        public string DescricaoVaga { get; set; }

        public string StatusVaga { get; set; }

        public string SalarioVaga { get; set; }

        public string Empresa { get; set; }

    }
}
