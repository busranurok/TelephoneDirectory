using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TelephoneDirectory.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [DisplayName("Ad")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Ad bilgisi boş geçilmez!")]
        [StringLength(25, ErrorMessage ="En fazla 25 karakter girmelisiniz.")]
        public string Name { get; set; }

        [DisplayName("Soyad")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Soyad bilgisi boş geçilmez!")]
        public string Lastname { get; set; }

        [DisplayName("Kullanıcı Ad")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Kullanıcı Adı bilgisi boş geçilmez!")]
        public string Username { get; set; }

        [DisplayName("Telefon")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Telefon bilgisi boş geçilmez!")]
        public string PhoneNumber { get; set; }

        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; }

        public int ManagerId { get; set; }

        [DisplayName("Yönetici")]
        public virtual User Manager { get; set; }

        [DisplayName("Şifre")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Şifre boş geçilmez!")]
        public string Password { get; set; }

        public bool IsAdmin { get; set; }
    }
}