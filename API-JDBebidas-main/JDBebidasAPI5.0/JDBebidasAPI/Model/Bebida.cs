using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JDBebidasAPI.Model
{
    public class Bebida
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Milimetragem { get; set; }
        public int Quantidade { get; set; }
    }
}
