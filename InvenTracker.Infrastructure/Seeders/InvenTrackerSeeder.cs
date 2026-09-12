using InvenTracker.Domain.Entities;

namespace InvenTracker.Infrastructure.Seeders;


public class InvenTrackerSeeder
{
    private readonly InvenTrackerDbContext _dbContext;

    public InvenTrackerSeeder(InvenTrackerDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public void Seed()
    {
        if (_dbContext.Database.CanConnect())
        {
            if (!_dbContext.Companies.Any())
            {
                var companies = GetCompanies();
                _dbContext.Companies.AddRange(companies);
                _dbContext.SaveChanges();
            }

            if (!_dbContext.Roles.Any())
            {
                var roles = GetRoles();
                _dbContext.Roles.AddRange(roles);
                _dbContext.SaveChanges();
            }

            if (!_dbContext.Users.Any())
            {
                var users = GetUsers();
                _dbContext.Users.AddRange(users);
                _dbContext.SaveChanges();
            }
        }
    }


    private IEnumerable<User> GetUsers()
    {
        return new List<User>
        {
            new User
            {
                Id = Guid.Parse("aaaaaaaa-aaaa-aaaa-aaaa-aaaaaaaaaaaa"),
                FirstName = "Admin",
                LastName = "Testowy",
                Username = "admin",
                Email = "admin@test.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin123!"),
                RoleId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            },
            new User
            {
                Id = Guid.Parse("bbbbbbbb-bbbb-bbbb-bbbb-bbbbbbbbbbbb"),
                FirstName = "Technik",
                LastName = "Testowy",
                Username = "technik",
                Email = "technik@test.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("Technik123!"),
                RoleId = Guid.Parse("33333333-3333-3333-3333-333333333333")
            },
            new User
            {
                Id = Guid.Parse("cccccccc-cccc-cccc-cccc-cccccccccccc"),
                FirstName = "Dostawca",
                LastName = "Testowy",
                Username = "dostawca",
                Email = "dostawca@test.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("Dostawca123!"),
                RoleId = Guid.Parse("44444444-4444-4444-4444-444444444444")
            },
            new User
            {
                Id = Guid.Parse("dddddddd-dddd-dddd-dddd-dddddddddddd"),
                FirstName = "User",
                LastName = "Testowy",
                Username = "user",
                Email = "user@test.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("User123!"),
                RoleId = Guid.Parse("22222222-2222-2222-2222-222222222222")
            }
        };
    }

