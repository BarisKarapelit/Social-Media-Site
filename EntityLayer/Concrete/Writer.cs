using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class Writer
    {
        [Key]
        [DisplayName("Yazar No")]
        public int WriterID { get; set; }
        [StringLength(50)]
        [Display(Name = "Yazar Adı")]
        public string WriterName { get; set; }
        [StringLength(50)]
        [Display(Name = "Yazar Soyadı")]
        public string WriterSurName { get; set; }
        
        [StringLength(2000)]
        [DisplayName("Yazar Görsel Linki")]
        public string WriterImage { get; set; }
        [StringLength(100)]
        [Display(Name = "Hakkında")]
        public string WriterAbout { get; set; }
        [StringLength(200)]
        [Display(Name = "E-Posta")]
        public string WriterMail { get; set; }
       
        [StringLength(200)]
        [Display(Name = "Şifre")]

        public string WriterPassword { get; set; }
        [StringLength(50)]
        [Display(Name = "Ünvan")]
        public string WriterTitle { get; set; }

        public ICollection<Heading> Headings { get; set; }
        public ICollection<Content> Contents { get; set; }

    }
}
