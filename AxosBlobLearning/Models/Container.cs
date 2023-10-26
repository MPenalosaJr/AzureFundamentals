using System.ComponentModel.DataAnnotations;

namespace AxosBlobLearning.Models
{
    public class Container
    {
        [Required]
        public string Name { get; set; }
    }
}
