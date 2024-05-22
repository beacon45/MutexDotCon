using Microsoft.AspNetCore.Identity;
using MutexDotCom.Data.Constants;
using MutexDotCom.Models;

namespace MutexDotCom.Data.Initializer
{
    public class ApplicationDbInitials
    {
        public static void seeding(IApplicationBuilder app)
        {
            using(var serviceScope=app.ApplicationServices.CreateScope())
            {
                var context=serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

                context.Database.EnsureCreated();
                //Department
                if (!context.Departments.Any())
                {
                    context.Departments.AddRange(new List<Department>()
                    {
                        new Department()
                        {
                            Name="Alphine Dojo",
                            Logo="https://shorturl.at/aquHO",
                            Description="Mature but child of 5"
                        },
                        new Department()
                        {
                            Name="Brad Moxly",
                            Logo="https://shorturl.at/uBLVX",
                            Description="Birdish child"
                        },
                        new Department()
                        {
                            Name="Bad Bunny",
                            Logo="https://shorturl.at/djxH0",
                            Description="Loving carrot"
                        },
                        new Department()
                        {
                            Name="Stray Streets",
                            Logo="https://shorturl.at/cJY68",
                            Description="Big Dog"
                        },
                        new Department()
                        {
                            Name="Sharpin Crox",
                            Logo="https://shorturl.at/chjsN",
                            Description="Legally married"
                        }
                    });
                    context.SaveChanges();
                }
                //Developer
                if (!context.Developers.Any())
                {
                    context.Developers.AddRange(new List<Developer>()
                    {
                        new Developer()
                        {
                            Name="Jeremie Doku",
                            ProfilePictureURL="https://rb.gy/dg7rgz",
                            Skills="Python,ReactJs,NodeJs"
                        },
                        new Developer()
                        {
                            Name="Rob Lucci",
                            ProfilePictureURL="https://rb.gy/e0wedy",
                            Skills="Python,ReactJs,NodeJs"
                        },
                        new Developer()
                        {
                            Name="Ivanko D Sunday",
                            ProfilePictureURL="https://rb.gy/6z68kj",
                            Skills="Python,ReactJs,NodeJs"
                        },
                        new Developer()
                        {
                            Name="Edward Newgate",
                            ProfilePictureURL="https://rb.gy/g81ci8",
                            Skills="Python,ReactJs,NodeJs"
                        },
                        new Developer()
                        {
                            Name="Kobie Mainoo",
                            ProfilePictureURL="https://rb.gy/zrq958",
                            Skills="Python,ReactJs,NodeJs"
                        },

                    });
                    context.SaveChanges();
                }
                //Manager
                if (!context.Managers.Any())
                {
                    context.Managers.AddRange(new List<Manager>()
                    {
                        new Manager()
                        {
                            Name="Kevin Orlando",
                            ProfilePictureURL="https://tinyurl.com/5c2b663a",
                            Description="Passionately dominating"
                        },
                        new Manager()
                        {
                            Name="Dominik Ghosh",
                            ProfilePictureURL="https://tinyurl.com/mxamnphv",
                            Description="Passionately dominating"
                        },
                        new Manager()
                        {
                            Name="Victor Calcao",
                            ProfilePictureURL="https://tinyurl.com/57vsvjtf",
                            Description="Passionately dominating"
                        },
                        new Manager()
                        {
                            Name="Maeve Augustin",
                            ProfilePictureURL="https://tinyurl.com/ydkpab52",
                            Description="Passionately dominating"
                        },
                        new Manager()
                        {
                            Name="Ruby Basak",
                            ProfilePictureURL="https://tinyurl.com/s3k6x9zs",
                            Description="Passionately dominating"
                        },

                    });
                    context.SaveChanges();
                }
                //Projects
                if (!context.Projects.Any())
                {
                    context.Projects.AddRange(new List<Project>()
                    {
                        new Project()
                        {
                            Name="Catlify",
                            ProbelemStatement="To endure cats at heated temperature",
                            ClientName="Nani Majumder",
                            ImageURL="https://tinyurl.com/46zrsp22",
                            InitialDate=DateTime.Now.AddDays(-10),
                            EndDate=DateTime.Now.AddDays(10),
                            DepartmentId=43,
                            ManagerId=43,
                        },
                        new Project()
                        {
                            Name="Vege Pajji",
                            ProbelemStatement="Eat Grass without sugar",
                            ClientName="John Cena",
                            ImageURL="https://tinyurl.com/yc52wfjs",
                            InitialDate=DateTime.Now.AddDays(7),
                            EndDate=DateTime.Now.AddDays(15),
                            DepartmentId=41,
                            ManagerId=41,
                        },
                        new Project()
                        {
                            Name="Bed Shed",
                            ProbelemStatement="Nails to be cut",
                            ClientName="Kakali Ghosh Dastidar",
                            ImageURL="https://tinyurl.com/26teh9e7",
                            InitialDate=DateTime.Now,
                            EndDate=DateTime.Now.AddDays(7),
                            DepartmentId=44,
                            ManagerId=44,
                        },
                        new Project()
                        {
                            Name="Poison Pay",
                            ProbelemStatement="Toxic payment to be done under table",
                            ClientName="Leonardo Vinci",
                            ImageURL="https://tinyurl.com/vcjeus6x",
                            InitialDate=DateTime.Now,
                            EndDate=DateTime.Now.AddDays(3),
                            DepartmentId=41,
                            ManagerId=42,
                        },
                        new Project()
                        {
                            Name="Armstrong Shamer",
                            ProbelemStatement="Check body under zero gravity",
                            ClientName="Ronty roy",
                            ImageURL="https://tinyurl.com/385275wc",
                            InitialDate=DateTime.Now.AddDays(5),
                            EndDate=DateTime.Now.AddDays(20),
                            DepartmentId=41,
                            ManagerId=45,
                        },
                    });
                    context.SaveChanges();
                }
                //DevProjects
                if (!context.DevProjects.Any())
                {
                    context.DevProjects.AddRange(new List<DevProjects>
                    {
                        new DevProjects()
                        {
                            DevId=36,
                            ProjectId=15
                        },
                        new DevProjects()
                        {
                            DevId=40,
                            ProjectId=15
                        },
                        new DevProjects()
                        {
                            DevId=39,
                            ProjectId=16
                        },
                        new DevProjects()
                        {
                            DevId=37,
                            ProjectId=16
                        },
                        new DevProjects()
                        {
                            DevId=38,
                            ProjectId=17
                        },
                        new DevProjects()
                        {
                            DevId=39,
                            ProjectId=17
                        },
                        new DevProjects()
                        {
                            DevId=37,
                            ProjectId=17
                        },
                        new DevProjects()
                        {
                            DevId=40,
                            ProjectId=18
                        },
                        new DevProjects()
                        {
                            DevId=36,
                            ProjectId=18
                        },
                        new DevProjects()
                        {
                            DevId=38,
                            ProjectId=18
                        },
                        new DevProjects()
                        {
                            DevId=37,
                            ProjectId=19
                        },
                        new DevProjects()
                        {
                            DevId=40,
                            ProjectId=19
                        },
                        new DevProjects()
                        {
                            DevId=39,
                            ProjectId=19
                        },
                    });
                    context.SaveChanges();
                }
                
                
            }
        }

        //Seeding Roles
        public static async Task SeedRolesAsync(IServiceProvider service)
        {
            //Seed Roles
            var userManager = service.GetService<UserManager<ApplicationUser>>();
            var roleManager = service.GetService<RoleManager<IdentityRole>>();
            await roleManager.CreateAsync(new IdentityRole(Roles.Admin.ToString()));
            await roleManager.CreateAsync(new IdentityRole(Roles.User.ToString()));

            // creating admin

            var user = new ApplicationUser
            {
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                FullName = "Bea Burgers",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true
            };

            var userInDb = await userManager.FindByEmailAsync(user.Email);
            if (userInDb == null)
            {
                await userManager.CreateAsync(user, "Admin@123");
                await userManager.AddToRoleAsync(user, Roles.Admin.ToString());
            }
        }
    }
}
