using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class Heading
    {
        [Key]
        [DisplayName("ID")]
        public int HeadingID { get; set; }

        [StringLength(50)]
        [Display(Name = "Başlık Adı")]
        public string HeadingName { get; set; }
        [Display(Name = "Başlık Tarihi")]
        public DateTime  HeadingDate { get; set; }

        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }

        public ICollection<Content> Contents { get; set; }
        [Display(Name = "Yazar ID")]
        public int  WriterID { get; set; }
        public virtual Writer Writer { get; set; }



    }
}
