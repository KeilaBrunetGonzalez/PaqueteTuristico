using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using PaqueteTuristico.Models;

namespace PaqueteTuristico.Services
{
    public class InitializationServices
    {
        private readonly UserManager<UserApp> userManager;
        private readonly RoleManager<IdentityRole> roleManager; 
        private readonly ProvinceSetService _services;
        public InitializationServices(UserManager<UserApp> userManager, RoleManager<IdentityRole> roleManager, ProvinceSetService _services) { 
            this.userManager = userManager;
            this.roleManager = roleManager;
            this._services = _services;
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

        public async Task CreateProvinces()
        {

            var pinar_del_rio = new Province 
            {
                ProvinceId = 1, 
                ProvinceName = "Pinar del Río", 
                ProvinceDesc = "Esta provincia es famosa por sus paisajes naturales y la producción de tabaco. Es el hogar del Valle de Viñales, un sitio del Patrimonio Mundial de la UNESCO." 
            };
            await _services.InsertProvinceAsync(pinar_del_rio);
            var artemisa = new Province 
            { 
                ProvinceId = 2, 
                ProvinceName = "Artemisa", 
                ProvinceDesc = "Una de las provincias más jóvenes de Cuba, Artemisa es conocida por su desarrollo industrial y agrícola."
            };
            await _services.InsertProvinceAsync(artemisa);
            var la_habana = new Province
            {
                ProvinceId = 3,
                ProvinceName = "La Habana",
                ProvinceDesc = "La capital de Cuba, La Habana es famosa por su rica historia, vibrante vida nocturna y arquitectura colonial."
            };
            await _services.InsertProvinceAsync(la_habana);
            var mayabeque = new Province
            {
                ProvinceId = 4,
                ProvinceName = "Mayabeque",
                ProvinceDesc = "Esta pequeña provincia agrícola es conocida por sus cultivos de cítricos y vegetales."
            };
            await _services.InsertProvinceAsync(mayabeque);
            var matanzas = new Province
            {
                ProvinceId = 5,
                ProvinceName = "Matanzas",
                ProvinceDesc = "Hogar de hermosas playas, la famosa Cueva de Bellamar y la ciudad de Varadero, uno de los destinos turísticos más populares de Cuba."
            };
            await _services.InsertProvinceAsync(matanzas);
            var cienfuegos = new Province
            {
                ProvinceId = 6,
                ProvinceName = "Cienfuegos",
                ProvinceDesc = "Conocida como la \"Perla del Sur\", Cienfuegos es famosa por su arquitectura francesa y su hermosa bahía. "
            };
            await _services.InsertProvinceAsync(cienfuegos);
            var villa_clara = new Province
            {
                ProvinceId = 7,
                ProvinceName = "Villa Clara",
                ProvinceDesc = "Esta provincia es el hogar del monumento a Ernesto Che Guevara en Santa Clara y el destino turístico de las cayos del norte."
            };
            await _services.InsertProvinceAsync(villa_clara);
            var santi_spiritus = new Province
            {
                ProvinceId = 8,
                ProvinceName = "Sancti Spíritus",
                ProvinceDesc = "Conocida por ser la ubicación de Trinidad, una ciudad Patrimonio de la Humanidad de la UNESCO, que es famosa por su arquitectura colonial bien conservada."
            };
            await _services.InsertProvinceAsync(santi_spiritus);
            var ciego_de_avila = new Province
            {
                ProvinceId = 9,
                ProvinceName = "Ciego de Ávila",
                ProvinceDesc = "Famosa por sus plantaciones de piña y su fauna diversa, esta provincia es también el acceso a los cayos del norte, un popular destino turístico."
            };
            await _services.InsertProvinceAsync(ciego_de_avila);
            var camaguey = new Province
            {
                ProvinceId = 10,
                ProvinceName = "Camagüey",
                ProvinceDesc = "Conocida por sus laberínticas calles y su arquitectura colonial, Camagüey es también famosa por sus tradiciones ganaderas. "
            };
            await _services.InsertProvinceAsync(camaguey);
            var las_tunas = new Province
            {
                ProvinceId = 11,
                ProvinceName = "Las Tunas",
                ProvinceDesc = "A menudo llamada la \"Balcón de Oriente\", Las Tunas es conocida por su festival anual de esculturas."
            };
            await _services.InsertProvinceAsync(las_tunas);
            var granma = new Province
            {
                ProvinceId = 12,
                ProvinceName = "Granma",
                ProvinceDesc = "Hogar del Parque Nacional Desembarco del Granma, un sitio del Patrimonio Mundial de la UNESCO, y la ciudad de Bayamo, uno de los asentamientos más antiguos de Cuba."
            };
            await _services.InsertProvinceAsync(granma);
            var holguin = new Province
            {
                ProvinceId = 13,
                ProvinceName = "Holguín",
                ProvinceDesc = "Conocida por sus hermosas playas, como Guardalavaca, y su paisaje montañoso."
            };
            await _services.InsertProvinceAsync(holguin);
            var santiago_de_cuba = new Province
            {
                ProvinceId = 14,
                ProvinceName = "Santiago de Cuba",
                ProvinceDesc = "Cuna del son cubano y rica en historia revolucionaria, Santiago de Cuba es la segunda ciudad más grande de Cuba."
            };
            await _services.InsertProvinceAsync(santiago_de_cuba);
            var guantanamo = new Province
            {
                ProvinceId = 15,
                ProvinceName = "Guantánamo",
                ProvinceDesc = "La provincia es famosa por su música y danza tradicional, el Changüí. "
            };
            await _services.InsertProvinceAsync(guantanamo);
            var isla_de_la_juventud = new Province
            {
                ProvinceId = 16,
                ProvinceName = "Isla de la Juventud",
                ProvinceDesc = "El segundo cuerpo terrestre más grande de Cuba, famoso por sus sitios de buceo y la cría de cítricos."
            };
            await _services.InsertProvinceAsync(isla_de_la_juventud);

        }
    }
}
