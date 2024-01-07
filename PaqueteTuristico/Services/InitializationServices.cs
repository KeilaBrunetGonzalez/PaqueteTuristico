﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PaqueteTuristico.Models;

namespace PaqueteTuristico.Services
{
    public class InitializationServices
    {
        private readonly UserManager<UserApp> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        public InitializationServices(UserManager<UserApp> userManager, RoleManager<IdentityRole> roleManager) { 
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        //Funcion que iniciali
        public async Task CreateRoles()
        {
            string[] roleNames = { "Admin", "User", "SuperAdmin" };
            //Comprovar si ya existen los roles para que no haya fallos
            foreach (var roleName in roleNames)
            {
                if (!await roleManager.RoleExistsAsync(roleName))
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
        }

        public async Task CreateUsers()
        {
            
                var franco = new UserApp { UserName = "Franco", Email = "admin@example.com" };
                var keila = new UserApp { UserName = "Keila", Email = "keilabrunet@gmail.com" };
                var dalia = new UserApp { UserName = "Dalia", Email = "daliareyes@gmail.com" };
                var dario = new UserApp { UserName = "Dario", Email = "ivandario@gmail.com" };
                var relleno = new UserApp { UserName = "Supremo" };
            if (await userManager.FindByNameAsync(franco.UserName) == null)
            {
                var result = await userManager.CreateAsync(franco, "franco123");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(franco, "Admin");
                }
            }
            if (await userManager.FindByNameAsync(keila.UserName) == null)
            {
                var result = await userManager.CreateAsync(keila, "keila123");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(keila, "Admin");
                }
            }
            if (await userManager.FindByNameAsync(dalia.UserName) == null) {
                var result = await userManager.CreateAsync(dalia, "dalia123");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(dalia, "Admin");
                }
            }
            if (await userManager.FindByNameAsync(dario.UserName) == null)
            {
                var result = await userManager.CreateAsync(dario, "dario123");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(dario, "Admin");
                }
            }
            if (await userManager.FindByNameAsync(keila.UserName) == null)
            {
                var result = await userManager.CreateAsync(dalia, "dalia");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(dalia, "Admin");
                }
            }
            if (await userManager.FindByNameAsync(relleno.UserName) == null)
            {
                var result = await userManager.CreateAsync(relleno, "supremo123");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(relleno, "SuperAdmin");
                }
            }

        }

    }
}
