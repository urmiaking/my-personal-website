using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWebsite.Models
{
    public class AboutMe
    {
        public AboutMe()
        { }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string Description { get; set; }

        public string Image { get; set; }

        public virtual List<Technology> Technologies { get; set; }
    }

    public class Technology
    {
        public Technology()
        { }

        public int Id { get; set; }

        [DisplayName("عنوان تکنولوژی")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string Title { get; set; }

        public int AboutMeId { get; set; }

        public virtual AboutMe AboutMe { get; set; }
    }
}
