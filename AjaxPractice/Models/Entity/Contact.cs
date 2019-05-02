using AjaxPractice.AppCode.Globalization;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AjaxPractice.Models.Entity
{
    public class Contact
    {
        public int Id { get; set; }

        [Display(Name = "FirstName", ResourceType = typeof(RLang))]
        [Required(ErrorMessageResourceName = "RequiredField",ErrorMessageResourceType = typeof(RLang))]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(RLang))]
        [Display(Name = "LastName", ResourceType = typeof(RLang))]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(RLang))]
        [Display(Name = "Organisation", ResourceType = typeof(RLang))]
        [StringLength(100)]
        public string Organisation { get; set; }

        [Required(ErrorMessageResourceName = "RequiredField", ErrorMessageResourceType = typeof(RLang))]
        [Display(Name = "Phone", ResourceType = typeof(RLang))]
        [StringLength(15)]
        [Column(TypeName = "varchar")]
        public string Phone { get; set; }

        [Display(Name = "Email", ResourceType = typeof(RLang))]
        [EmailAddress(ErrorMessageResourceName ="EmailField", ErrorMessageResourceType = typeof(RLang))]
        public string Email { get; set; }
    }
}