using System.ComponentModel.DataAnnotations;

namespace Hehannul.BirdWatch.Models.BirWatchViewModels
{
    public class CreateViewModel
    {
        [Required]
        [Display(Name = "Lintulaji")]
        public string BirdName { get; set; }
    }
}
