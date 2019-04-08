using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TelephoneDirectory.Entities
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }

        [DisplayName ("Departman Adı")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Departman adı bilgisi boş geçilmez!")]
        public string DepartmentName { get; set; }

        [DisplayName ("Departman Açıklaması")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Departman açıklama bilgisi boş geçilmez!")]
        public string DepartmentDescription { get; set; }
    }
}