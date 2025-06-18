using System.ComponentModel.DataAnnotations;

namespace CrudVF.Models
{
    public class Personagem
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; set; }
        
        [Required(ErrorMessage = "A idade é obrigatória.")]
        public string Tipo { get; set; }
        
    }
}