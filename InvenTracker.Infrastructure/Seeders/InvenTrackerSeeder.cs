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
        }
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
            CompanyId = techCorp.Id,
            DepartmentId = itSupportDept.Id,
            Drawers = new List<Drawer>()
        };

        // Szuflady dla szafy A1
        var drawer1 = new Drawer
        {
            Id = Guid.NewGuid(),
            Name = "Szuflada 1-1",
            X = 0,
            Y = 0,
            Z = 0,
            Width = 50,
            Height = 20,
            WardrobeId = wardrobe1.Id,
            Items = new List<Item>
            {
                new Item
                {
                    Id = Guid.NewGuid(),
                    Name = "Kabel HDMI 2m",
                    Description = "Kabel HDMI 2.0 do monitorów",
                    Status = "Dostępny",
                    Quantity = 15,
                    Partition = 1
                },
                new Item
                {
                    Id = Guid.NewGuid(),
                    Name = "Mysz bezprzewodowa Logitech",
                    Description = "Mysz optyczna Logitech M185",
                    Status = "Dostępny",
                    Quantity = 8,
                    Partition = 2
                }
            }
        };

        var drawer2 = new Drawer
        {
            Id = Guid.NewGuid(),
            Name = "Szuflada 1-2",
            X = 0,
            Y = 1,
            Z = 0,
            Width = 50,
            Height = 20,
            WardrobeId = wardrobe1.Id,
            Items = new List<Item>
            {
                new Item
                {
                    Id = Guid.NewGuid(),
                    Name = "Klawiatura USB",
                    Description = "Klawiatura membranowa Dell KB216",
                    Status = "Dostępny",
                    Quantity = 12,
                    Partition = 1
                },
                new Item
                {
                    Id = Guid.NewGuid(),
                    Name = "Zasilacz uniwersalny",
                    Description = "Zasilacz 65W USB-C",
                    Status = "Niski stan",
                    Quantity = 3,
                    Partition = 2
                }
            }
        };

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
            Z = 0,
            Width = 60,
            Height = 25,
            WardrobeId = wardrobe2.Id,
            Items = new List<Item>
            {
                new Item
                {
                    Id = Guid.NewGuid(),
                    Name = "Raspberry Pi 4",
                    Description = "Raspberry Pi 4 Model B 8GB RAM",
                    Status = "Dostępny",
                    Quantity = 5,
                    Partition = 1
                },
                new Item
                {
                    Id = Guid.NewGuid(),
                    Name = "Kabel Ethernet Cat6",
                    Description = "Kabel sieciowy 3m",
                    Status = "Dostępny",
                    Quantity = 20,
                    Partition = 2
                }
            }
        };

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
            Z = 0,
            Width = 40,
            Height = 15,
            WardrobeId = wardrobe3.Id,
            Items = new List<Item>
            {
                new Item
                {
                    Id = Guid.NewGuid(),
                    Name = "Rękawice medyczne L",
                    Description = "Rękawice lateksowe rozmiar L",
                    Status = "Dostępny",
                    Quantity = 100,
                    Partition = 1
                },
                new Item
                {
                    Id = Guid.NewGuid(),
                    Name = "Maseczki chirurgiczne",
                    Description = "Maseczki jednorazowe 3-warstwowe",
                    Status = "Dostępny",
                    Quantity = 200,
                    Partition = 2
                }
            }
        };

        var drawer5 = new Drawer
        {
            Id = Guid.NewGuid(),
            Name = "Szuflada E1-2",
            X = 0,
            Y = 1,
            Z = 0,
            Width = 40,
            Height = 15,
            WardrobeId = wardrobe3.Id,
            Items = new List<Item>
            {
                new Item
                {
                    Id = Guid.NewGuid(),
                    Name = "Strzykawki 10ml",
                    Description = "Strzykawki jednorazowe 10ml",
                    Status = "Dostępny",
                    Quantity = 50,
                    Partition = 1
                },
                new Item
                {
                    Id = Guid.NewGuid(),
                    Name = "Opatrunki sterylne",
                    Description = "Opatrunki 10x10cm",
                    Status = "Niski stan",
                    Quantity = 15,
                    Partition = 2
                }
            }
        };

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
            Z = 0,
            Width = 45,
            Height = 18,
            WardrobeId = wardrobe4.Id,
            Items = new List<Item>
            {
                new Item
                {
                    Id = Guid.NewGuid(),
                    Name = "Probówki z EDTA",
                    Description = "Probówki do badań krwi 5ml",
                    Status = "Dostępny",
                    Quantity = 80,
                    Partition = 1
                },
                new Item
                {
                    Id = Guid.NewGuid(),
                    Name = "Pipety automatyczne",
                    Description = "Pipety 100-1000µl",
                    Status = "Dostępny",
                    Quantity = 6,
                    Partition = 2
                }
            }
        };

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