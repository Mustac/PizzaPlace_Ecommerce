﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace PizzaPlace.BlazorServer.Helpers
{
    public class DataSeeder
    {
        public static async Task SeedUserAndRolesAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            if (await userManager.Users.AnyAsync())
                return;

            IdentityRole[] roles = new IdentityRole[]
            {
                new IdentityRole { Name = Role.Manager  },
                new IdentityRole { Name = Role.Chef },
                new IdentityRole { Name = Role.Delivery },
                new IdentityRole { Name = Role.Customer }
            };

            foreach(var role in roles)
            {
                await roleManager.CreateAsync(role);
            }

            ApplicationUser[] applicationUsers = new[] { new ApplicationUser
            {
                Addresses = new List<Address>
                {
                    new Address
                    {
                        City = "Oslo",
                        Street = "Torggata 18",
                        Zip = "0181",
                    }
                },
                Email = "chef1@gmail.com",
                UserName = "chef1@gmail.com"
            },
                new ApplicationUser
            {
                    Addresses = new List<Address>
                {
                    new Address
                    {
                        City = "Oslo",
                        Street = "Karl Johans gate 22",
                        Zip = "0159",
                    }
                },
                Email = "chef2@gmail.com",
                UserName = "chef2@gmail.com"
            },
                new ApplicationUser
            {
                      Addresses = new List<Address>
                {
                    new Address
                    {
                        City = "Oslo",
                        Street = "Storgata 32",
                        Zip = "0184",
                    }
                },
                Email = "chef3@gmail.com",
                UserName = "chef3@gmail.com"
            },
                new ApplicationUser
            {
                    Addresses = new List<Address>
                {
                    new Address
                    {
                        City = "Oslo",
                        Street = "Prinsens gate 15",
                        Zip = "0152",
                    }
                },
                Email = "chef4@gmail.com",
                UserName = "chef4@gmail.com"
            }};

            foreach (var user in applicationUsers)
            {
                var tempUser = await userManager.CreateAsync(user);
                await userManager.AddToRoleAsync(user, Role.Chef);
            }

            ApplicationUser[] applicationUsersDelivery = new[] {
            new ApplicationUser
            {
                 Addresses = new List<Address>
                {
                    new Address
                    {
                        City = "Oslo",
                        Street = "Torggata 18",
                        Zip = "0181",
                    }
                },
                Email = "delivery1@gmail.com",
                UserName = "delivery1@gmail.com"
            },
            new ApplicationUser
            {
                Addresses = new List<Address>
                {
                    new Address
                    {
                        City = "Oslo",
                        Street = "Karl Johans gate 22",
                        Zip = "0159",
                    }
                },
                Email = "delivery2@gmail.com",
                UserName = "delivery2@gmail.com"
            },
            new ApplicationUser
            {
                Addresses = new List<Address>
                {
                    new Address
                    {
                        City = "Oslo",
                        Street = "Storgata 32",
                        Zip = "0184",
                    }
                },
                Email = "delivery3@gmail.com",
                UserName = "delivery3@gmail.com"
            },
            new ApplicationUser
            {
                Addresses = new List<Address>
                {
                    new Address
                    {
                        City = "Oslo",
                        Street = "Prinsens gate 15",
                        Zip = "0152",
                    }
                },
                Email = "delivery4@gmail.com",
                UserName = "delivery4@gmail.com"
            }
        };

            foreach (var user in applicationUsersDelivery)
            {
                var tempUser = await userManager.CreateAsync(user);
                await userManager.AddToRoleAsync(user, Role.Delivery);
            }

            var manager = new ApplicationUser
            {
                Addresses = new List<Address>
                {
                    new Address
                    {
                        City = "Oslo",
                        Street = "Hjeramoen 46A",
                        Zip = "2072",
                    }
                },
                Email = "mustac.marijan@gmail.com",
                UserName = "mustac.marijan@gmail.com"
            };

            

            await userManager.CreateAsync(manager);
            await userManager.AddToRoleAsync(manager, Role.Manager);

        }


    }
}