    private IEnumerable<Role> GetRoles()
    {
        return new List<Role>()
        {
            new Role
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                Name = "Admin",
            },
            new Role
            {
                Id = Guid.Parse("22222222-2222-2222-2222-222222222222"),
                Name = "User",
            },
            new Role
            {
                Id = Guid.Parse("33333333-3333-3333-3333-333333333333"),
                Name = "Technik",
            },
            new Role
            {
                Id = Guid.Parse("44444444-4444-4444-4444-444444444444"),
                Name = "Dostawca",
            }
        };
    }

    private IEnumerable<Company> GetCompanies()
    {
        var companies = new List<Company>();

        // Firma 1: TechCorp
        var techCorpAddress = new AddressCompany
        {
            Id = Guid.NewGuid(),
            Street = "Aleje Jerozolimskie",
            BuildingNumber = "123A",
            PostalCode = "00-001",
            City = "Warszawa"
        };

        var techCorp = new Company
        {
            Id = Guid.NewGuid(),
            Name = "TechCorp Rozwiązania IT",
            Description = "Firma 1: TechCorp",
            Address = techCorpAddress,
            AddressId = techCorpAddress.Id,
            Departments = new List<Department>(),
            Wardrobes = new List<Wardrobe>()
        };

        // Działy TechCorp
        var itSupportDeptAddress = new AddressDepartment
        {
            Id = Guid.NewGuid(),
            Street = "Marszałkowska",
            BuildingNumber = "45",
            PostalCode = "00-002",
            City = "Warszawa"
        };

        var itSupportDept = new Department
        {
            Id = Guid.NewGuid(),
            Name = "Wsparcie IT",
            Description = "Dział wsparcia technicznego",
            CompanyId = techCorp.Id,
            Address = itSupportDeptAddress,
            AddressId = itSupportDeptAddress.Id,
            Wardrobes = new List<Wardrobe>()
        };

        var developmentDeptAddress = new AddressDepartment
        {
            Id = Guid.NewGuid(),
            Street = "Krucza",
            BuildingNumber = "16/22",
            PostalCode = "00-003",
            City = "Warszawa"
        };

        var developmentDept = new Department
        {
            Id = Guid.NewGuid(),
            Name = "Dział Programistów",
            Description = "Dział deweloperski",
            CompanyId = techCorp.Id,
            Address = developmentDeptAddress,
            AddressId = developmentDeptAddress.Id,
            Wardrobes = new List<Wardrobe>()
        };

        // Szafy dla IT Support
        var wardrobe1 = new Wardrobe
        {
            Id = Guid.NewGuid(),
            Name = "Szafa sprzętowa A1",
            Model = "StoragePro 3000",
            SerialNumber = "SP3000-2024-001",
            SoftwareVersion = "v2.1.5",
            IsOnline = true,
            CompanyId = techCorp.Id,
            DepartmentId = itSupportDept.Id,
            Drawers = new List<Drawer>()
        };

        // Szuflada 1-1
        var drawer1 = new Drawer
        {
            Id = Guid.NewGuid(),
            Name = "Szuflada 1-1",
            X = 0,
            Y = 0,
            WidthDrawer = 50,
            HeightDrawer = 20,
            LengthDrawer = 100,
            TotalPartitions = 2,
            WardrobeId = wardrobe1.Id,
        };

        var partition1 = new Partition
        {
            Id = Guid.NewGuid(),
            Z = 1,
            HeightPartition = 100,
            WidthPartition = 100,
            LengthPartition = 10,
            DrawerId = drawer1.Id,
            ItemPartitions = new List<ItemPartition>
            {
                new ItemPartition
                {
                    Id = Guid.NewGuid(),
                    Item = new Item
                    {
                        Id = Guid.NewGuid(),
                        Name = "Kabel HDMI 2m",
                        Description = "Kabel HDMI 2.0 do monitorów",
                        Status = "Dostępny",
                    }
                }
            }
        };

        drawer1.Partitions.Add(partition1);

        // Szuflada 1-2
        var drawer2 = new Drawer
        {
            Id = Guid.NewGuid(),
            Name = "Szuflada 1-2",
            X = 0,
            Y = 1,
            WidthDrawer = 50,
            HeightDrawer = 20,
            LengthDrawer = 100,
            TotalPartitions = 2,
            WardrobeId = wardrobe1.Id,
        };

        var partition2 = new Partition
        {
            Id = Guid.NewGuid(),
            Z = 1,
            HeightPartition = 100,
            WidthPartition = 50,
            LengthPartition = 100,
            DrawerId = drawer2.Id,
            ItemPartitions = new List<ItemPartition>
            {
                new ItemPartition
                {
                    Id = Guid.NewGuid(),
                    Item = new Item
                    {
                        Id = Guid.NewGuid(),
                        Name = "Klawiatura USB",
                        Description = "Klawiatura membranowa Dell KB216",
                        Status = "Dostępny",
                    }
                }
            }
        };

        var partition3 = new Partition
        {
            Id = Guid.NewGuid(),
            Z = 2,
            HeightPartition = 100,
            WidthPartition = 50,
            LengthPartition = 10,
            DrawerId = drawer2.Id,
            ItemPartitions = new List<ItemPartition>
            {
                new ItemPartition
                {
                    Id = Guid.NewGuid(),
                    Item = new Item
                    {
                        Id = Guid.NewGuid(),
                        Name = "Zasilacz uniwersalny",
                        Description = "Zasilacz 65W USB-C",
                        Status = "Niski stan",
                    }
                }
            }
        };

        drawer2.Partitions.Add(partition2);
        drawer2.Partitions.Add(partition3);

        wardrobe1.Drawers.Add(drawer1);
        wardrobe1.Drawers.Add(drawer2);

        // Szafa dla Development
        var wardrobe2 = new Wardrobe
        {
            Id = Guid.NewGuid(),
            Name = "Szafa deweloperska D1",
            Model = "DevStorage 5000",
            SerialNumber = "DS5000-2024-002",
            SoftwareVersion = "v3.0.1",
            IsOnline =  true,
            CompanyId = techCorp.Id,
            DepartmentId = developmentDept.Id,
            Drawers = new List<Drawer>()
        };

        var drawer3 = new Drawer
        {
            Id = Guid.NewGuid(),
            Name = "Szuflada D1-1",
            X = 0,
            Y = 0,
            WidthDrawer = 60,
            HeightDrawer = 25,
            LengthDrawer = 100,
            TotalPartitions = 2,
            WardrobeId = wardrobe2.Id,
        };

        var partition4 = new Partition
        {
            Id = Guid.NewGuid(),
            Z = 1,
            HeightPartition = 100,
            WidthPartition = 50,
            LengthPartition = 10,
            DrawerId = drawer3.Id,
            ItemPartitions = new List<ItemPartition>
            {
                new ItemPartition
                {
                    Id = Guid.NewGuid(),
                    Item = new Item
                    {
                        Id = Guid.NewGuid(),
                        Name = "Raspberry Pi 4",
                        Description = "Raspberry Pi 4 Model B 8GB RAM",
                        Status = "Dostępny",
                    }
                }
            }
        };

        var partition5 = new Partition
        {
            Id = Guid.NewGuid(),
            Z = 2,
            HeightPartition = 100,
            WidthPartition = 50,
            LengthPartition = 10,
            DrawerId = drawer3.Id,
            ItemPartitions = new List<ItemPartition>
            {
                new ItemPartition
                {
                    Id = Guid.NewGuid(),
                    Item = new Item
                    {
                        Id = Guid.NewGuid(),
                        Name = "Kabel Ethernet Cat6",
                        Description = "Kabel sieciowy 3m",
                        Status = "Dostępny",
                    }
                }
            }
        };

        drawer3.Partitions.Add(partition4);
        drawer3.Partitions.Add(partition5);
        wardrobe2.Drawers.Add(drawer3);

        itSupportDept.Wardrobes.Add(wardrobe1);
        developmentDept.Wardrobes.Add(wardrobe2);
        techCorp.Departments.Add(itSupportDept);
        techCorp.Departments.Add(developmentDept);

        // Firma 2: MediHealth
        var mediHealthAddress = new AddressCompany
        {
            Id = Guid.NewGuid(),
            Street = "Lindleya",
            BuildingNumber = "4",
            PostalCode = "02-005",
            City = "Warszawa"
        };

        var mediHealth = new Company
        {
            Id = Guid.NewGuid(),
            Name = "Klinika MediZdrowie",
            Description = "Firma 2: MediHealth",
            Address = mediHealthAddress,
            AddressId = mediHealthAddress.Id,
            Departments = new List<Department>(),
            Wardrobes = new List<Wardrobe>()
        };

        // Działy MediHealth
        var emergencyDeptAddress = new AddressDepartment
        {
            Id = Guid.NewGuid(),
            Street = "Lindleya",
            BuildingNumber = "4A",
            PostalCode = "02-005",
            City = "Warszawa"
        };

        var emergencyDept = new Department
        {
            Id = Guid.NewGuid(),
            Name = "Oddział Ratunkowy",
            Description = "Oddział ratunkowy - pomoc w nagłych wypadkach",
            CompanyId = mediHealth.Id,
            Address = emergencyDeptAddress,
            AddressId = emergencyDeptAddress.Id,
            Wardrobes = new List<Wardrobe>()
        };

        var laboratoryDeptAddress = new AddressDepartment
        {
            Id = Guid.NewGuid(),
            Street = "Lindleya",
            BuildingNumber = "4B",
            PostalCode = "02-005",
            City = "Warszawa"
        };

        var laboratoryDept = new Department
        {
            Id = Guid.NewGuid(),
            Name = "Laboratorium",
            Description = "Laboratorium medyczne - badania i diagnostyka",
            CompanyId = mediHealth.Id,
            Address = laboratoryDeptAddress,
            AddressId = laboratoryDeptAddress.Id,
            Wardrobes = new List<Wardrobe>()
        };

        // Szafa dla Emergency
        var wardrobe3 = new Wardrobe
        {
            Id = Guid.NewGuid(),
            Name = "Szafa medyczna E1",
            Model = "MediStore 2000",
            SerialNumber = "MS2000-2024-001",
            SoftwareVersion = "v1.5.0",
            IsOnline =  true,
            CompanyId = mediHealth.Id,
            DepartmentId = emergencyDept.Id,
            Drawers = new List<Drawer>()
        };

        var drawer4 = new Drawer
        {
            Id = Guid.NewGuid(),
            Name = "Szuflada E1-1",
            X = 0,
            Y = 0,
            WidthDrawer = 40,
            HeightDrawer = 15,
            LengthDrawer = 100,
            TotalPartitions = 2,
            WardrobeId = wardrobe3.Id,
        };

        var partition6 = new Partition
        {
            Id = Guid.NewGuid(),
            Z = 1,
            HeightPartition = 100,
            WidthPartition = 50,
            LengthPartition = 10,
            DrawerId = drawer4.Id,
            ItemPartitions = new List<ItemPartition>
            {
                new ItemPartition
                {
                    Id = Guid.NewGuid(),
                    Item = new Item
                    {
                        Id = Guid.NewGuid(),
                        Name = "Rękawice medyczne L",
                        Description = "Rękawice lateksowe rozmiar L",
                        Status = "Dostępny",
                    }
                }
            }
        };

        var partition7 = new Partition
        {
            Id = Guid.NewGuid(),
            Z = 2,
            HeightPartition = 100,
            WidthPartition = 50,
            LengthPartition = 10,
            DrawerId = drawer4.Id,
            ItemPartitions = new List<ItemPartition>
            {
                new ItemPartition
                {
                    Id = Guid.NewGuid(),
                    Item = new Item
                    {
                        Id = Guid.NewGuid(),
                        Name = "Maseczki chirurgiczne",
                        Description = "Maseczki jednorazowe 3-warstwowe",
                        Status = "Dostępny",
                    }
                }
            }
        };

        drawer4.Partitions.Add(partition6);
        drawer4.Partitions.Add(partition7);

        var drawer5 = new Drawer
        {
            Id = Guid.NewGuid(),
            Name = "Szuflada E1-2",
            X = 0,
            Y = 1,
            WidthDrawer = 40,
            HeightDrawer = 15,
            LengthDrawer = 100,
            TotalPartitions = 2,
            WardrobeId = wardrobe3.Id,
        };

        var partition8 = new Partition
        {
            Id = Guid.NewGuid(),
            Z = 1,
            HeightPartition = 100,
            WidthPartition = 50,
            LengthPartition = 10,
            DrawerId = drawer5.Id,
            ItemPartitions = new List<ItemPartition>
            {
                new ItemPartition
                {
                    Id = Guid.NewGuid(),
                    Item = new Item
                    {
                        Id = Guid.NewGuid(),
                        Name = "Strzykawki 10ml",
                        Description = "Strzykawki jednorazowe 10ml",
                        Status = "Dostępny",
                    }
                }
            }
        };

        var partition9 = new Partition
        {
            Id = Guid.NewGuid(),
            Z = 2,
            HeightPartition = 100,
            WidthPartition = 50,
            LengthPartition = 10,
            DrawerId = drawer5.Id,
            ItemPartitions = new List<ItemPartition>
            {
                new ItemPartition
                {
                    Id = Guid.NewGuid(),
                    Item = new Item
                    {
                        Id = Guid.NewGuid(),
                        Name = "Opatrunki sterylne",
                        Description = "Opatrunki 10x10cm",
                        Status = "Niski stan",
                    }
                }
            }
        };

        drawer5.Partitions.Add(partition8);
        drawer5.Partitions.Add(partition9);

        wardrobe3.Drawers.Add(drawer4);
        wardrobe3.Drawers.Add(drawer5);

        // Szafa dla Laboratory
        var wardrobe4 = new Wardrobe
        {
            Id = Guid.NewGuid(),
            Name = "Szafa laboratoryjna L1",
            Model = "LabStore 4000",
            SerialNumber = "LS4000-2024-001",
            SoftwareVersion = "v2.3.0",
            IsOnline =  true,
            CompanyId = mediHealth.Id,
            DepartmentId = laboratoryDept.Id,
            Drawers = new List<Drawer>()
        };

        var drawer6 = new Drawer
        {
            Id = Guid.NewGuid(),
            Name = "Szuflada L1-1",
            X = 0,
            Y = 0,
            WidthDrawer = 45,
            HeightDrawer = 18,
            LengthDrawer = 100,
            TotalPartitions = 2,
            WardrobeId = wardrobe4.Id,
        };

        var partition10 = new Partition
        {
            Id = Guid.NewGuid(),
            Z = 1,
            HeightPartition = 100,
            WidthPartition = 50,
            LengthPartition = 10,
            DrawerId = drawer6.Id,
            ItemPartitions = new List<ItemPartition>
            {
                new ItemPartition
                {
                    Id = Guid.NewGuid(),
                    Item = new Item
                    {
                        Id = Guid.NewGuid(),
                        Name = "Probówki z EDTA",
                        Description = "Probówki do badań krwi 5ml",
                        Status = "Dostępny",
                    }
                }
            }
        };

        var partition11 = new Partition
        {
            Id = Guid.NewGuid(),
            Z = 2,
            HeightPartition = 100,
            WidthPartition = 50,
            LengthPartition = 10,
            DrawerId = drawer6.Id,
            ItemPartitions = new List<ItemPartition>
            {
                new ItemPartition
                {
                    Id = Guid.NewGuid(),
                    Item = new Item
                    {
                        Id = Guid.NewGuid(),
                        Name = "Pipety automatyczne",
                        Description = "Pipety 100-1000µl",
                        Status = "Dostępny",
                    }
                }
            }
        };

        drawer6.Partitions.Add(partition10);
        drawer6.Partitions.Add(partition11);
        wardrobe4.Drawers.Add(drawer6);

        emergencyDept.Wardrobes.Add(wardrobe3);
        laboratoryDept.Wardrobes.Add(wardrobe4);
        mediHealth.Departments.Add(emergencyDept);
        mediHealth.Departments.Add(laboratoryDept);

        companies.Add(techCorp);
        companies.Add(mediHealth);

        return companies;
    }
}