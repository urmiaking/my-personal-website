using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWebsite.Models.Weblog
{
    public class BlogCategory
    {
        public BlogCategory()
        {

        }

        public int Id { get; set; }

        [DisplayName("نام دسته")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(50, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string Name { get; set; }

        public virtual List<Blog> Blogs { get; set; }
    }
}
