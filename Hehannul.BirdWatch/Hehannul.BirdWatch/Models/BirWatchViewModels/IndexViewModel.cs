using Hehannul.BirdWatch.Domain;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hehannul.BirdWatch.Models.BirWatchViewModels
{
    public class IndexViewModel
    {
        [Display(Name = "Havaitut linnut")]
        public List<Bird> Birds { get; set; }
    }
}
