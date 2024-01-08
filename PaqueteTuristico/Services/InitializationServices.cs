using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PaqueteTuristico.Data;
using Microsoft.AspNetCore.Mvc;
using PaqueteTuristico.Models;

namespace PaqueteTuristico.Services
{
    public class InitializationServices
    {
        private readonly UserManager<UserApp> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly conocubaContext context;
        private readonly ProvinceSetService  _services;
        private readonly TransportationContractServices _transportation;
        private readonly ComplementaryContractServices _complementary;
        private readonly HotelContractServices _hotels;
        public InitializationServices(UserManager<UserApp> userManager, RoleManager<IdentityRole> roleManager, conocubaContext context, ProvinceSetService _services,
            TransportationContractServices _transportation, ComplementaryContractServices _complementary, HotelContractServices _hotels)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.context = context;
            this._services = _services;
            this._transportation = _transportation;
            this._complementary = _complementary;
            this._hotels = _hotels;
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
            if (await userManager.FindByNameAsync(dalia.UserName) == null)
            {
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
        public async Task createDataHotels()
        {
            var list = new List<Hotel> { new Hotel { HotelId = 1, Name = "Hotel Habana", Chain = "Cadena A", Category = 5, Phone = 123456789, Email = "habana@hotel.cu", NumberOfRooms = 200, ProvinceId = 1, DisNearCity = 0, DisAirport = 20, NumberOfFloors = 10, Address = "Calle A, Habana", ComercializationMode = "All Inclusive", Price = 120.00m },
            new Hotel { HotelId = 2, Name = "Hotel Santiago", Chain = "Cadena B", Category = 4, Phone = 123456789, Email = "santiago@hotel.cu", NumberOfRooms = 150, ProvinceId = 2, DisNearCity = 10, DisAirport = 30, NumberOfFloors = 8, Address = "Calle B, Santiago", ComercializationMode = "Bed & Breakfast", Price = 80.00m },
            new Hotel { HotelId = 3, Name = "Hotel Trinidad", Chain = "Cadena C", Category = 3, Phone = 123456789, Email = "trinidad@hotel.cu", NumberOfRooms = 100, ProvinceId = 3, DisNearCity = 15, DisAirport = 35, NumberOfFloors = 6, Address = "Calle C, Trinidad", ComercializationMode = "Half Board", Price = 90.00m },
            new Hotel { HotelId = 4, Name = "Hotel Varadero", Chain = "Cadena D", Category = 5, Phone = 123456789, Email = "varadero@hotel.cu", NumberOfRooms = 250, ProvinceId = 4, DisNearCity = 5, DisAirport = 25, NumberOfFloors = 12, Address = "Calle D, Varadero", ComercializationMode = "All Inclusive", Price = 130.00m },
            new Hotel { HotelId = 5, Name = "Hotel Cienfuegos", Chain = "Cadena E", Category = 4, Phone = 123456789, Email = "cienfuegos@hotel.cu", NumberOfRooms = 120, ProvinceId = 5, DisNearCity = 10, DisAirport = 30, NumberOfFloors = 7, Address = "Calle E, Cienfuegos", ComercializationMode = "Full Board", Price = 100.00m },
            new Hotel { HotelId = 6, Name = "Hotel Camagüey", Chain = "Cadena F", Category = 3, Phone = 123456789, Email = "camaguey@hotel.cu", NumberOfRooms = 90, ProvinceId = 6, DisNearCity = 20, DisAirport = 40, NumberOfFloors = 5, Address = "Calle F, Camagüey", ComercializationMode = "Bed & Breakfast", Price = 70.00m },
            new Hotel { HotelId = 7, Name = "Hotel Holguín", Chain = "Cadena G", Category = 4, Phone = 123456789, Email = "holguin@hotel.cu", NumberOfRooms = 140, ProvinceId = 7, DisNearCity = 15, DisAirport = 35, NumberOfFloors = 8, Address = "Calle G, Holguín", ComercializationMode = "Half Board", Price = 95.00m },
            new Hotel { HotelId = 8, Name = "Hotel Pinar del Río", Chain = "Cadena H", Category = 3, Phone = 123456789, Email = "pinardelrio@hotel.cu", NumberOfRooms = 80, ProvinceId = 8, DisNearCity = 25, DisAirport = 45, NumberOfFloors = 4, Address = "Calle H, Pinar del Río", ComercializationMode = "Bed & Breakfast", Price = 60.00m } ,
            new Hotel { HotelId = 9, Name = "Hotel Guantánamo", Chain = "Cadena I", Category = 4, Phone = 123456789, Email = "guantanamo@hotel.cu", NumberOfRooms = 130, ProvinceId = 9, DisNearCity = 15, DisAirport = 35, NumberOfFloors = 7, Address = "Calle I, Guantánamo", ComercializationMode = "Full Board", Price = 85.00m } ,
            new Hotel { HotelId = 10, Name = "Hotel Matanzas", Chain = "Cadena J", Category = 5, Phone = 123456789, Email = "matanzas@hotel.cu", NumberOfRooms = 210, ProvinceId = 10, DisNearCity = 10, DisAirport = 30, NumberOfFloors = 11, Address = "Calle J, Matanzas", ComercializationMode = "All Inclusive", Price = 125.00m },
        };
            await context.HotelSet.AddRangeAsync(list);
            await context.SaveChangesAsync();
        }

        public async Task createRooms()
        {
            var list = new List<Room> { new Room { Id = 1, Name = "Habitación 1", Description = "Habitación doble", Price = 50.00m, AmountofPeople = 2, HotelId = 1 },
            new Room { Id = 2, Name = "Habitación 2", Description = "Habitación individual", Price = 30.00m, AmountofPeople = 1, HotelId = 1 },
             new Room { Id = 3, Name = "Habitación 3", Description = "Habitación doble", Price = 50.00m, AmountofPeople = 2, HotelId = 2 },
             new Room { Id = 4, Name = "Habitación 4", Description = "Habitación triple", Price = 70.00m, AmountofPeople = 3, HotelId = 2 },
             new Room { Id = 5, Name = "Habitación 5", Description = "Habitación individual", Price = 30.00m, AmountofPeople = 1, HotelId = 3 },
             new Room { Id = 6, Name = "Habitación 6", Description = "Habitación doble", Price = 50.00m, AmountofPeople = 2, HotelId = 4 },
             new Room { Id = 7, Name = "Habitación 7", Description = "Habitación triple", Price = 70.00m, AmountofPeople = 3, HotelId = 5 },
             new Room { Id = 8, Name = "Habitación 8", Description = "Habitación individual", Price = 30.00m, AmountofPeople = 1, HotelId = 6 },
            new Room { Id = 9, Name = "Habitación 9", Description = "Habitación doble", Price = 50.00m, AmountofPeople = 2, HotelId = 7 },
             new Room { Id = 10, Name = "Habitación 10", Description = "Habitación triple", Price = 70.00m, AmountofPeople = 3, HotelId = 8 },
        };
            await context.RoomSet.AddRangeAsync(list);
            await context.SaveChangesAsync();
        }

        public async Task crateMeals()
        {
            var list = new List<Meal>
            { new Meal { Id = 1, Name = "Plan de comida 1", Description = "Desayuno, almuerzo y cena", Price = 20.00m, HotelId = 1 },
             new Meal { Id = 2, Name = "Plan de comida 2", Description = "Solo desayuno", Price = 10.00m, HotelId = 1 },
             new Meal { Id = 3, Name = "Plan de comida 3", Description = "Desayuno y cena", Price = 15.00m, HotelId = 2 },
             new Meal { Id = 4, Name = "Plan de comida 4", Description = "Desayuno, almuerzo y cena", Price = 20.00m, HotelId = 2 },
             new Meal { Id = 5, Name = "Plan de comida 5", Description = "Solo desayuno", Price = 10.00m, HotelId = 3 },
             new Meal { Id = 6, Name = "Plan de comida 6", Description = "Desayuno y cena", Price = 15.00m, HotelId = 4 },
             new Meal { Id = 7, Name = "Plan de comida 7", Description = "Desayuno, almuerzo y cena", Price = 20.00m, HotelId = 5 },
             new Meal { Id = 8, Name = "Plan de comida 8", Description = "Solo desayuno", Price = 10.00m, HotelId = 6 },
             new Meal { Id = 9, Name = "Plan de comida 9", Description = "Desayuno y cena", Price = 15.00m, HotelId = 7 },
             new Meal { Id = 10, Name = "Plan de comida 10", Description = "Desayuno, almuerzo y cena", Price = 20.00m, HotelId = 8 },
        };
            await context.MealSet.AddRangeAsync(list);
            await context.SaveChangesAsync();
        }
        public async Task crateVehicles()
        {
            var list = new List<Vehicle>
            {
             new Vehicle { VehicleId = 1, License_Plate_Number = "ABC123", Price = 20000.00m, Brand = "Marca A", Capacity_Without_Equipement = 4, Capacity_With_Equipement = 2, Total_Capacity = 6, Year_of_Manufacture = 2015, Manufacturing_Mode = "Manual", ProvinceId = 1 },
             new Vehicle { VehicleId = 2, License_Plate_Number = "DEF456", Price = 25000.00m, Brand = "Marca B", Capacity_Without_Equipement = 5, Capacity_With_Equipement = 3, Total_Capacity = 8, Year_of_Manufacture = 2016, Manufacturing_Mode = "Automático", ProvinceId = 2 },
             new Vehicle { VehicleId = 3, License_Plate_Number = "GHI789", Price = 30000.00m, Brand = "Marca C", Capacity_Without_Equipement = 6, Capacity_With_Equipement = 4, Total_Capacity = 10, Year_of_Manufacture = 2017, Manufacturing_Mode = "Manual", ProvinceId = 3 },
             new Vehicle { VehicleId = 4, License_Plate_Number = "JKL012", Price = 35000.00m, Brand = "Marca D", Capacity_Without_Equipement = 7, Capacity_With_Equipement = 5, Total_Capacity = 12, Year_of_Manufacture = 2018, Manufacturing_Mode = "Automático", ProvinceId = 4 },
             new Vehicle { VehicleId = 5, License_Plate_Number = "MNO345", Price = 40000.00m, Brand = "Marca E", Capacity_Without_Equipement = 8, Capacity_With_Equipement = 6, Total_Capacity = 14, Year_of_Manufacture = 2019, Manufacturing_Mode = "Manual", ProvinceId = 5 },
             new Vehicle { VehicleId = 6, License_Plate_Number = "PQR678", Price = 45000.00m, Brand = "Marca F", Capacity_Without_Equipement = 9, Capacity_With_Equipement = 7, Total_Capacity = 16, Year_of_Manufacture = 2020, Manufacturing_Mode = "Automático", ProvinceId = 6 },
             new Vehicle { VehicleId = 7, License_Plate_Number = "STU901", Price = 50000.00m, Brand = "Marca G", Capacity_Without_Equipement = 10, Capacity_With_Equipement = 8, Total_Capacity = 18, Year_of_Manufacture = 2021, Manufacturing_Mode = "Manual", ProvinceId = 7 },
             new Vehicle { VehicleId = 8, License_Plate_Number = "VWX234", Price = 55000.00m, Brand = "Marca H", Capacity_Without_Equipement = 11, Capacity_With_Equipement = 9, Total_Capacity = 20, Year_of_Manufacture = 2022, Manufacturing_Mode = "Automático", ProvinceId = 8 },
             new Vehicle { VehicleId = 9, License_Plate_Number = "YZA567", Price = 60000.00m, Brand = "Marca I", Capacity_Without_Equipement = 12, Capacity_With_Equipement = 10, Total_Capacity = 22, Year_of_Manufacture = 2023, Manufacturing_Mode = "Manual", ProvinceId = 9 },
             new Vehicle { VehicleId = 10, License_Plate_Number = "BCD890", Price = 65000.00m, Brand = "Marca J", Capacity_Without_Equipement = 13, Capacity_With_Equipement = 11, Total_Capacity = 24, Year_of_Manufacture = 2024, Manufacturing_Mode = "Automático", ProvinceId = 10 },
        };
            await context.VehicleSet.AddRangeAsync(list);
            await context.SaveChangesAsync();
        }
        public async Task crateActivities()
        {
            var list = new List<DayliActivities>
            {
                 new DayliActivities { ActivityId = 1, Day = 1, Description = "Actividad 1", Price = 10.00m, ProvinceId = 1 },
            new DayliActivities { ActivityId = 2, Day = 2, Description = "Actividad 2", Price = 20.00m, ProvinceId = 2 },
             new DayliActivities { ActivityId = 3, Day = 3, Description = "Actividad 3", Price = 30.00m, ProvinceId = 3 },
             new DayliActivities { ActivityId = 4, Day = 4, Description = "Actividad 4", Price = 40.00m, ProvinceId = 4 },
             new DayliActivities { ActivityId = 5, Day = 5, Description = "Actividad 5", Price = 50.00m, ProvinceId = 5 },
             new DayliActivities { ActivityId = 6, Day = 6, Description = "Actividad 6", Price = 60.00m, ProvinceId = 6 },
             new DayliActivities { ActivityId = 7, Day = 7, Description = "Actividad 7", Price = 70.00m, ProvinceId = 7 },
             new DayliActivities { ActivityId = 8, Day = 8, Description = "Actividad 8", Price = 80.00m, ProvinceId = 8 },
             new DayliActivities { ActivityId = 9, Day = 9, Description = "Actividad 9", Price = 90.00m, ProvinceId = 9 },
             new DayliActivities { ActivityId = 10, Day = 10, Description = "Actividad 10", Price = 100.00m, ProvinceId = 10 },
        };
            await context.DayliActivitieSet.AddRangeAsync(list);
            await context.SaveChangesAsync();
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

        public async Task CreateTransportContracts()
        {

            var t1 = new TransportationContract
            {
                Id = 1,
                Desc = "Contrato de Transporte",
                StarDate = new DateTime(2023, 10, 27),
                EndTime = new DateTime(2024, 10, 27),
                ConcilTime = new DateTime(2023, 10, 30),
                Enabled = true,
                TransportationProvider = "Proveedor 1",
                IncluedVehicles = 1
            }; await _transportation.InsertTransportationContractAsync(t1);
            var t2 = new TransportationContract
            {
                Id = 2,
                Desc = "Contrato de Transporte",
                StarDate = new DateTime(2024, 01, 05),
                EndTime = new DateTime(2025, 01, 05),
                ConcilTime = new DateTime(2024, 01, 10),
                Enabled = true,
                TransportationProvider = "Proveedor 2",
                IncluedVehicles = 2
            }; await _transportation.InsertTransportationContractAsync(t2);
            var t3 = new TransportationContract
            {
                Id = 7,
                Desc = "Contrato de Transporte",
                StarDate = new DateTime(2023, 01, 02),
                EndTime = new DateTime(2024, 01, 02),
                ConcilTime = new DateTime(2023, 01, 05),
                Enabled = false,
                TransportationProvider = "Proveedor 3",
                IncluedVehicles = 3
            }; await _transportation.InsertTransportationContractAsync(t3);
            var t4 = new TransportationContract
            {
                Id = 8,
                Desc = "Contrato de Transporte",
                StarDate = new DateTime(2023, 04, 15),
                EndTime = new DateTime(2024, 04, 15),
                ConcilTime = new DateTime(2023, 04, 30),
                Enabled = true,
                TransportationProvider = "Proveedor 4",
                IncluedVehicles = 4
            }; await _transportation.InsertTransportationContractAsync(t4);
            var t5 = new TransportationContract
            {
                Id = 13,
                Desc = "Contrato de Transporte",
                StarDate = new DateTime(2023, 12, 04),
                EndTime = new DateTime(2024, 12, 04),
                ConcilTime = new DateTime(2023, 12, 12),
                Enabled = true,
                TransportationProvider = "Proveedor 5",
                IncluedVehicles = 5
            }; await _transportation.InsertTransportationContractAsync(t5);
            var t6 = new TransportationContract
            {
                Id = 14,
                Desc = "Contrato de Transporte",
                StarDate = new DateTime(2022, 10, 04),
                EndTime = new DateTime(2023, 10, 04),
                ConcilTime = new DateTime(2022, 10, 12),
                Enabled = false,
                TransportationProvider = "Proveedor 6",
                IncluedVehicles = 6
            }; await _transportation.InsertTransportationContractAsync(t6);
            var t7 = new TransportationContract
            {
                Id = 19,
                Desc = "Contrato de Transporte",
                StarDate = new DateTime(2023, 05, 04),
                EndTime = new DateTime(2024, 05, 04),
                ConcilTime = new DateTime(2023, 05, 12),
                Enabled = true,
                TransportationProvider = "Proveedor 7",
                IncluedVehicles = 7
            }; await _transportation.InsertTransportationContractAsync(t7);
            var t8 = new TransportationContract
            {
                Id = 20,
                Desc = "Contrato de Transporte",
                StarDate = new DateTime(2022, 12, 04),
                EndTime = new DateTime(2023, 12, 04),
                ConcilTime = new DateTime(2022, 12, 12),
                Enabled = false,
                TransportationProvider = "Proveedor 8",
                IncluedVehicles = 8
            }; await _transportation.InsertTransportationContractAsync(t8);
            var t9 = new TransportationContract
            {
                Id = 25,
                Desc = "Contrato de Transporte",
                StarDate = new DateTime(2023, 08, 04),
                EndTime = new DateTime(2024, 08, 04),
                ConcilTime = new DateTime(2023, 08, 12),
                Enabled = true,
                TransportationProvider = "Proveedor 9",
                IncluedVehicles = 9
            }; await _transportation.InsertTransportationContractAsync(t9);
            var t10 = new TransportationContract
            {
                Id = 26,
                Desc = "Contrato de Transporte",
                StarDate = new DateTime(2022, 11, 04),
                EndTime = new DateTime(2023, 11, 04),
                ConcilTime = new DateTime(2022, 11, 12),
                Enabled = false,
                TransportationProvider = "Proveedor 10",
                IncluedVehicles = 10
            }; await _transportation.InsertTransportationContractAsync(t10);
        }

        public async Task CreateComplementaryContract()
        {
            await _complementary.InsertComplementaryContractAsync(new ComplementaryContract
            {
                Id = 3,
                Desc = "Contrato Complementario",
                StarDate = new DateTime(2023, 10, 27),
                EndTime = new DateTime(2024, 10, 27),
                ConcilTime = new DateTime(2023, 10, 30),
                Enabled = true,
                ServiceType = "Museo",
                CostPerPerson = 10.00m,
                ComplementaryServiceProvince = "Servicio 1"
            });
            await _complementary.InsertComplementaryContractAsync(new ComplementaryContract
            {
                Id = 4,
                Desc = "Contrato Complementario",
                StarDate = new DateTime(2024, 01, 05),
                EndTime = new DateTime(2025, 01, 05),
                ConcilTime = new DateTime(2024, 01, 10),
                Enabled = true,
                ServiceType = "Cafetería",
                CostPerPerson = 20.00m,
                ComplementaryServiceProvince = "Servicio 2"
            });
            await _complementary.InsertComplementaryContractAsync(new ComplementaryContract
            {
                Id = 9,
                Desc = "Contrato Complementario",
                StarDate = new DateTime(2023, 01, 02),
                EndTime = new DateTime(2024, 01, 02),
                ConcilTime = new DateTime(2023, 01, 05),
                Enabled = false,
                ServiceType = "Espectáculo nocturno",
                CostPerPerson = 30.00m,
                ComplementaryServiceProvince = "Servicio 3"
            });
            await _complementary.InsertComplementaryContractAsync(new ComplementaryContract
            {
                Id = 10,
                Desc = "Contrato Complementario",
                StarDate = new DateTime(2023, 04, 15),
                EndTime = new DateTime(2024, 04, 15),
                ConcilTime = new DateTime(2023, 04, 30),
                Enabled = true,
                ServiceType = "Excursión",
                CostPerPerson = 40.00m,
                ComplementaryServiceProvince = "Servicio 4"
            });
            await _complementary.InsertComplementaryContractAsync(new ComplementaryContract
            {
                Id = 15,
                Desc = "Contrato Complementario",
                StarDate = new DateTime(2023, 12, 04),
                EndTime = new DateTime(2024, 12, 04),
                ConcilTime = new DateTime(2023, 12, 12),
                Enabled = true,
                ServiceType = "Paseo marítimo",
                CostPerPerson = 50.00m,
                ComplementaryServiceProvince = "Servicio 5"
            });
            await _complementary.InsertComplementaryContractAsync(new ComplementaryContract
            {
                Id = 16,
                Desc = "Contrato Complementario",
                StarDate = new DateTime(2022, 10, 04),
                EndTime = new DateTime(2023, 10, 04),
                ConcilTime = new DateTime(2022, 10, 12),
                Enabled = false,
                ServiceType = "Museo",
                CostPerPerson = 60.00m,
                ComplementaryServiceProvince = "Servicio 6"
            });
            await _complementary.InsertComplementaryContractAsync(new ComplementaryContract
            {
                Id = 21,
                Desc = "Contrato Complementario",
                StarDate = new DateTime(2023, 05, 04),
                EndTime = new DateTime(2024, 05, 04),
                ConcilTime = new DateTime(2023, 05, 12),
                Enabled = true,
                ServiceType = "Espectáculo nocturno",
                CostPerPerson = 70.00m,
                ComplementaryServiceProvince = "Servicio 7"
            });
            await _complementary.InsertComplementaryContractAsync(new ComplementaryContract
            {
                Id = 22,
                Desc = "Contrato Complementario",
                StarDate = new DateTime(2022, 12, 04),
                EndTime = new DateTime(2023, 12, 04),
                ConcilTime = new DateTime(2022, 12, 12),
                Enabled = false,
                ServiceType = "Excursión",
                CostPerPerson = 80.00m,
                ComplementaryServiceProvince = "Servicio 8"
            });
        }

        public async Task CreateHotelContract()
        {
            await _hotels.InsertHotelContractAsync(new HotelContract
            {
                Id = 5,
                Desc = "Contrato de Hotel",
                StarDate = new DateTime(2023, 10, 27),
                EndTime = new DateTime(2024, 10, 27),
                ConcilTime = new DateTime(2023, 10, 30),
                Enabled = true,
                Address = "Calle A, La Habana",
                HotelTotalPrice = 120.00m
            });
            await _hotels.InsertHotelContractAsync(new HotelContract
            {
                Id = 6,
                Desc = "Contrato de Hotel",
                StarDate = new DateTime(2024, 01, 05),
                EndTime = new DateTime(2025, 01, 05),
                ConcilTime = new DateTime(2024, 01, 10),
                Enabled = true,
                Address = "Calle B, Santiago",
                HotelTotalPrice = 80.00m
            });
            await _hotels.InsertHotelContractAsync(new HotelContract
            {
                Id = 11,
                Desc = "Contrato de Hotel",
                StarDate = new DateTime(2023, 01, 02),
                EndTime = new DateTime(2024, 01, 02),
                ConcilTime = new DateTime(2023, 01, 05),
                Enabled = false,
                Address = "Calle C, Trinidad",
                HotelTotalPrice = 90.00m
            });
            await _hotels.InsertHotelContractAsync(new HotelContract
            {
                Id = 12,
                Desc = "Contrato de Hotel",
                StarDate = new DateTime(2023, 04, 15),
                EndTime = new DateTime(2024, 04, 15),
                ConcilTime = new DateTime(2023, 04, 30),
                Enabled = true,
                Address = "Calle D, Varadero",
                HotelTotalPrice = 130.00m
            });
            await _hotels.InsertHotelContractAsync(new HotelContract
            {
                Id = 17,
                Desc = "Contrato de Hotel",
                StarDate = new DateTime(2023, 12, 04),
                EndTime = new DateTime(2024, 12, 04),
                ConcilTime = new DateTime(2023, 12, 12),
                Enabled = true,
                Address = "Calle E, Cienfuegos",
                HotelTotalPrice = 100.00m
            });
            await _hotels.InsertHotelContractAsync(new HotelContract
            {
                Id = 18,
                Desc = "Contrato de Hotel",
                StarDate = new DateTime(2022, 10, 04),
                EndTime = new DateTime(2023, 10, 04),
                ConcilTime = new DateTime(2022, 10, 12),
                Enabled = false,
                Address = "Calle F, Camagüey",
                HotelTotalPrice = 70.00m
            });
            await _hotels.InsertHotelContractAsync(new HotelContract
            {
                Id = 23,
                Desc = "Contrato de Hotel",
                StarDate = new DateTime(2023, 05, 04),
                EndTime = new DateTime(2024, 05, 04),
                ConcilTime = new DateTime(2023, 05, 12),
                Enabled = true,
                Address = "Calle G, Holguín",
                HotelTotalPrice = 95.00m
            });
            await _hotels.InsertHotelContractAsync(new HotelContract
            {
                Id = 24,
                Desc = "Contrato de Hotel",
                StarDate = new DateTime(2022, 12, 04),
                EndTime = new DateTime(2023, 12, 04),
                ConcilTime = new DateTime(2022, 12, 12),
                Enabled = false,
                Address = "Calle H, Pinar del Río",
                HotelTotalPrice = 60.00m
            });
            await _hotels.InsertHotelContractAsync(new HotelContract
            {
                Id = 27,
                Desc = "Contrato de Hotel",
                StarDate = new DateTime(2023, 08, 04),
                EndTime = new DateTime(2024, 08, 04),
                ConcilTime = new DateTime(2023, 08, 12),
                Enabled = true,
                Address = "Calle I, Guantánamo",
                HotelTotalPrice = 85.00m
            });
            await _hotels.InsertHotelContractAsync(new HotelContract
            {
                Id = 28,
                Desc = "Contrato de Hotel",
                StarDate = new DateTime(2022, 11, 04),
                EndTime = new DateTime(2023, 11, 04),
                ConcilTime = new DateTime(2022, 11, 12),
                Enabled = false,
                Address = "Calle J, Matanzas",
                HotelTotalPrice = 125.00m
            });
        }


    }
}
