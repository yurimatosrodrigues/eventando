using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Diagnostics.Contracts;

namespace eventando.Models
{
    public class Produto
    {
        [Display(Name = "Código")]
        public int Codigo { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Display(Name = "Preço")]
        public double Preco { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data Fabricação")]
        public DateTime DataFabricacao { get; set; }

    }
}
