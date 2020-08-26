using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWebsite.Models
{
    public class WorkSample
    {
        public WorkSample()
        { }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Image { get; set; }

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

        public string Title { get; set; }

        public string Description { get; set; }

        public string Technologies { get; set; }

        public string Image { get; set; }

        public string ImageDescription { get; set; }

        public string Link { get; set; }

        public int WorkSampleId { get; set; }

        public virtual WorkSample WorkSample { get; set; }
    }
}
