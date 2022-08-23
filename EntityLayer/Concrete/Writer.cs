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
        [DisplayName("ID")]
        public int WriterID { get; set; }
        [StringLength(50)]
        [Display(Name = "Yazar Adı")]
        public string WriterName { get; set; }
        [StringLength(50)]
        [Display(Name = "Yazar Soyadı")]
        public string WriterSurName { get; set; }
        
        [StringLength(100)]
        public string WriterImage { get; set; }
        [StringLength(50)]
        [Display(Name = "E-Posta")]
        public string WriterMail { get; set; }
       
        [StringLength(20)]
        public string WriterPassword { get; set; }

        public ICollection<Heading> Headings { get; set; }
        public ICollection<Content> Contents { get; set; }

    }
}
