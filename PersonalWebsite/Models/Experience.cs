using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalWebsite.Models
{
    public class Experience
    {
        public Experience()
        { }

        public int Id { get; set; }

        public string Title { get; set; }

        public string GreenTitle { get; set; }

        public string Duration { get; set; }

        public virtual List<ExperienceTool> ExperienceTools { get; set; }

    }

    public class Tool
    {
        public Tool()
        { }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual List<ExperienceTool> ExperienceTools { get; set; }
    }

    public class ExperienceTool
    {
        public ExperienceTool()
        { }

        public int ExperienceId { get; set; }
        public virtual Experience Experience { get; set; }

        public int ToolId { get; set; }
        public virtual Tool Tool { get; set; }
    }
}
