using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWebsite.Models
{
    public class WorkSample
    {
        public WorkSample()
        { }

        public int Id { get; set; }


        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Title { get; set; }

        [Display(Name = "تصویر")]
        public string Image { get; set; }

        [Display(Name = "تاریخ ایجاد")]
        public DateTime CreateDateTime { get; set; }

        public virtual List<WorkSampleCategory> WorkSampleCategories { get; set; }

        public virtual Detail Detail { get; set; }
    }

    public class WorkSampleCategory
    {
        public WorkSampleCategory()
        { }

        public int WorkSampleId { get; set; }
        public virtual WorkSample WorkSample { get; set; }

        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }

    public class Category
    {
        public Category()
        { }

        public int Id { get; set; }

        [Display(Name = "تکنولوژی")]
        public Group Group { get; set; }

        public virtual List<WorkSampleCategory> WorkSampleCategories { get; set; }
    }

    public enum Group
    {
        DotNet, Python, MicroService, Java
    }

    public class Detail
    {
        public Detail()
        { }

        public int Id { get; set; }

        [Display(Name = "عنوان")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Title { get; set; }

        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Description { get; set; }

        [Display(Name = "تکنولوژی ها")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Technologies { get; set; }

        [Display(Name = "تصویر پیش نمایش")]
        public string Image { get; set; }

        [Display(Name = "کپشن عکس")]
        public string ImageDescription { get; set; }

        [Display(Name = "لینک گیت هاب")]
        public string Link { get; set; }

        public int WorkSampleId { get; set; }

        public virtual WorkSample WorkSample { get; set; }
    }
}
