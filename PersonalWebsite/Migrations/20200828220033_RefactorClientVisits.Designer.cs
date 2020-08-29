﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PersonalWebsite.Data;

namespace PersonalWebsite.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20200828220033_RefactorClientVisits")]
    partial class RefactorClientVisits
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PersonalWebsite.Areas.Admin.Models.MailServer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("HostAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Port")
                        .HasColumnType("int");

                    b.Property<string>("ServerAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("MailServers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            HostAddress = "smtp.gmail.com",
                            Password = "MASOUD7559",
                            Port = 587,
                            ServerAddress = "masoud.xpress@gmail.com"
                        });
                });

            modelBuilder.Entity("PersonalWebsite.Areas.Admin.Models.SiteAdmin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResetPasswordCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SiteAdmins");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "masoud.xpress@gmail.com",
                            FullName = "مسعود خدادادی",
                            Password = "f1ac294f56ceb706e90dd1719934c3ae444431483a2857bb001289f7d5acc0bb",
                            ResetPasswordCode = ""
                        });
                });

            modelBuilder.Entity("PersonalWebsite.Models.AboutMe", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AboutMe");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "من، مسعود خدادادی، فارغ التحصیل رشته مهندسی کامپیوتر از دانشگاه ارومیه هستم. به طور حرفه ای در زمینه برنامه نویسی سمت سرور با زبان سی شارپ فعالیت می کنم و برنامه های تحت وب با پلتفرم ASP.Net Core توسعه می دهم. من همچنین در زمینه های زیر تجربه و مهارت دارم:",
                            Image = "dotnet.jpg"
                        });
                });

            modelBuilder.Entity("PersonalWebsite.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Group")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Group = 0
                        },
                        new
                        {
                            Id = 2,
                            Group = 3
                        },
                        new
                        {
                            Id = 3,
                            Group = 1
                        },
                        new
                        {
                            Id = 4,
                            Group = 2
                        });
                });

            modelBuilder.Entity("PersonalWebsite.Models.ClientVisit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("IpAddress")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ClientVisits");
                });

            modelBuilder.Entity("PersonalWebsite.Models.ContactForm", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ContactForms");
                });

            modelBuilder.Entity("PersonalWebsite.Models.ContactMe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ContactMe");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "آذربایجان غربی، ارومیه، مدرس",
                            EmailAddress = "masoud.xpress@gmail.com",
                            PhoneNumber = "+989382017559"
                        });
                });

            modelBuilder.Entity("PersonalWebsite.Models.Detail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Link")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Technologies")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("WorkSampleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("WorkSampleId")
                        .IsUnique();

                    b.ToTable("Details");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "در این پروژه، برنامه ای تحت وب با پلتفرم ASP.NET Core برای کلینیکی با عنوان 'کلینیک فوق تخصصی بهار' پیاده سازی شده است.بیماران کلینیک می توانند با استفاده از این برنامه با پزشک مورد نظر خود، وقت ملاقات رزرو کنند، نسخه های خود را مشاهده کنند و در صورت تمایل هزینه ی آن را به صورت آنلاین پرداخت کنند و با پزشکانی که به آن ها مراجعه کرده اند، گفت وگوی آنلاین انجام دهند.همچنین این برنامه به پزشکان کمک خواهد کرد تا اطلاعات ویزیت را ذخیره کرده و نسخه های بیماران را به طور آنلاین به داروخانه‌ی کلینیک صادر کنند.مسئول داروخانه، وظیفه ی مدیریت داروها و تحویل نسخه های صادره از سوی پزشکان به بیماران را دارد.دو مدیر برای برنامه تعیین شده است؛ مدیر سایت که وظیفه ی تولید محتوای صفحه اصلی کلینیک را دارد و مدیر کلینیک نیز می تواند پزشکان را در سیستم ثبت نام کرده، آمار کلی کلینیک را مشاهده کند و همچنین به رسیدگی به شکایات بیماران بپردازد.خروجی نهایی با استفاده از داکر به فایل ایمیج تبدیل شده که در تمامی سیستم عامل ها قابل اجرا می باشد و برای اتوماسیون استقرار، مدیریت و مقیاس پذیری برنامه از کوبرنیتز استفاده می شود.",
                            Image = "bahar-clinic.png",
                            ImageDescription = "وبسایت کلینیک فوق تخصصی بهار",
                            Link = "https://github.com/urmiaking/Clinic",
                            Technologies = "C#,ASP.NET Core,MVC,Docker,SignalR,Kubernetes",
                            Title = "پیاده سازی وبسایتی برای کلینیک فوق تخصصی بهار",
                            WorkSampleId = 1
                        },
                        new
                        {
                            Id = 2,
                            Description = "این پروژه برای درس رایانش ابری ارائه شده است.در این پروژه، وبسایتی با پلتفرم ASP.NET Core پیاده سازی شده است که بخش های مختلف آن به صورت جدا در پروژه ای دیگر ساخته شده اند و API هایی را برای برنامه اصلی ارائه می کنند.بدین ترتیب، بار کاری بین قسمت های مختلف تقسیم می شود و وبسایت برای درخواست های زیاد به مشکل نخواهد خورد.در این پروژه برای مدیریت API ها و پروژه و همچنین تضمین مقیاس پذیری و سرویس دهی ۲۴ ساعته سرور، از از کوبرنیتز استفاده شده است",
                            Image = "news-microservice.png",
                            ImageDescription = "معماری میکروسرویس پروژه وبسایت خبری",
                            Link = "https://github.com/urmiaking/news-front-end",
                            Technologies = "C#,ASP.NET Core,MVC,Web API,Docker,Microservice,Kubernetes",
                            Title = "پیاده سازی وبسایت خبری با معماری میکروسرویس",
                            WorkSampleId = 2
                        },
                        new
                        {
                            Id = 3,
                            Description = "این پروژه، با همکاری شرکت آسمان الکترونیک اسپوتا(اسکای نیک)برای مدیریت دستگاه های هوشمند از طریق گوشی هوشمند ساخته شده است.دستگاه های هوشمندی که این شرکت به تولید رسانده است کاملا بومی بوده و توسط دستگاهی به نام 'هاب'مدیریت می شوند.سرور مورد نظر با استفاده از سوکت های TCP دستورات مختلف را از دستگاه های هوشمند به تلفن های هوشمند منتقل می کند.کاربر در هر جایی می تواند به سرور متصل شده و لوازم هوشمند خانه خود را کنترل کند.برای این پروژه پنل ادمین نیز جهت مدیریت هاب ها و مشاهده آمار کاربران ساخته شده است",
                            Image = "skynic-server.png",
                            ImageDescription = "",
                            Link = "https://github.com/urmiaking/SkynicServer",
                            Technologies = "Java,Socket Programming,Skynic,PHP,MySQL,Javascript",
                            Title = "پیاده سازی سروری برای مدیریت دستگاه های هوشمند",
                            WorkSampleId = 3
                        },
                        new
                        {
                            Id = 4,
                            Description = "در این پروژه، با استفاده از دو الگوریتم SVM و Naive Bayse مدل های یادگیری ماشین برای پیش بینی عنوان خبر از روی متن آن ساخته شده است.این پروژه، ۱۵۰۰ خبر به عنوان تست دریافت کرده و عمل یادگیری را آغاز می کند.پس از اتمام یادگیری با استفاده از ۵۰۰ داده تست، کارایی آن ارزیابی می گردد.کارایی و دقت این مدل ها حداکثر به ۸۵ درصد می رسد.",
                            Image = "machine-learning-model.png",
                            ImageDescription = "پیش بینی چهار دسته خبری از روی متن خبر",
                            Link = "https://github.com/urmiaking/TextClassificationNBSVM",
                            Technologies = "Python,Machine Learning,SVM,Naive Bayse,Text Classification",
                            Title = "پیاده سازی مدلی جهت پیش بینی موضوع خبر از روی متن آن",
                            WorkSampleId = 4
                        },
                        new
                        {
                            Id = 5,
                            Description = "در این پروژه، وبسایتی با پتلفرم ASP.NET Core پیاده سازی شده است که آمار کرونا در آن با استفاده های API ها دریافت شده و توسط ادمین قابل مدیریت می باشد.برای استقرار پروژه از کوبرنیتز استفاده شده است تا مقیاس پذیری آن در بارکاری زیاد تضمین شود",
                            Image = "coronavirus.png",
                            ImageDescription = "وبسایت مدیریت آمار کرونا",
                            Link = "https://github.com/urmiaking/news-front-end",
                            Technologies = "C#,ASP.NET Core,MVC,Web API,Docker,Microservice,Kubernetes",
                            Title = "پیاده سازی وبسایت مدیریت آمار کرونا با معماری میکروسرویس",
                            WorkSampleId = 5
                        },
                        new
                        {
                            Id = 6,
                            Description = "در این پروژه با استفاده از پلتفرم ASP.NET Core سعی شده است تمامی قابلیت های سایت تاپ لرن پیاده سازی شود.این وبسایت جهت خرید دوره های برنامه نویسی طراحی شده است.پروژه در دست ساخت است و سعی شده است در آن از معماری لایه بندی، معماری تمیز و IoC استفاده شود",
                            Image = "toplearn-modal.png",
                            ImageDescription = "وبسایت تاپ لرن",
                            Link = "https://github.com/urmiaking/TopLearn",
                            Technologies = "C#,ASP.NET Core,MVC,Razor Page,Javascript",
                            Title = "پیاده سازی وبسایتی مشابه سایت تاپ لرن",
                            WorkSampleId = 6
                        },
                        new
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
                });

            modelBuilder.Entity("PersonalWebsite.Models.Education", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CollegeName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DegreeTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Duration")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Educations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CollegeName = "دبیرستان شاهد",
                            DegreeTitle = "دیپلم ریاضی و فیزیک",
                            Description = "دریچه های علم در دبیرستان شاهد شهید آهندوست به روی من گشوده شد. من در این دبیرستان رشته ریاضی و فیزیک را گذرانده و مدرک دیپلم خود را با معدل ۱۹ کسب کرده ام.",
                            Duration = "۱۳۹۱-۱۳۹۵"
                        },
                        new
                        {
                            Id = 2,
                            CollegeName = "دانشگاه ارومیه",
                            DegreeTitle = "کارشناسی مهندسی کامپیوتر",
                            Description = "دانشگاه ارومیه، راه رسیدن به جایگاهی که هم اکنون در آن قرار دارم را هموار کرد. به لطف مدد الهی، دوران کارشناسی خود را با موفقیت گذرانده و موفق به کسب مقام اول با معدل ۱۸.۲۱ در رشته مهندسی کامپیوتر شده ام.",
                            Duration = "۱۳۹۵-۱۳۹۹"
                        },
                        new
                        {
                            Id = 3,
                            CollegeName = "دانشگاه ارومیه",
                            DegreeTitle = "کارشناسی ارشد مهندسی نرم افزار",
                            Description = "جهت تکمیل علم و دانش خود، قصد ادامه تحصیل در رشته مهندسی نرم افزار در دانشگاه ارومیه را دارم. امسال در کنکور ارشد شرکت کرده ام و انشالله نتیجه آن به زودی اعلام میگردد.",
                            Duration = "۱۳۹۹-..."
                        });
                });

            modelBuilder.Entity("PersonalWebsite.Models.Experience", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Duration")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("GreenTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Experiences");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Duration = "۱۳۹۷",
                            GreenTitle = "اسکای نیک",
                            Title = "پیاده سازی سوکت سرور در شرکت"
                        },
                        new
                        {
                            Id = 2,
                            Duration = "۱۳۹۸-۱۳۹۹",
                            GreenTitle = "کلینیک بهار",
                            Title = "پیاده سازی سیستمی برای"
                        },
                        new
                        {
                            Id = 3,
                            Duration = "۱۳۹۹",
                            GreenTitle = "میکروسرویس",
                            Title = "پیاده سازی سایت خبری با معماری"
                        });
                });

            modelBuilder.Entity("PersonalWebsite.Models.ExperienceTool", b =>
                {
                    b.Property<int>("ExperienceId")
                        .HasColumnType("int");

                    b.Property<int>("ToolId")
                        .HasColumnType("int");

                    b.HasKey("ExperienceId", "ToolId");

                    b.HasIndex("ToolId");

                    b.ToTable("ExperienceTool");

                    b.HasData(
                        new
                        {
                            ExperienceId = 1,
                            ToolId = 1
                        },
                        new
                        {
                            ExperienceId = 1,
                            ToolId = 2
                        },
                        new
                        {
                            ExperienceId = 2,
                            ToolId = 3
                        },
                        new
                        {
                            ExperienceId = 2,
                            ToolId = 4
                        },
                        new
                        {
                            ExperienceId = 3,
                            ToolId = 5
                        },
                        new
                        {
                            ExperienceId = 3,
                            ToolId = 6
                        });
                });

            modelBuilder.Entity("PersonalWebsite.Models.PersonalSkill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Progress")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PersonalSkills");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Progress = 80,
                            Title = "ارتباطات خوب"
                        },
                        new
                        {
                            Id = 2,
                            Progress = 95,
                            Title = "برنامه ریزی منظم"
                        },
                        new
                        {
                            Id = 3,
                            Progress = 90,
                            Title = "مدیریت پروژه"
                        },
                        new
                        {
                            Id = 4,
                            Progress = 70,
                            Title = "کار تیمی"
                        });
                });

            modelBuilder.Entity("PersonalWebsite.Models.TechnicalSkill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Progress")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TechnicalSkills");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Progress = 86,
                            Title = "#C"
                        },
                        new
                        {
                            Id = 2,
                            Progress = 74,
                            Title = "NET."
                        },
                        new
                        {
                            Id = 3,
                            Progress = 90,
                            Title = "NET Core."
                        },
                        new
                        {
                            Id = 4,
                            Progress = 53,
                            Title = "Java"
                        },
                        new
                        {
                            Id = 5,
                            Progress = 46,
                            Title = "Javascript"
                        });
                });

            modelBuilder.Entity("PersonalWebsite.Models.Technology", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AboutMeId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AboutMeId");

                    b.ToTable("Technologies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AboutMeId = 1,
                            Title = "NET."
                        },
                        new
                        {
                            Id = 2,
                            AboutMeId = 1,
                            Title = "Java"
                        },
                        new
                        {
                            Id = 3,
                            AboutMeId = 1,
                            Title = "#C"
                        },
                        new
                        {
                            Id = 4,
                            AboutMeId = 1,
                            Title = "SQL Server"
                        },
                        new
                        {
                            Id = 5,
                            AboutMeId = 1,
                            Title = "Javascript"
                        },
                        new
                        {
                            Id = 6,
                            AboutMeId = 1,
                            Title = "Oracle SQL"
                        },
                        new
                        {
                            Id = 7,
                            AboutMeId = 1,
                            Title = "MySQL"
                        },
                        new
                        {
                            Id = 8,
                            AboutMeId = 1,
                            Title = "Docker"
                        },
                        new
                        {
                            Id = 9,
                            AboutMeId = 1,
                            Title = "Microservices"
                        },
                        new
                        {
                            Id = 10,
                            AboutMeId = 1,
                            Title = "Kubernetes"
                        },
                        new
                        {
                            Id = 11,
                            AboutMeId = 1,
                            Title = "Web API"
                        },
                        new
                        {
                            Id = 12,
                            AboutMeId = 1,
                            Title = "Clean Code"
                        },
                        new
                        {
                            Id = 13,
                            AboutMeId = 1,
                            Title = "C"
                        },
                        new
                        {
                            Id = 14,
                            AboutMeId = 1,
                            Title = "++C"
                        },
                        new
                        {
                            Id = 15,
                            AboutMeId = 1,
                            Title = "HTML"
                        },
                        new
                        {
                            Id = 16,
                            AboutMeId = 1,
                            Title = "Python"
                        });
                });

            modelBuilder.Entity("PersonalWebsite.Models.Tool", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tools");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Java, Socket programming"
                        },
                        new
                        {
                            Id = 2,
                            Name = "HTML, CSS, JS, PHP, MySQL"
                        },
                        new
                        {
                            Id = 3,
                            Name = "ASP.NET Core 3.1"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Docker & Kubernetes"
                        },
                        new
                        {
                            Id = 5,
                            Name = "ASP.NET Core 3.1 MVC and Web API"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Docker, Kubernetes, Microservice architecture"
                        });
                });

            modelBuilder.Entity("PersonalWebsite.Models.WorkSample", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreateDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("WorkSamples");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreateDateTime = new DateTime(2020, 8, 29, 2, 30, 32, 848, DateTimeKind.Local).AddTicks(6469),
                            Image = "clinic.jpg",
                            Title = "کلینیک فوق تخصصی بهار"
                        },
                        new
                        {
                            Id = 2,
                            CreateDateTime = new DateTime(2020, 8, 29, 2, 30, 32, 851, DateTimeKind.Local).AddTicks(9355),
                            Image = "docker.png",
                            Title = "وبسایت خبری"
                        },
                        new
                        {
                            Id = 3,
                            CreateDateTime = new DateTime(2020, 8, 29, 2, 30, 32, 851, DateTimeKind.Local).AddTicks(9413),
                            Image = "airlink-smart-hub.jpg",
                            Title = "سرور اسکای نیک"
                        },
                        new
                        {
                            Id = 4,
                            CreateDateTime = new DateTime(2020, 8, 29, 2, 30, 32, 851, DateTimeKind.Local).AddTicks(9420),
                            Image = "machine-learning.png",
                            Title = "یادگیری ماشین"
                        },
                        new
                        {
                            Id = 5,
                            CreateDateTime = new DateTime(2020, 8, 29, 2, 30, 32, 851, DateTimeKind.Local).AddTicks(9424),
                            Image = "corona.png",
                            Title = "وبسایت مدیریت آمار کرونا"
                        },
                        new
                        {
                            Id = 6,
                            CreateDateTime = new DateTime(2020, 8, 29, 2, 30, 32, 851, DateTimeKind.Local).AddTicks(9428),
                            Image = "toplearn.png",
                            Title = "وبسایت تاپ لرن"
                        },
                        new
                        {
                            Id = 7,
                            CreateDateTime = new DateTime(2020, 8, 29, 2, 30, 32, 851, DateTimeKind.Local).AddTicks(9432),
                            Image = "university.jpg",
                            Title = "سیستم دانشگاه"
                        });
                });

            modelBuilder.Entity("PersonalWebsite.Models.WorkSampleCategory", b =>
                {
                    b.Property<int>("WorkSampleId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.HasKey("WorkSampleId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("WorkSampleCategories");

                    b.HasData(
                        new
                        {
                            WorkSampleId = 1,
                            CategoryId = 1
                        },
                        new
                        {
                            WorkSampleId = 2,
                            CategoryId = 1
                        },
                        new
                        {
                            WorkSampleId = 2,
                            CategoryId = 4
                        },
                        new
                        {
                            WorkSampleId = 3,
                            CategoryId = 2
                        },
                        new
                        {
                            WorkSampleId = 4,
                            CategoryId = 3
                        },
                        new
                        {
                            WorkSampleId = 5,
                            CategoryId = 1
                        },
                        new
                        {
                            WorkSampleId = 5,
                            CategoryId = 4
                        },
                        new
                        {
                            WorkSampleId = 6,
                            CategoryId = 1
                        },
                        new
                        {
                            WorkSampleId = 7,
                            CategoryId = 1
                        });
                });

            modelBuilder.Entity("PersonalWebsite.Models.Detail", b =>
                {
                    b.HasOne("PersonalWebsite.Models.WorkSample", "WorkSample")
                        .WithOne("Detail")
                        .HasForeignKey("PersonalWebsite.Models.Detail", "WorkSampleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PersonalWebsite.Models.ExperienceTool", b =>
                {
                    b.HasOne("PersonalWebsite.Models.Experience", "Experience")
                        .WithMany("ExperienceTools")
                        .HasForeignKey("ExperienceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PersonalWebsite.Models.Tool", "Tool")
                        .WithMany("ExperienceTools")
                        .HasForeignKey("ToolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PersonalWebsite.Models.Technology", b =>
                {
                    b.HasOne("PersonalWebsite.Models.AboutMe", "AboutMe")
                        .WithMany("Technologies")
                        .HasForeignKey("AboutMeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PersonalWebsite.Models.WorkSampleCategory", b =>
                {
                    b.HasOne("PersonalWebsite.Models.Category", "Category")
                        .WithMany("WorkSampleCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PersonalWebsite.Models.WorkSample", "WorkSample")
                        .WithMany("WorkSampleCategories")
                        .HasForeignKey("WorkSampleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
