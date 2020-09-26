using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWebsite.Models.Weblog
{
    public class Blog
    {
        public Blog()
        {

        }

        public int Id { get; set; }

        [Display(Name = "عنوان بلاگ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string Title { get; set; }

        [Display(Name = "شرح مختصر بلاگ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(500, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string ShortDescription { get; set; }

        [Display(Name = "محتوای بلاگ")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Description { get; set; }

        [Display(Name = "نویسنده")]
        public string Author { get; set; }

        [Display(Name = "عکس بلاگ")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string ImageUrl { get; set; }

        [Display(Name = "تاریخ انتشار")]
        public DateTime DateTime { get; set; }

        [Display(Name = "برچسب ها")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Tags { get; set; }

        [Display(Name = "تعداد بازدید")]
        public int ViewCount { get; set; }

        public int CategoryId { get; set; }
        public virtual BlogCategory Category { get; set; }
    }
}
