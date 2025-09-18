﻿using KASHOP.DAL.Data;
using KASHOP.DAL.Data.Migrations;
using KASHOP.DAL.Models;
using KASHOP.DAL.Models.Brand;
using KASHOP.DAL.Models.Category;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KASHOP.DAL.Utils
{
    public class SeedData : ISeedData
    {
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public SeedData(ApplicationDbContext context,
                        RoleManager<IdentityRole> roleManager,
                        UserManager<ApplicationUser> userManager
            )
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task DataSeedingAsync()
        {
            // تطبيق أي Migrations معلّقة
            if ((await _context.Database.GetPendingMigrationsAsync()).Any())
            {
                _context.Database.Migrate();
            }


            if (!await _context.categories.AnyAsync())
            {
                await _context.categories.AddRangeAsync(
                     new Category { Name = "Clothes" },
                     new Category { Name = "Mobiles" }
                 );
            }


            if (!await _context.Brands.AnyAsync())
            {
                await _context.Brands.AddRangeAsync(
                    new Brand { Name = "Samsung" },
                    new Brand { Name = "Apple" },
                    new Brand { Name = "Nike" }
                );
            }

            await _context.SaveChangesAsync();
        }

        public async Task IdentityDataSeedingAsync()
        {
            if (_context.Database.GetPendingMigrations().Any())
            {
                _context.Database.Migrate();
            }

            if (!await _roleManager.Roles.AnyAsync())
            {
                await _roleManager.CreateAsync(new IdentityRole("Admin"));
                await _roleManager.CreateAsync(new IdentityRole("SuperAdmin"));
                await _roleManager.CreateAsync(new IdentityRole("Customer"));
            }
            if (!await _userManager.Users.AnyAsync())
            {
                var user1 = new ApplicationUser
                {
                    Email = "tariq@gmail.com",
                    PhoneNumber = "0592100103",
                    UserName = "tshreem",
                };
                var user2 = new ApplicationUser
                {
                    Email = "sami@gmail.com",
                    PhoneNumber = "0592100104",
                    UserName = "sshreem",
                };
                var user3 = new ApplicationUser
                {
                    Email = "alaa@gmail.com",
                    PhoneNumber = "0592100105",
                    UserName = "ashreem",
                };

                await _userManager.CreateAsync(user1, "Pass@1212");
                await _userManager.CreateAsync(user2, "Pass@1212");
                await _userManager.CreateAsync(user3, "Pass@1212");


                await _userManager.AddToRoleAsync(user1, "Admin");
                await _userManager.AddToRoleAsync(user2, "SuperAdmin");
                await _userManager.AddToRoleAsync(user3, "Customer");

                
            }
            await _context.SaveChangesAsync();
        }
    }

}