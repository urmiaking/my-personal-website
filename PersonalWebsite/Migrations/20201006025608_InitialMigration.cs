using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalWebsite.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AboutMe",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: false),
                    Image = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutMe", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BlogCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Group = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClientVisits",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IpAddress = table.Column<string>(nullable: true),
                    DateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientVisits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactForms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    EmailAddress = table.Column<string>(nullable: false),
                    Message = table.Column<string>(nullable: false),
                    DateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactForms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactMe",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactMe", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Educations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DegreeTitle = table.Column<string>(nullable: true),
                    CollegeName = table.Column<string>(nullable: true),
                    Duration = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Educations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Experiences",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    GreenTitle = table.Column<string>(nullable: true),
                    Duration = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experiences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MailServers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServerAddress = table.Column<string>(nullable: true),
                    HostAddress = table.Column<string>(nullable: true),
                    Port = table.Column<int>(nullable: false),
                    Password = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MailServers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PersonalSkills",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Progress = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonalSkills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SiteAdmins",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    ResetPasswordCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteAdmins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TechnicalSkills",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Progress = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TechnicalSkills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tools",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tools", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkSamples",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    CreateDateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkSamples", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Technologies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    AboutMeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technologies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Technologies_AboutMe_AboutMeId",
                        column: x => x.AboutMeId,
                        principalTable: "AboutMe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 200, nullable: false),
                    ShortDescription = table.Column<string>(maxLength: 500, nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Author = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(maxLength: 200, nullable: true),
                    DateTime = table.Column<DateTime>(nullable: false),
                    Tags = table.Column<string>(nullable: false),
                    ViewCount = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Blogs_BlogCategories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "BlogCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExperienceTool",
                columns: table => new
                {
                    ExperienceId = table.Column<int>(nullable: false),
                    ToolId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExperienceTool", x => new { x.ExperienceId, x.ToolId });
                    table.ForeignKey(
                        name: "FK_ExperienceTool_Experiences_ExperienceId",
                        column: x => x.ExperienceId,
                        principalTable: "Experiences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExperienceTool_Tools_ToolId",
                        column: x => x.ToolId,
                        principalTable: "Tools",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Details",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Technologies = table.Column<string>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    ImageDescription = table.Column<string>(nullable: true),
                    Link = table.Column<string>(nullable: true),
                    WorkSampleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Details", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Details_WorkSamples_WorkSampleId",
                        column: x => x.WorkSampleId,
                        principalTable: "WorkSamples",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkSampleCategories",
                columns: table => new
                {
                    WorkSampleId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkSampleCategories", x => new { x.WorkSampleId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_WorkSampleCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WorkSampleCategories_WorkSamples_WorkSampleId",
                        column: x => x.WorkSampleId,
                        principalTable: "WorkSamples",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AboutMe",
                columns: new[] { "Id", "Description", "Image" },
                values: new object[] { 1, "من، مسعود خدادادی، فارغ التحصیل رشته مهندسی کامپیوتر از دانشگاه ارومیه هستم. به طور حرفه ای در زمینه برنامه نویسی سمت سرور با زبان سی شارپ فعالیت می کنم و برنامه های تحت وب با پلتفرم ASP.Net Core توسعه می دهم. من همچنین در زمینه های زیر تجربه و مهارت دارم:", "dotnet.jpg" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Group" },
                values: new object[,]
                {
                    { 1, 0 },
                    { 2, 3 },
                    { 3, 1 },
                    { 4, 2 }
                });

            migrationBuilder.InsertData(
                table: "ContactMe",
                columns: new[] { "Id", "Address", "EmailAddress", "PhoneNumber" },
                values: new object[] { 1, "آذربایجان غربی، ارومیه، مدرس", "masoud.xpress@gmail.com", "+989382017559" });

            migrationBuilder.InsertData(
                table: "Educations",
                columns: new[] { "Id", "CollegeName", "DegreeTitle", "Description", "Duration" },
                values: new object[,]
                {
                    { 1, "دبیرستان شاهد", "دیپلم ریاضی و فیزیک", "دریچه های علم در دبیرستان شاهد شهید آهندوست به روی من گشوده شد. من در این دبیرستان رشته ریاضی و فیزیک را گذرانده و مدرک دیپلم خود را با معدل ۱۹ کسب کرده ام.", "۱۳۹۱-۱۳۹۵" },
                    { 2, "دانشگاه ارومیه", "کارشناسی مهندسی کامپیوتر", "دانشگاه ارومیه، راه رسیدن به جایگاهی که هم اکنون در آن قرار دارم را هموار کرد. به لطف مدد الهی، دوران کارشناسی خود را با موفقیت گذرانده و موفق به کسب مقام اول با معدل 18.09 در رشته مهندسی کامپیوتر شده ام.", "۱۳۹۵-۱۳۹۹" },
                    { 3, "دانشگاه ارومیه", "کارشناسی ارشد مهندسی نرم افزار", "جهت تکمیل علم و دانش خود، قصد ادامه تحصیل در رشته مهندسی نرم افزار در دانشگاه ارومیه را دارم. امسال در کنکور ارشد شرکت کرده ام و انشالله نتیجه آن به زودی اعلام میگردد.", "۱۳۹۹-..." }
                });

            migrationBuilder.InsertData(
                table: "Experiences",
                columns: new[] { "Id", "Duration", "GreenTitle", "Title" },
                values: new object[,]
                {
                    { 1, "۱۳۹۷", "اسکای نیک", "پیاده سازی سوکت سرور در شرکت" },
                    { 2, "۱۳۹۸-۱۳۹۹", "کلینیک بهار", "پیاده سازی سیستمی برای" },
                    { 3, "۱۳۹۹", "میکروسرویس", "پیاده سازی سایت خبری با معماری" }
                });

            migrationBuilder.InsertData(
                table: "MailServers",
                columns: new[] { "Id", "HostAddress", "Password", "Port", "ServerAddress", "Type" },
                values: new object[] { 1, "smtp.gmail.com", "MASOUD7559", 587, "masoud.xpress@gmail.com", null });

            migrationBuilder.InsertData(
                table: "PersonalSkills",
                columns: new[] { "Id", "Progress", "Title" },
                values: new object[,]
                {
                    { 3, 90, "مدیریت پروژه" },
                    { 2, 95, "برنامه ریزی منظم" },
                    { 4, 70, "کار تیمی" },
                    { 1, 70, "زبان انگلیسی" }
                });

            migrationBuilder.InsertData(
                table: "SiteAdmins",
                columns: new[] { "Id", "Email", "FullName", "Password", "ResetPasswordCode" },
                values: new object[] { 1, "masoud.xpress@gmail.com", "مسعود خدادادی", "f1ac294f56ceb706e90dd1719934c3ae444431483a2857bb001289f7d5acc0bb", "" });

            migrationBuilder.InsertData(
                table: "TechnicalSkills",
                columns: new[] { "Id", "Progress", "Title" },
                values: new object[,]
                {
                    { 1, 86, "#C" },
                    { 2, 74, "NET." },
                    { 3, 90, "NET Core." },
                    { 4, 53, "Java" },
                    { 5, 46, "Javascript" }
                });

            migrationBuilder.InsertData(
                table: "Tools",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 6, "Docker, Kubernetes, Microservice architecture" },
                    { 5, "ASP.NET Core 3.1 MVC and Web API" },
                    { 4, "Docker & Kubernetes" },
                    { 3, "ASP.NET Core 3.1" },
                    { 1, "Java, Socket programming" },
                    { 2, "HTML, CSS, JS, PHP, MySQL" }
                });

            migrationBuilder.InsertData(
                table: "WorkSamples",
                columns: new[] { "Id", "CreateDateTime", "Image", "Title" },
                values: new object[,]
                {
                    { 6, new DateTime(2020, 10, 6, 6, 26, 8, 24, DateTimeKind.Local).AddTicks(9785), "toplearn.png", "وبسایت تاپ لرن" },
                    { 1, new DateTime(2020, 10, 6, 6, 26, 8, 21, DateTimeKind.Local).AddTicks(6503), "clinic.jpg", "کلینیک فوق تخصصی بهار" },
                    { 2, new DateTime(2020, 10, 6, 6, 26, 8, 24, DateTimeKind.Local).AddTicks(9706), "docker.png", "وبسایت خبری" },
                    { 3, new DateTime(2020, 10, 6, 6, 26, 8, 24, DateTimeKind.Local).AddTicks(9770), "airlink-smart-hub.jpg", "سرور اسکای نیک" },
                    { 4, new DateTime(2020, 10, 6, 6, 26, 8, 24, DateTimeKind.Local).AddTicks(9777), "machine-learning.png", "یادگیری ماشین" },
                    { 5, new DateTime(2020, 10, 6, 6, 26, 8, 24, DateTimeKind.Local).AddTicks(9782), "corona.png", "وبسایت مدیریت آمار کرونا" },
                    { 7, new DateTime(2020, 10, 6, 6, 26, 8, 24, DateTimeKind.Local).AddTicks(9789), "university.jpg", "سیستم دانشگاه" }
                });

            migrationBuilder.InsertData(
                table: "Details",
                columns: new[] { "Id", "Description", "Image", "ImageDescription", "Link", "Technologies", "Title", "WorkSampleId" },
                values: new object[,]
                {
                    { 6, "در این پروژه با استفاده از پلتفرم ASP.NET Core سعی شده است تمامی قابلیت های سایت تاپ لرن پیاده سازی شود.این وبسایت جهت خرید دوره های برنامه نویسی طراحی شده است.پروژه در دست ساخت است و سعی شده است در آن از معماری لایه بندی، معماری تمیز و IoC استفاده شود", "toplearn-modal.png", "وبسایت تاپ لرن", "https://github.com/urmiaking/TopLearn", "C#,ASP.NET Core,MVC,Razor Page,Javascript", "پیاده سازی وبسایتی مشابه سایت تاپ لرن", 6 },
                    { 5, "در این پروژه، وبسایتی با پتلفرم ASP.NET Core پیاده سازی شده است که آمار کرونا در آن با استفاده های API ها دریافت شده و توسط ادمین قابل مدیریت می باشد.برای استقرار پروژه از کوبرنیتز استفاده شده است تا مقیاس پذیری آن در بارکاری زیاد تضمین شود", "coronavirus.png", "وبسایت مدیریت آمار کرونا", "https://github.com/urmiaking/news-front-end", "C#,ASP.NET Core,MVC,Web API,Docker,Microservice,Kubernetes", "پیاده سازی وبسایت مدیریت آمار کرونا با معماری میکروسرویس", 5 },
                    { 4, "در این پروژه، با استفاده از دو الگوریتم SVM و Naive Bayse مدل های یادگیری ماشین برای پیش بینی عنوان خبر از روی متن آن ساخته شده است.این پروژه، ۱۵۰۰ خبر به عنوان تست دریافت کرده و عمل یادگیری را آغاز می کند.پس از اتمام یادگیری با استفاده از ۵۰۰ داده تست، کارایی آن ارزیابی می گردد.کارایی و دقت این مدل ها حداکثر به ۸۵ درصد می رسد.", "machine-learning-model.png", "پیش بینی چهار دسته خبری از روی متن خبر", "https://github.com/urmiaking/TextClassificationNBSVM", "Python,Machine Learning,SVM,Naive Bayse,Text Classification", "پیاده سازی مدلی جهت پیش بینی موضوع خبر از روی متن آن", 4 },
                    { 3, "این پروژه، با همکاری شرکت آسمان الکترونیک اسپوتا(اسکای نیک)برای مدیریت دستگاه های هوشمند از طریق گوشی هوشمند ساخته شده است.دستگاه های هوشمندی که این شرکت به تولید رسانده است کاملا بومی بوده و توسط دستگاهی به نام 'هاب'مدیریت می شوند.سرور مورد نظر با استفاده از سوکت های TCP دستورات مختلف را از دستگاه های هوشمند به تلفن های هوشمند منتقل می کند.کاربر در هر جایی می تواند به سرور متصل شده و لوازم هوشمند خانه خود را کنترل کند.برای این پروژه پنل ادمین نیز جهت مدیریت هاب ها و مشاهده آمار کاربران ساخته شده است", "skynic-server.png", "", "https://github.com/urmiaking/SkynicServer", "Java,Socket Programming,Skynic,PHP,MySQL,Javascript", "پیاده سازی سروری برای مدیریت دستگاه های هوشمند", 3 },
                    { 2, "این پروژه برای درس رایانش ابری ارائه شده است.در این پروژه، وبسایتی با پلتفرم ASP.NET Core پیاده سازی شده است که بخش های مختلف آن به صورت جدا در پروژه ای دیگر ساخته شده اند و API هایی را برای برنامه اصلی ارائه می کنند.بدین ترتیب، بار کاری بین قسمت های مختلف تقسیم می شود و وبسایت برای درخواست های زیاد به مشکل نخواهد خورد.در این پروژه برای مدیریت API ها و پروژه و همچنین تضمین مقیاس پذیری و سرویس دهی ۲۴ ساعته سرور، از از کوبرنیتز استفاده شده است", "news-microservice.png", "معماری میکروسرویس پروژه وبسایت خبری", "https://github.com/urmiaking/news-front-end", "C#,ASP.NET Core,MVC,Web API,Docker,Microservice,Kubernetes", "پیاده سازی وبسایت خبری با معماری میکروسرویس", 2 },
                    { 1, "در این پروژه، برنامه ای تحت وب با پلتفرم ASP.NET Core برای کلینیکی با عنوان 'کلینیک فوق تخصصی بهار' پیاده سازی شده است.بیماران کلینیک می توانند با استفاده از این برنامه با پزشک مورد نظر خود، وقت ملاقات رزرو کنند، نسخه های خود را مشاهده کنند و در صورت تمایل هزینه ی آن را به صورت آنلاین پرداخت کنند و با پزشکانی که به آن ها مراجعه کرده اند، گفت وگوی آنلاین انجام دهند.همچنین این برنامه به پزشکان کمک خواهد کرد تا اطلاعات ویزیت را ذخیره کرده و نسخه های بیماران را به طور آنلاین به داروخانه‌ی کلینیک صادر کنند.مسئول داروخانه، وظیفه ی مدیریت داروها و تحویل نسخه های صادره از سوی پزشکان به بیماران را دارد.دو مدیر برای برنامه تعیین شده است؛ مدیر سایت که وظیفه ی تولید محتوای صفحه اصلی کلینیک را دارد و مدیر کلینیک نیز می تواند پزشکان را در سیستم ثبت نام کرده، آمار کلی کلینیک را مشاهده کند و همچنین به رسیدگی به شکایات بیماران بپردازد.خروجی نهایی با استفاده از داکر به فایل ایمیج تبدیل شده که در تمامی سیستم عامل ها قابل اجرا می باشد و برای اتوماسیون استقرار، مدیریت و مقیاس پذیری برنامه از کوبرنیتز استفاده می شود.", "bahar-clinic.png", "وبسایت کلینیک فوق تخصصی بهار", "https://github.com/urmiaking/Clinic", "C#,ASP.NET Core,MVC,Docker,SignalR,Kubernetes", "پیاده سازی وبسایتی برای کلینیک فوق تخصصی بهار", 1 },
                    { 7, "این پروژه برای درس پایگاه داده با زبان سی شارپ و با پلتفرم ویندوز فرم ساخته شده است.اطلاعات دانشجویان اساتید و مسئول دانشگاه در پایگاه داده ذخیره می شود و امکان بکاپ گیری و بازیابی پایگاه داده وجود دارد.", "", "", "", "C#,.NET Framework,WinForms,SQL Server,ADO.NET", "پیاده سازی برنامه تحت دسکتاپ برای دانشگاه", 7 }
                });

            migrationBuilder.InsertData(
                table: "ExperienceTool",
                columns: new[] { "ExperienceId", "ToolId" },
                values: new object[,]
                {
                    { 2, 3 },
                    { 3, 6 },
                    { 3, 5 },
                    { 2, 4 },
                    { 1, 2 },
                    { 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "Technologies",
                columns: new[] { "Id", "AboutMeId", "Title" },
                values: new object[,]
                {
                    { 17, 1, "ML.NET" },
                    { 16, 1, "Python" },
                    { 1, 1, "NET." },
                    { 14, 1, "++C" },
                    { 4, 1, "SQL Server" },
                    { 5, 1, "Javascript" },
                    { 15, 1, "HTML" },
                    { 2, 1, "Java" },
                    { 6, 1, "Oracle SQL" },
                    { 7, 1, "MySQL" },
                    { 3, 1, "#C" },
                    { 9, 1, "Microservices" },
                    { 10, 1, "Kubernetes" },
                    { 11, 1, "Web API" },
                    { 12, 1, "Clean Code" },
                    { 13, 1, "C" },
                    { 8, 1, "Docker" }
                });

            migrationBuilder.InsertData(
                table: "WorkSampleCategories",
                columns: new[] { "WorkSampleId", "CategoryId" },
                values: new object[,]
                {
                    { 5, 1 },
                    { 5, 4 },
                    { 6, 1 },
                    { 2, 4 },
                    { 3, 2 },
                    { 2, 1 },
                    { 1, 1 },
                    { 4, 3 },
                    { 7, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_CategoryId",
                table: "Blogs",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Details_WorkSampleId",
                table: "Details",
                column: "WorkSampleId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExperienceTool_ToolId",
                table: "ExperienceTool",
                column: "ToolId");

            migrationBuilder.CreateIndex(
                name: "IX_Technologies_AboutMeId",
                table: "Technologies",
                column: "AboutMeId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkSampleCategories_CategoryId",
                table: "WorkSampleCategories",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "ClientVisits");

            migrationBuilder.DropTable(
                name: "ContactForms");

            migrationBuilder.DropTable(
                name: "ContactMe");

            migrationBuilder.DropTable(
                name: "Details");

            migrationBuilder.DropTable(
                name: "Educations");

            migrationBuilder.DropTable(
                name: "ExperienceTool");

            migrationBuilder.DropTable(
                name: "MailServers");

            migrationBuilder.DropTable(
                name: "PersonalSkills");

            migrationBuilder.DropTable(
                name: "SiteAdmins");

            migrationBuilder.DropTable(
                name: "TechnicalSkills");

            migrationBuilder.DropTable(
                name: "Technologies");

            migrationBuilder.DropTable(
                name: "WorkSampleCategories");

            migrationBuilder.DropTable(
                name: "BlogCategories");

            migrationBuilder.DropTable(
                name: "Experiences");

            migrationBuilder.DropTable(
                name: "Tools");

            migrationBuilder.DropTable(
                name: "AboutMe");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "WorkSamples");
        }
    }
}
