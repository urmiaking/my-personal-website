using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonalWebsite.Models;
using PersonalWebsite.Models.Weblog;

namespace PersonalWebsite.DTOs
{
    public class IndexViewModel
    {
        public IndexViewModel(AboutMe aboutMe, List<TechnicalSkill> technicalSkills, List<Blog> blogs, List<PersonalSkill> personalSkills, List<Education> educations, List<Experience> experiences, List<WorkSample> workSamples, ContactMe contactMe, ContactForm contactForm)
        {
            AboutMe = aboutMe;
            TechnicalSkills = technicalSkills ?? new List<TechnicalSkill>();
            PersonalSkills = personalSkills ?? new List<PersonalSkill>();
            Educations = educations ?? new List<Education>();
            Experiences = experiences ?? new List<Experience>();
            WorkSamples = workSamples ?? new List<WorkSample>();
            Blogs = blogs ?? new List<Blog>();
            ContactMe = contactMe;
            ContactForm = contactForm;
        }

        public IndexViewModel()
        {
            TechnicalSkills =  new List<TechnicalSkill>();
            PersonalSkills =  new List<PersonalSkill>();
            Educations =  new List<Education>();
            Experiences =  new List<Experience>();
            WorkSamples =  new List<WorkSample>();
            Blogs = new List<Blog>();
        }

        public AboutMe AboutMe { get; set; }

        public List<TechnicalSkill> TechnicalSkills { get; set; }
        public List<PersonalSkill> PersonalSkills { get; set; }

        public List<Education> Educations { get; set; }
        public List<Experience> Experiences { get; set; }

        public List<WorkSample> WorkSamples { get; set; }

        public List<Blog> Blogs { get; set; }

        public ContactMe ContactMe { get; set; }
        public ContactForm ContactForm { get; set; }
    }
}
