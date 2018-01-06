using System.ComponentModel.DataAnnotations;

namespace Hehannul.BirdWatch.Models.BirWatchViewModels
{
    public class IndexViewModel
    {
        [Display(Name = "Havaitut varikset")]
        public int NumberOfHoodedCrows { get; set; }

        [Display(Name = "Havaitut harakat")]
        public int NumberOfPicaPicas { get; set; }
    }
}
