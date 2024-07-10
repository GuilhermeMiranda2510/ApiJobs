using ApiJobs.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiJobs.ViewModels
{
    public class EmpresaVagaViewModel
    {
        [Key]
        public Guid Id { get; set; }

        public Guid UserID { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataCadastro { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string TituloVaga { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string DescricaoVaga { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string StatusVaga { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string SalarioVaga { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Empresa { get; set; }

    }
}
