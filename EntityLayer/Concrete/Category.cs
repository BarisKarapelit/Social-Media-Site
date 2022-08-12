using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class Category
    {
        [Key]
        [Display(Name = "ID")]
        public int CategoryID { get; set; }
        [StringLength(50)]
        [Display(Name = "Kategori Adı")]
        public string CategoryName { get; set; }
        [DisplayName("Açıklama")]
        [StringLength(200)]
        public string CategoryDescription { get; set; }
        [DisplayName("Durum")]
        public bool CategoryStatus { get; set; }

        public ICollection<Heading> Headings { get; set; }
    }
}
