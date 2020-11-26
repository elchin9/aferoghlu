using Aferoglu.Models;
using Aferoglu.Utilities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aferoglu.DAL
{
    public class DbInitializer
    {
        public static async Task Seed(AferogluDbContext context,
            UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            await context.Database.EnsureCreatedAsync();
            if (!await roleManager.RoleExistsAsync(StaticUsers.Admin))
            {
                await roleManager.CreateAsync(new IdentityRole(StaticUsers.Admin));
            }

            if (!await roleManager.RoleExistsAsync(StaticUsers.Member))
            {
                await roleManager.CreateAsync(new IdentityRole(StaticUsers.Member));
            }

            if (await userManager.FindByNameAsync("Admin") == null)
            {
                var ourTeam = new List<OurTeam>();
                ourTeam.Add(new OurTeam
                {
                    PhotoURL = "gallery-1.jpg"
                });
                ourTeam.Add(new OurTeam
                {
                    PhotoURL = "gallery-2.jpg"
                });
                ourTeam.Add(new OurTeam
                {
                    PhotoURL = "gallery-3.jpg"
                });
                context.OurTeam.AddRange(ourTeam);
                await context.SaveChangesAsync();

                var lang = new List<Lang>();
             
                lang.Add(new Lang
                {
                    Name = "Rus Dili",
                    Code = "RU"

                });
                lang.Add(new Lang
                {
                    Name = "Ingilis Dili",
                    Code = "EN"
                });
                lang.Add(new Lang
                {
                    Name = "Azərbaycan Dili",
                    Code = "AZ"
                });

                context.Langs.AddRange(lang);
                await context.SaveChangesAsync();

                var ourTeamLang = new List<OurTeamLang>();
                ourTeamLang.Add(new OurTeamLang
                {
                    FullName = "Müasir Dizayn",
                    Profession = "Yüksək keyfiyyətli avadanlıqlar, təcrübəli və kreativ mütəxəssislər tərəfindən dizayn edilən məhsullarımız xidmətinizdədir.",
                    OurTeamId = 1,
                    LangId = 1
                });
                ourTeamLang.Add(new OurTeamLang
                {
                    FullName = "Modern Design",
                    Profession = "Our products, designed by high quality equipment, experienced and creative professionals, are at your service.",
                    OurTeamId = 1,
                    LangId = 2
                });
                ourTeamLang.Add(new OurTeamLang
                {
                    FullName = "Современный дизайн",
                    Profession = "К вашим услугам наша продукция, созданная на высококачественном оборудовании, опытные и креативные профессионалы.",
                    OurTeamId = 1,
                    LangId = 3
                });
                ourTeamLang.Add(new OurTeamLang
                {
                    FullName = "Çatdırılma və quraşdırılma",
                    Profession = "Keyfiyyəti və müasirliyi ilə yanaşı mebellərin alındığı məkandan sifarişçinin göstərdiyi ünvana çatdırılması və quraşdırılması pulsuz şəkildə həyata keçirilir. ",
                    OurTeamId = 2,
                    LangId = 1
                });
                ourTeamLang.Add(new OurTeamLang
                {
                    FullName = "Delivery and installation.",
                    Profession = "Along with the quality and modernity, delivery and installation of furniture from the place of purchase to the address indicated by the customer is free of charge.",
                    OurTeamId = 2,
                    LangId = 2
                });
                ourTeamLang.Add(new OurTeamLang
                {
                    FullName = "Доставка и установка.",
                    Profession = "Наряду с качеством и современностью, доставка и установка мебели от места покупки по указанному заказчиком адресу осуществляется бесплатно.",
                    OurTeamId = 2,
                    LangId = 3
                });
                ourTeamLang.Add(new OurTeamLang
                {
                    FullName = "Ofisiniz üçün ən yaxşısı",
                    Profession = "Keyfiyyət öndə olmaqla xəyalınızdakı ofisi yaratmaq və sizin üçün daha rahat tərzə gətirmək üçün çalışırıq.",
                    OurTeamId = 3,
                    LangId = 1
                });
                ourTeamLang.Add(new OurTeamLang
                {
                    FullName = "Best for your office",
                    Profession = "We strive to create the office of your dreams with quality in mind and bring a more comfortable style for you.",
                    OurTeamId = 3,
                    LangId = 2
                });
                ourTeamLang.Add(new OurTeamLang
                {
                    FullName = "Лучшее для вашего офиса",
                    Profession = "Мы стремимся создать офис вашей мечты, заботясь о качестве и предлагая вам более комфортный стиль.",
                    OurTeamId = 3,
                    LangId = 3
                });

                context.OurTeamLangs.AddRange(ourTeamLang);

                var about = new About
                {
                    PhotoURL = ""
                };

                await context.About.AddAsync(about);
                await context.SaveChangesAsync();

                var aboutLang = new List<AboutLang>();
                aboutLang.Add(new AboutLang
                {
                    Description = "xgdd",
                    LangId = 1,
                    AboutId = about.Id
                });
                aboutLang.Add(new AboutLang
                {
                    Description = "sdgdf",
                    LangId = 2,
                    AboutId = about.Id
                });
                aboutLang.Add(new AboutLang
                {
                    Description = "sdgdf",
                    LangId = 3,
                    AboutId = about.Id
                });

                context.AboutLang.AddRange(aboutLang);
                await context.SaveChangesAsync();

                var admin = new AppUser()
                {
                    FirstName = "Admin",
                    LastName = "Admin",
                    Email = "ElchinSh@code.edu.az",
                    UserName = "admin",
                };

                var result = await userManager.CreateAsync(admin, "Admin123!");

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, StaticUsers.Admin);
                }
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, StaticUsers.Admin);
                }
            }
        }
    }
}
