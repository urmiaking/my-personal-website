﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PersonalWebsite.Areas.Admin.Models;
using PersonalWebsite.Models;
using PersonalWebsite.Models.Weblog;

namespace PersonalWebsite.Data
{
    public static class MigrationExtentsion
    {
        public static IHost MigrateDatabase<T>(this IHost host) where T : DbContext
        {
            using var scope = host.Services.CreateScope();
            using var appContext = scope.ServiceProvider.GetRequiredService<T>();
            try
            {
                appContext.Database.Migrate();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return host;
        }

        public static void Seed(this ModelBuilder modelBuilder)
        {
            #region AboutMe

            modelBuilder.Entity<AboutMe>()
                .HasData(new AboutMe()
                {
                    Id = 1,
                    Description = "من، مسعود خدادادی، فارغ التحصیل رشته مهندسی کامپیوتر از دانشگاه ارومیه هستم. به طور حرفه ای در زمینه برنامه نویسی سمت سرور با زبان سی شارپ فعالیت می کنم و برنامه های تحت وب با پلتفرم ASP.Net Core توسعه می دهم. من همچنین در زمینه های زیر تجربه و مهارت دارم:",
                    Image = "dotnet.jpg"
                });

            #endregion

            #region Technology

            modelBuilder.Entity<Technology>()
                .HasData(new Technology()
                {
                    Id = 1,
                    AboutMeId = 1,
                    Title = "NET."
                }, new Technology()
                {
                    Id = 2,
                    AboutMeId = 1,
                    Title = "Java"
                }, new Technology()
                {
                    Id = 3,
                    AboutMeId = 1,
                    Title = "#C"
                }, new Technology()
                {
                    Id = 4,
                    AboutMeId = 1,
                    Title = "SQL Server"
                }, new Technology()
                {
                    Id = 5,
                    AboutMeId = 1,
                    Title = "Javascript"
                }, new Technology()
                {
                    Id = 6,
                    AboutMeId = 1,
                    Title = "Oracle SQL"
                }, new Technology()
                {
                    Id = 7,
                    AboutMeId = 1,
                    Title = "MySQL"
                }, new Technology()
                {
                    Id = 8,
                    AboutMeId = 1,
                    Title = "Docker"
                }, new Technology()
                {
                    Id = 9,
                    AboutMeId = 1,
                    Title = "Microservices"
                }, new Technology()
                {
                    Id = 10,
                    AboutMeId = 1,
                    Title = "Kubernetes"
                }, new Technology()
                {
                    Id = 11,
                    AboutMeId = 1,
                    Title = "Web API"
                }, new Technology()
                {
                    Id = 12,
                    AboutMeId = 1,
                    Title = "Clean Code"
                }, new Technology()
                {
                    Id = 13,
                    AboutMeId = 1,
                    Title = "C"
                }, new Technology()
                {
                    Id = 14,
                    AboutMeId = 1,
                    Title = "++C"
                }, new Technology()
                {
                    Id = 15,
                    AboutMeId = 1,
                    Title = "HTML"
                }, new Technology()
                {
                    Id = 16,
                    AboutMeId = 1,
                    Title = "Python"
                });

            #endregion

            #region Technical Skill

            modelBuilder.Entity<TechnicalSkill>()
                .HasData(new TechnicalSkill()
                {
                    Id = 1,
                    Progress = 86,
                    Title = "#C"
                }, new TechnicalSkill()
                {
                    Id = 2,
                    Progress = 74,
                    Title = "NET."
                }, new TechnicalSkill()
                {
                    Id = 3,
                    Progress = 90,
                    Title = "NET Core."
                }, new TechnicalSkill()
                {
                    Id = 4,
                    Progress = 53,
                    Title = "Java"
                }, new TechnicalSkill()
                {
                    Id = 5,
                    Progress = 46,
                    Title = "Javascript"
                });

            #endregion

            #region Personal Skill

            modelBuilder.Entity<PersonalSkill>()
                .HasData(new PersonalSkill()
                {
                    Id = 1,
                    Progress = 80,
                    Title = "ارتباطات خوب"
                }, new PersonalSkill()
                {
                    Id = 2,
                    Progress = 95,
                    Title = "برنامه ریزی منظم"
                }, new PersonalSkill()
                {
                    Id = 3,
                    Progress = 90,
                    Title = "مدیریت پروژه"
                }, new PersonalSkill()
                {
                    Id = 4,
                    Progress = 70,
                    Title = "کار تیمی"
                });

            #endregion

            #region Education

            modelBuilder.Entity<Education>()
                .HasData(new Education()
                {
                    Id = 1,
                    DegreeTitle = "دیپلم ریاضی و فیزیک",
                    CollegeName = "دبیرستان شاهد",
                    Description = "دریچه های علم در دبیرستان شاهد شهید آهندوست به روی من گشوده شد. من در این دبیرستان رشته ریاضی و فیزیک را گذرانده و مدرک دیپلم خود را با معدل ۱۹ کسب کرده ام.",
                    Duration = "۱۳۹۱-۱۳۹۵"
                }, new Education()
                {
                    Id = 2,
                    DegreeTitle = "کارشناسی مهندسی کامپیوتر",
                    CollegeName = "دانشگاه ارومیه",
                    Description = "دانشگاه ارومیه، راه رسیدن به جایگاهی که هم اکنون در آن قرار دارم را هموار کرد. به لطف مدد الهی، دوران کارشناسی خود را با موفقیت گذرانده و موفق به کسب مقام اول با معدل ۱۸.۲۱ در رشته مهندسی کامپیوتر شده ام.",
                    Duration = "۱۳۹۵-۱۳۹۹"
                }, new Education()
                {
                    Id = 3,
                    DegreeTitle = "کارشناسی ارشد مهندسی نرم افزار",
                    CollegeName = "دانشگاه ارومیه",
                    Description = "جهت تکمیل علم و دانش خود، قصد ادامه تحصیل در رشته مهندسی نرم افزار در دانشگاه ارومیه را دارم. امسال در کنکور ارشد شرکت کرده ام و انشالله نتیجه آن به زودی اعلام میگردد.",
                    Duration = "۱۳۹۹-..."
                });

            #endregion

            #region Experience

            modelBuilder.Entity<Experience>()
                .HasData(new Experience()
                {
                    Id = 1,
                    Duration = "۱۳۹۷",
                    Title = "پیاده سازی سوکت سرور در شرکت",
                    GreenTitle = "اسکای نیک"
                }, new Experience()
                {
                    Id = 2,
                    Duration = "۱۳۹۸-۱۳۹۹",
                    Title = "پیاده سازی سیستمی برای",
                    GreenTitle = "کلینیک بهار"
                }, new Experience()
                {
                    Id = 3,
                    Duration = "۱۳۹۹",
                    Title = "پیاده سازی سایت خبری با معماری",
                    GreenTitle = "میکروسرویس"
                });

            #endregion

            #region Tool

            modelBuilder.Entity<Tool>()
                .HasData(new Tool()
                {
                    Id = 1,
                    Name = "Java, Socket programming"
                }, new Tool()
                {
                    Id = 2,
                    Name = "HTML, CSS, JS, PHP, MySQL"
                }, new Tool()
                {
                    Id = 3,
                    Name = "ASP.NET Core 3.1"
                }, new Tool()
                {
                    Id = 4,
                    Name = "Docker & Kubernetes"
                }, new Tool()
                {
                    Id = 5,
                    Name = "ASP.NET Core 3.1 MVC and Web API"
                }, new Tool()
                {
                    Id = 6,
                    Name = "Docker, Kubernetes, Microservice architecture"
                });

            #endregion

            #region ExperienceTool

            modelBuilder.Entity<ExperienceTool>()
                .HasData(new ExperienceTool()
                {
                    ExperienceId = 1,
                    ToolId = 1
                }, new ExperienceTool()
                {
                    ExperienceId = 1,
                    ToolId = 2
                }, new ExperienceTool()
                {
                    ExperienceId = 2,
                    ToolId = 3
                }, new ExperienceTool()
                {
                    ExperienceId = 2,
                    ToolId = 4
                }, new ExperienceTool()
                {
                    ExperienceId = 3,
                    ToolId = 5
                }, new ExperienceTool()
                {
                    ExperienceId = 3,
                    ToolId = 6
                });

            #endregion

            #region WorkSample

            modelBuilder.Entity<WorkSample>()
                .HasData(new WorkSample()
                {
                    Id = 1,
                    Title = "کلینیک فوق تخصصی بهار",
                    Image = "clinic.jpg",
                    CreateDateTime = DateTime.Now
                }, new WorkSample()
                {
                    Id = 2,
                    Title = "وبسایت خبری",
                    Image = "docker.png",
                    CreateDateTime = DateTime.Now
                }, new WorkSample()
                {
                    Id = 3,
                    Title = "سرور اسکای نیک",
                    Image = "airlink-smart-hub.jpg",
                    CreateDateTime = DateTime.Now
                }, new WorkSample()
                {
                    Id = 4,
                    Title = "یادگیری ماشین",
                    Image = "machine-learning.png",
                    CreateDateTime = DateTime.Now
                }, new WorkSample()
                {
                    Id = 5,
                    Title = "وبسایت مدیریت آمار کرونا",
                    Image = "corona.png",
                    CreateDateTime = DateTime.Now
                }, new WorkSample()
                {
                    Id = 6,
                    Title = "وبسایت تاپ لرن",
                    Image = "toplearn.png",
                    CreateDateTime = DateTime.Now
                }, new WorkSample()
                {
                    Id = 7,
                    Title = "سیستم دانشگاه",
                    Image = "university.jpg",
                    CreateDateTime = DateTime.Now
                });

            #endregion

            #region Detail

            modelBuilder.Entity<Detail>()
                .HasData(new Detail()
                {
                    Id = 1,
                    Description = "در این پروژه، برنامه ای تحت وب با پلتفرم ASP.NET Core برای کلینیکی با عنوان 'کلینیک فوق تخصصی بهار' پیاده سازی شده است.بیماران کلینیک می توانند با استفاده از این برنامه با پزشک مورد نظر خود، وقت ملاقات رزرو کنند، نسخه های خود را مشاهده کنند و در صورت تمایل هزینه ی آن را به صورت آنلاین پرداخت کنند و با پزشکانی که به آن ها مراجعه کرده اند، گفت وگوی آنلاین انجام دهند.همچنین این برنامه به پزشکان کمک خواهد کرد تا اطلاعات ویزیت را ذخیره کرده و نسخه های بیماران را به طور آنلاین به داروخانه‌ی کلینیک صادر کنند.مسئول داروخانه، وظیفه ی مدیریت داروها و تحویل نسخه های صادره از سوی پزشکان به بیماران را دارد.دو مدیر برای برنامه تعیین شده است؛ مدیر سایت که وظیفه ی تولید محتوای صفحه اصلی کلینیک را دارد و مدیر کلینیک نیز می تواند پزشکان را در سیستم ثبت نام کرده، آمار کلی کلینیک را مشاهده کند و همچنین به رسیدگی به شکایات بیماران بپردازد.خروجی نهایی با استفاده از داکر به فایل ایمیج تبدیل شده که در تمامی سیستم عامل ها قابل اجرا می باشد و برای اتوماسیون استقرار، مدیریت و مقیاس پذیری برنامه از کوبرنیتز استفاده می شود.",
                    Image = "bahar-clinic.png",
                    ImageDescription = "وبسایت کلینیک فوق تخصصی بهار",
                    Link = "https://github.com/urmiaking/Clinic",
                    Technologies = "C#,ASP.NET Core,MVC,Docker,SignalR,Kubernetes",
                    Title = "پیاده سازی وبسایتی برای کلینیک فوق تخصصی بهار",
                    WorkSampleId = 1
                }, new Detail()
                {
                    Id = 2,
                    Description = "این پروژه برای درس رایانش ابری ارائه شده است.در این پروژه، وبسایتی با پلتفرم ASP.NET Core پیاده سازی شده است که بخش های مختلف آن به صورت جدا در پروژه ای دیگر ساخته شده اند و API هایی را برای برنامه اصلی ارائه می کنند.بدین ترتیب، بار کاری بین قسمت های مختلف تقسیم می شود و وبسایت برای درخواست های زیاد به مشکل نخواهد خورد.در این پروژه برای مدیریت API ها و پروژه و همچنین تضمین مقیاس پذیری و سرویس دهی ۲۴ ساعته سرور، از از کوبرنیتز استفاده شده است",
                    Image = "news-microservice.png",
                    ImageDescription = "معماری میکروسرویس پروژه وبسایت خبری",
                    Link = "https://github.com/urmiaking/news-front-end",
                    Technologies = "C#,ASP.NET Core,MVC,Web API,Docker,Microservice,Kubernetes",
                    Title = "پیاده سازی وبسایت خبری با معماری میکروسرویس",
                    WorkSampleId = 2
                }, new Detail()
                {
                    Id = 3,
                    Description = "این پروژه، با همکاری شرکت آسمان الکترونیک اسپوتا(اسکای نیک)برای مدیریت دستگاه های هوشمند از طریق گوشی هوشمند ساخته شده است.دستگاه های هوشمندی که این شرکت به تولید رسانده است کاملا بومی بوده و توسط دستگاهی به نام 'هاب'مدیریت می شوند.سرور مورد نظر با استفاده از سوکت های TCP دستورات مختلف را از دستگاه های هوشمند به تلفن های هوشمند منتقل می کند.کاربر در هر جایی می تواند به سرور متصل شده و لوازم هوشمند خانه خود را کنترل کند.برای این پروژه پنل ادمین نیز جهت مدیریت هاب ها و مشاهده آمار کاربران ساخته شده است",
                    Image = "skynic-server.png",
                    ImageDescription = "",
                    Link = "https://github.com/urmiaking/SkynicServer",
                    Technologies = "Java,Socket Programming,Skynic,PHP,MySQL,Javascript",
                    Title = "پیاده سازی سروری برای مدیریت دستگاه های هوشمند",
                    WorkSampleId = 3
                }, new Detail()
                {
                    Id = 4,
                    Description = "در این پروژه، با استفاده از دو الگوریتم SVM و Naive Bayse مدل های یادگیری ماشین برای پیش بینی عنوان خبر از روی متن آن ساخته شده است.این پروژه، ۱۵۰۰ خبر به عنوان تست دریافت کرده و عمل یادگیری را آغاز می کند.پس از اتمام یادگیری با استفاده از ۵۰۰ داده تست، کارایی آن ارزیابی می گردد.کارایی و دقت این مدل ها حداکثر به ۸۵ درصد می رسد.",
                    Image = "machine-learning-model.png",
                    ImageDescription = "پیش بینی چهار دسته خبری از روی متن خبر",
                    Link = "https://github.com/urmiaking/TextClassificationNBSVM",
                    Technologies = "Python,Machine Learning,SVM,Naive Bayse,Text Classification",
                    Title = "پیاده سازی مدلی جهت پیش بینی موضوع خبر از روی متن آن",
                    WorkSampleId = 4
                }, new Detail()
                {
                    Id = 5,
                    Description = "در این پروژه، وبسایتی با پتلفرم ASP.NET Core پیاده سازی شده است که آمار کرونا در آن با استفاده های API ها دریافت شده و توسط ادمین قابل مدیریت می باشد.برای استقرار پروژه از کوبرنیتز استفاده شده است تا مقیاس پذیری آن در بارکاری زیاد تضمین شود",
                    Image = "coronavirus.png",
                    ImageDescription = "وبسایت مدیریت آمار کرونا",
                    Link = "https://github.com/urmiaking/news-front-end",
                    Technologies = "C#,ASP.NET Core,MVC,Web API,Docker,Microservice,Kubernetes",
                    Title = "پیاده سازی وبسایت مدیریت آمار کرونا با معماری میکروسرویس",
                    WorkSampleId = 5
                }, new Detail()
                {
                    Id = 6,
                    Description = "در این پروژه با استفاده از پلتفرم ASP.NET Core سعی شده است تمامی قابلیت های سایت تاپ لرن پیاده سازی شود.این وبسایت جهت خرید دوره های برنامه نویسی طراحی شده است.پروژه در دست ساخت است و سعی شده است در آن از معماری لایه بندی، معماری تمیز و IoC استفاده شود",
                    Image = "toplearn-modal.png",
                    ImageDescription = "وبسایت تاپ لرن",
                    Link = "https://github.com/urmiaking/TopLearn",
                    Technologies = "C#,ASP.NET Core,MVC,Razor Page,Javascript",
                    Title = "پیاده سازی وبسایتی مشابه سایت تاپ لرن",
                    WorkSampleId = 6
                }, new Detail()
                {
                    Id = 7,
                    Description = "این پروژه برای درس پایگاه داده با زبان سی شارپ و با پلتفرم ویندوز فرم ساخته شده است.اطلاعات دانشجویان اساتید و مسئول دانشگاه در پایگاه داده ذخیره می شود و امکان بکاپ گیری و بازیابی پایگاه داده وجود دارد.",
                    Image = "",
                    ImageDescription = "",
                    Link = "",
                    Technologies = "C#,.NET Framework,WinForms,SQL Server,ADO.NET",
                    Title = "پیاده سازی برنامه تحت دسکتاپ برای دانشگاه",
                    WorkSampleId = 7
                });

            #endregion

            #region Category

            modelBuilder.Entity<Category>()
                .HasData(new Category()
                {
                    Id = 1,
                    Group = Group.DotNet
                }, new Category()
                {
                    Id = 2,
                    Group = Group.Java
                }, new Category()
                {
                    Id = 3,
                    Group = Group.Python
                }, new Category()
                {
                    Id = 4,
                    Group = Group.MicroService
                });

            #endregion

            #region WorkSampleCategory

            modelBuilder.Entity<WorkSampleCategory>()
                .HasData(new WorkSampleCategory()
                {
                    WorkSampleId = 1,
                    CategoryId = 1
                }, new WorkSampleCategory()
                {
                    WorkSampleId = 2,
                    CategoryId = 1
                }, new WorkSampleCategory()
                {
                    WorkSampleId = 2,
                    CategoryId = 4
                }, new WorkSampleCategory()
                {
                    WorkSampleId = 3,
                    CategoryId = 2
                }, new WorkSampleCategory()
                {
                    WorkSampleId = 4,
                    CategoryId = 3
                }, new WorkSampleCategory()
                {
                    WorkSampleId = 5,
                    CategoryId = 1
                }, new WorkSampleCategory()
                {
                    WorkSampleId = 5,
                    CategoryId = 4
                }, new WorkSampleCategory()
                {
                    WorkSampleId = 6,
                    CategoryId = 1
                }, new WorkSampleCategory()
                {
                    WorkSampleId = 7,
                    CategoryId = 1
                });

            #endregion

            #region ContactMe

            modelBuilder.Entity<ContactMe>()
                .HasData(new ContactMe()
                {
                    Id = 1,
                    Address = "آذربایجان غربی، ارومیه، مدرس",
                    EmailAddress = "masoud.xpress@gmail.com",
                    PhoneNumber = "+989382017559"
                });

            #endregion

            #region SiteAdmin

            modelBuilder.Entity<SiteAdmin>()
                .HasData(new SiteAdmin()
                {
                    Id = 1,
                    Email = "masoud.xpress@gmail.com",
                    FullName = "مسعود خدادادی",
                    Password = "f1ac294f56ceb706e90dd1719934c3ae444431483a2857bb001289f7d5acc0bb",
                    ResetPasswordCode = ""
                });

            #endregion

            #region MailServer

            modelBuilder.Entity<MailServer>()
                .HasData(new MailServer()
                {
                    Id = 1,
                    HostAddress = "smtp.gmail.com",
                    Port = 587,
                    ServerAddress = "masoud.xpress@gmail.com",
                    Password = "MASOUD7559"
                });

            #endregion

            #region Blog

            modelBuilder.Entity<BlogCategory>()
                .HasData(new BlogCategory()
                {
                    Id = 1,
                    Name = "دات نت"
                });

            modelBuilder.Entity<BlogCategory>()
                .HasData(new BlogCategory()
                {
                    Id = 2,
                    Name = "برنامه نویسی"
                });

            modelBuilder.Entity<BlogCategory>()
                .HasData(new BlogCategory()
                {
                    Id = 3,
                    Name = "تکنولوژی"
                });

            modelBuilder.Entity<Blog>()
                .HasData(new Blog()
                {
                    Id = 1,
                    Author = "مسعود خدادادی",
                    CategoryId = 1,
                    Title = "لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ",
                    DateTime = DateTime.Now,
                    Description = "لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ، و با استفاده از طراحان گرافیک است، چاپگرها و متون بلکه روزنامه و مجله در ستون و سطرآنچنان که لازم است، و برای شرایط فعلی تکنولوژی مورد نیاز، و کاربردهای متنوع با هدف بهبود ابزارهای کاربردی می باشد، کتابهای زیادی در شصت و سه درصد گذشته حال و آینده، شناخت فراوان جامعه و متخصصان را می طلبد، تا با نرم افزارها شناخت بیشتری را برای طراحان رایانه ای علی الخصوص طراحان خلاقی، و فرهنگ پیشرو در زبان فارسی ایجاد کرد، در این صورت می توان امید داشت که تمام و دشواری موجود در ارائه راهکارها، و شرایط سخت تایپ به پایان رسد و زمان مورد نیاز شامل حروفچینی دستاوردهای اصلی، و جوابگوی سوالات پیوسته اهل دنیای موجود طراحی اساسا مورد استفاده قرار گیرد.لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ، و با استفاده از طراحان گرافیک است، چاپگرها و متون بلکه روزنامه و مجله در ستون و سطرآنچنان که لازم است، و برای شرایط فعلی تکنولوژی مورد نیاز، و کاربردهای متنوع با هدف بهبود ابزارهای کاربردی می باشد، کتابهای زیادی در شصت و سه درصد گذشته حال و آینده، شناخت فراوان جامعه و متخصصان را می طلبد، تا با نرم افزارها شناخت بیشتری را برای طراحان رایانه ای علی الخصوص طراحان خلاقی، و فرهنگ پیشرو در زبان فارسی ایجاد کرد، در این صورت می توان امید داشت که تمام و دشواری موجود در ارائه راهکارها، و شرایط سخت تایپ به پایان رسد و زمان مورد نیاز شامل حروفچینی دستاوردهای اصلی، و جوابگوی سوالات پیوسته اهل دنیای موجود طراحی اساسا مورد استفاده قرار گیرد.لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ، و با استفاده از طراحان گرافیک است، چاپگرها و متون بلکه روزنامه و مجله در ستون و سطرآنچنان که لازم است، و برای شرایط فعلی تکنولوژی مورد نیاز، و کاربردهای متنوع با هدف بهبود ابزارهای کاربردی می باشد، کتابهای زیادی در شصت و سه درصد گذشته حال و آینده، شناخت فراوان جامعه و متخصصان را می طلبد، تا با نرم افزارها شناخت بیشتری را برای طراحان رایانه ای علی الخصوص طراحان خلاقی، و فرهنگ پیشرو در زبان فارسی ایجاد کرد، در این صورت می توان امید داشت که تمام و دشواری موجود در ارائه راهکارها، و شرایط سخت تایپ به پایان رسد و زمان مورد نیاز شامل حروفچینی دستاوردهای اصلی، و جوابگوی سوالات پیوسته اهل دنیای موجود طراحی اساسا مورد استفاده قرار گیرد.",
                    ShortDescription = "لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ",
                    ImageUrl = "b-1.png",
                    Tags = "تست،تست دو، تست سه"
                });

            modelBuilder.Entity<Blog>()
                .HasData(new Blog()
                {
                    Id = 2,
                    Author = "مسعود خدادادی",
                    CategoryId = 2,
                    Title = "لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ",
                    DateTime = DateTime.Now,
                    Description = "لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ، و با استفاده از طراحان گرافیک است، چاپگرها و متون بلکه روزنامه و مجله در ستون و سطرآنچنان که لازم است، و برای شرایط فعلی تکنولوژی مورد نیاز، و کاربردهای متنوع با هدف بهبود ابزارهای کاربردی می باشد، کتابهای زیادی در شصت و سه درصد گذشته حال و آینده، شناخت فراوان جامعه و متخصصان را می طلبد، تا با نرم افزارها شناخت بیشتری را برای طراحان رایانه ای علی الخصوص طراحان خلاقی، و فرهنگ پیشرو در زبان فارسی ایجاد کرد، در این صورت می توان امید داشت که تمام و دشواری موجود در ارائه راهکارها، و شرایط سخت تایپ به پایان رسد و زمان مورد نیاز شامل حروفچینی دستاوردهای اصلی، و جوابگوی سوالات پیوسته اهل دنیای موجود طراحی اساسا مورد استفاده قرار گیرد.لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ، و با استفاده از طراحان گرافیک است، چاپگرها و متون بلکه روزنامه و مجله در ستون و سطرآنچنان که لازم است، و برای شرایط فعلی تکنولوژی مورد نیاز، و کاربردهای متنوع با هدف بهبود ابزارهای کاربردی می باشد، کتابهای زیادی در شصت و سه درصد گذشته حال و آینده، شناخت فراوان جامعه و متخصصان را می طلبد، تا با نرم افزارها شناخت بیشتری را برای طراحان رایانه ای علی الخصوص طراحان خلاقی، و فرهنگ پیشرو در زبان فارسی ایجاد کرد، در این صورت می توان امید داشت که تمام و دشواری موجود در ارائه راهکارها، و شرایط سخت تایپ به پایان رسد و زمان مورد نیاز شامل حروفچینی دستاوردهای اصلی، و جوابگوی سوالات پیوسته اهل دنیای موجود طراحی اساسا مورد استفاده قرار گیرد.لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ، و با استفاده از طراحان گرافیک است، چاپگرها و متون بلکه روزنامه و مجله در ستون و سطرآنچنان که لازم است، و برای شرایط فعلی تکنولوژی مورد نیاز، و کاربردهای متنوع با هدف بهبود ابزارهای کاربردی می باشد، کتابهای زیادی در شصت و سه درصد گذشته حال و آینده، شناخت فراوان جامعه و متخصصان را می طلبد، تا با نرم افزارها شناخت بیشتری را برای طراحان رایانه ای علی الخصوص طراحان خلاقی، و فرهنگ پیشرو در زبان فارسی ایجاد کرد، در این صورت می توان امید داشت که تمام و دشواری موجود در ارائه راهکارها، و شرایط سخت تایپ به پایان رسد و زمان مورد نیاز شامل حروفچینی دستاوردهای اصلی، و جوابگوی سوالات پیوسته اهل دنیای موجود طراحی اساسا مورد استفاده قرار گیرد.",
                    ShortDescription = "لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ",
                    ImageUrl = "b-1.png",
                    Tags = "تست،تست دو، تست سه"
                });

            modelBuilder.Entity<Blog>()
                .HasData(new Blog()
                {
                    Id = 3,
                    Author = "مسعود خدادادی",
                    CategoryId = 3,
                    Title = "لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ",
                    DateTime = DateTime.Now,
                    Description = "لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ، و با استفاده از طراحان گرافیک است، چاپگرها و متون بلکه روزنامه و مجله در ستون و سطرآنچنان که لازم است، و برای شرایط فعلی تکنولوژی مورد نیاز، و کاربردهای متنوع با هدف بهبود ابزارهای کاربردی می باشد، کتابهای زیادی در شصت و سه درصد گذشته حال و آینده، شناخت فراوان جامعه و متخصصان را می طلبد، تا با نرم افزارها شناخت بیشتری را برای طراحان رایانه ای علی الخصوص طراحان خلاقی، و فرهنگ پیشرو در زبان فارسی ایجاد کرد، در این صورت می توان امید داشت که تمام و دشواری موجود در ارائه راهکارها، و شرایط سخت تایپ به پایان رسد و زمان مورد نیاز شامل حروفچینی دستاوردهای اصلی، و جوابگوی سوالات پیوسته اهل دنیای موجود طراحی اساسا مورد استفاده قرار گیرد.لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ، و با استفاده از طراحان گرافیک است، چاپگرها و متون بلکه روزنامه و مجله در ستون و سطرآنچنان که لازم است، و برای شرایط فعلی تکنولوژی مورد نیاز، و کاربردهای متنوع با هدف بهبود ابزارهای کاربردی می باشد، کتابهای زیادی در شصت و سه درصد گذشته حال و آینده، شناخت فراوان جامعه و متخصصان را می طلبد، تا با نرم افزارها شناخت بیشتری را برای طراحان رایانه ای علی الخصوص طراحان خلاقی، و فرهنگ پیشرو در زبان فارسی ایجاد کرد، در این صورت می توان امید داشت که تمام و دشواری موجود در ارائه راهکارها، و شرایط سخت تایپ به پایان رسد و زمان مورد نیاز شامل حروفچینی دستاوردهای اصلی، و جوابگوی سوالات پیوسته اهل دنیای موجود طراحی اساسا مورد استفاده قرار گیرد.لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ، و با استفاده از طراحان گرافیک است، چاپگرها و متون بلکه روزنامه و مجله در ستون و سطرآنچنان که لازم است، و برای شرایط فعلی تکنولوژی مورد نیاز، و کاربردهای متنوع با هدف بهبود ابزارهای کاربردی می باشد، کتابهای زیادی در شصت و سه درصد گذشته حال و آینده، شناخت فراوان جامعه و متخصصان را می طلبد، تا با نرم افزارها شناخت بیشتری را برای طراحان رایانه ای علی الخصوص طراحان خلاقی، و فرهنگ پیشرو در زبان فارسی ایجاد کرد، در این صورت می توان امید داشت که تمام و دشواری موجود در ارائه راهکارها، و شرایط سخت تایپ به پایان رسد و زمان مورد نیاز شامل حروفچینی دستاوردهای اصلی، و جوابگوی سوالات پیوسته اهل دنیای موجود طراحی اساسا مورد استفاده قرار گیرد.",
                    ShortDescription = "لورم ایپسوم متن ساختگی با تولید سادگی نامفهوم از صنعت چاپ",
                    ImageUrl = "b-1.png",
                    Tags = "تست،تست دو، تست سه"
                });

            #endregion
        }
    }
}
