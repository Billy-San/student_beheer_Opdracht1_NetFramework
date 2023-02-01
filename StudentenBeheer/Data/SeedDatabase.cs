using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using StudentenBeheer.Areas.Identity.Data;
using StudentenBeheer.Models;

namespace StudentenBeheer.Data
{

    public static class SeedDatabase
    {

        public static void Initialize(IServiceProvider serviceProvider, UserManager<ApplicationUser> userManager)
        {
            using (var context = new ApplicationContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationContext>>()))
            {
                ApplicationUser user = null;
                context.Database.EnsureCreated();

                if (!context.Users.Any())
                {
                    user = new ApplicationUser
                    {
                        UserName = "Admin",
                        Firstname = "Antoine",
                        Lastname = "Couck",
                        Email = "System.administrator@studentenbeheer.be",
                        EmailConfirmed = true
                    };

                    userManager.CreateAsync(user, "Abc!98765");
                }

                if (!context.Roles.Any())
                {

                    context.Roles.AddRange(

                            new IdentityRole { Id = "User", Name = "User", NormalizedName = "user" },
                            new IdentityRole { Id = "Admin", Name = "Admin", NormalizedName = "admin" }

                            );

                    context.SaveChanges();
                }


                if (!context.Gender.Any() || !(context.Student.Any()))
                {
                    // DB has been seeded
                    context.Gender.AddRange(

                       new Gender
                       {

                           ID = 'M',
                           Name = "Man"


                       },

                       new Gender
                       {

                           ID = 'V',
                           Name = "Vrouw"

                          
                       },

                       new Gender
                       {
                           ID = 'X',
                           Name = ""
                       }

                   );
                    context.SaveChanges();

                    context.Student.AddRange(

                               new Student
                               {
                                   Name = "Bakkali",
                                   Lastname = "Bilal",
                                   Birthday = DateTime.Now,
                                   GenderId = 'M',
                                   Deleted = DateTime.MaxValue


                               },
                               new Student
                               {
                                   Name = "cindy",
                                   Lastname = "Bak",
                                   Birthday = DateTime.Now,
                                   GenderId = 'F',
                                   Deleted = DateTime.Now


                               },
                                 new Student
                                 {
                                     Name = "Didi",
                                     Lastname = "Do",
                                     Birthday = DateTime.Now,
                                     GenderId = 'F',
                                     Deleted = DateTime.MaxValue


                                 },
                                   new Student
                                   {
                                       Name = "Soso",
                                       Lastname = "sas",
                                       Birthday = DateTime.Now,
                                       GenderId = 'F',
                                       Deleted = DateTime.MaxValue


                                   }
                        );
                    context.SaveChanges();

                }

                if (!context.Module.Any())
                {
                    context.Module.AddRange(

                    new Module
                    {
                        Name = "Backend web",
                        Omschrijving = "Laravel, Php,...",
                        Deleted = DateTime.MaxValue
                    },
                     new Module
                     {
                         Name = "Dynamic web",
                         Omschrijving = "Web design, met taal JavaScript",
                         Deleted = DateTime.Now
                     },
                      new Module
                      {
                          Name = "OS fundamentals",
                          Omschrijving = "Windows server, Linux",
                          Deleted = DateTime.MaxValue
                      }

                    );

                    context.SaveChanges();

                }


                if (user != null)
                {
                    context.UserRoles.AddRange(

                        new IdentityUserRole<string> { UserId = user.Id, RoleId = "Admin" }
                        //new IdentityUserRole<string> { UserId = user.Id, RoleId = "User" }

                        );

                    context.SaveChanges();
                }


            }
          


        }
    }

}

