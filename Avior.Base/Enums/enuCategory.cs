using System.ComponentModel.DataAnnotations;

namespace Avior.Base.Enums
{
    public enum enuCategory
    {
        [Display(Name = "CMV")]
        CMV = 1,
        [Display(Name = "Jeugd C")]
        JeugdC = 2,
        [Display(Name = "Jeugd B")]
        JeugdB = 3,
        [Display(Name = "Jeugd A")]
        JeugdA = 4
    }
}
