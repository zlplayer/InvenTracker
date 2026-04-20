using System.Net.Security;
using AutoMapper;
using InvenTracker.Application.Dtos;
using InvenTracker.Application.InvenTracker.Commands.CreateDepartaments;
using InvenTracker.Application.InvenTracker.Commands.CreateDivideDrawer;
using InvenTracker.Application.InvenTracker.Commands.CreateDrawers;
using InvenTracker.Application.InvenTracker.Commands.CreateItem;
using InvenTracker.Application.InvenTracker.Commands.CreateItemPartition;
using InvenTracker.Application.InvenTracker.Commands.CreatePartition;
using InvenTracker.Application.InvenTracker.Commands.CreateWardrobe;
using InvenTracker.Application.InvenTracker.Commands.LoginCommand;
using InvenTracker.Application.InvenTracker.Commands.RegisterCommand;
using InvenTracker.Application.InvenTracker.Commands.UpdateDepartaments;
using InvenTracker.Application.InvenTracker.Commands.UpdateDrawers;
using InvenTracker.Application.InvenTracker.Commands.UpdateItemPartition;
using InvenTracker.Application.InvenTracker.Commands.UpdatePartition;
using InvenTracker.Application.InvenTracker.Queries.GetAllPartitionsByDrawerId;
using InvenTracker.Domain.Entities;

namespace InvenTracker.Application.Mappings;

public class InvenTrackerMappingProfile: Profile
{
    public InvenTrackerMappingProfile()
    {
        CreateMap<Company, GetCompanyDto>()
            .ForMember(dest => dest.WardrobeCount, opt => opt.MapFrom(src => src.Wardrobes.Count))
            .ForMember(dest => dest.DepartementCount, opt => opt.MapFrom(src => src.Departments.Count))
            .ForMember(dest => dest.AddressCompany, opt => opt.MapFrom(src => src.Address));
        
        CreateMap<Company, GetDetailsCompanyDto>()
            .ForMember(dest=>dest.AddressCompany, opt => opt.MapFrom(src => src.Address))
            .ForMember(dest =>dest.Departments, opt=>opt.MapFrom(src => src.Departments))
            .ForMember(dest=>dest.Wardrobe,  opt=>opt.MapFrom(src => src.Wardrobes));
        
        CreateMap<CreateCompanyDto, Company>()
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.AddressCompany));
        
        CreateMap<AddressCompany, GetAddressCompanyDto>().ReverseMap();

        CreateMap<Department, GetDepartmentDto>()
            .ForMember(dest => dest.AddressDepartment, opt => opt.MapFrom(src => src.Address))
            .ForMember(dest => dest.Wardrobe, opt => opt.MapFrom(src => src.Wardrobes));

        CreateMap<CreateDepartmentDto, Department>()
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.AddressDepartment));

        CreateMap<CreateDepartmentCommand, Department>()
            .ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.CompanyId))
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.AddressDepartment));

        CreateMap<UpdateDepartmentCommand, Department>()
            .ForMember(dest=>dest.Address,opt=>opt.MapFrom(src=>src.AddressDepartment));
        
        CreateMap<AddressDepartment, GetAddressDepartmentDto>().ReverseMap();
        
        CreateMap<Wardrobe,  GetWardrobeDto>().ReverseMap();
        
        CreateMap<Wardrobe, GetDetailsWardrobeDto>()
            .ForMember(dest=>dest.Drawers, opt => opt.MapFrom(src => src.Drawers))
            .ForMember(dest=>dest.Users, opt=>opt.MapFrom(src=>src.ResponsibleUsers.Select(r => r.User)));

        CreateMap<CreateWardrobeCommand, Wardrobe>()
            .ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.CompanyId))
            .ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(src => src.DepartmentId));

        CreateMap<UpdateWardrobeDto, Wardrobe>();
        
        CreateMap<Drawer, GetDrawerDto>();

        CreateMap<Drawer, GetDetailsDrawerDto>();


        CreateMap<CreateDrawerCommand, Drawer>()
            .ForMember(dest => dest.WardrobeId, opt => opt.MapFrom(src => src.WardrobeId));

        CreateMap<UpdateDrawerCommand, Drawer>();

        CreateMap<CreateDivideDrawerCommand, Drawer>()
            .ForMember(dest => dest.ParentDrawerId, opt => opt.MapFrom(src => src.DrawerId))
            .ForMember(dest => dest.AvailablePartitions, opt => opt.MapFrom(src => src.TotalPartitions))
            .ForMember(dest => dest.WidthDrawer, opt => opt.MapFrom(src => src.Width))
            .ForMember(dest => dest.HeightDrawer, opt => opt.MapFrom(src => src.Height))
            .ForMember(dest => dest.LengthDrawer, opt => opt.MapFrom(src => src.Z));
        
        CreateMap<Item, GetItemDto>().ReverseMap();

        CreateMap<CreateItemCommand, Item>();
        
        CreateMap<UpdateItemDto, Item>().ReverseMap();

        CreateMap<Item, GetDetailsItemDto>();
        
        CreateMap<UpdatePasswordDto, User>().ReverseMap();
        CreateMap<UpdateUserDto, User>().ReverseMap();
        CreateMap<User, UserDto>()
            .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.Name)).ReverseMap();
        CreateMap<RegisterDto, RegisterCommand>();
        CreateMap<LoginDto, LoginCommand>();

        CreateMap<RegisterCommand, User>()
            .ForMember(dest => dest.PasswordHash, opt => opt.MapFrom(src => src.Password));


        CreateMap<ItemPartition, GetItemDto>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Item.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Item.Name))
            .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Item.Description))
            .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Item.Status))
            .ForMember(dest => dest.MinimumQuantityItem, opt => opt.MapFrom(src => src.MinimumQuantityItem))
            .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.QuantityItem))
            .ForMember(dest => dest.IsPackaged, opt => opt.MapFrom(src => src.Item.IsPackaged))
            .ForMember(dest => dest.QuantityPerPackage, opt => opt.MapFrom(src => src.Item.QuantityPerPackage));

        CreateMap<Partition, GetDetailsPartitionsDto>()
            .ForMember(dest => dest.Item, opt => opt.MapFrom(src => src.ItemPartitions.FirstOrDefault()))
            .ReverseMap().ForMember(dest => dest.ItemPartitions, opt => opt.MapFrom(src => src.Item));
        CreateMap<CreatePartitionCommand, Partition>();
        CreateMap<CreatePartitionDto, Partition>().ReverseMap();
        CreateMap<UpdatePartitionCommand, Partition>().ReverseMap();
        CreateMap<Partition, GetAllPartitionsByDrawerIdQuery>().ReverseMap();
        
        CreateMap<CreateItemPartitionCommand, ItemPartition>();
        CreateMap<UpdateItemPartitionCommand, ItemPartition>();

        CreateMap<ItemHistory, GetItemHistoryDto>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User != null
                ? $"{src.User.FirstName} {src.User.LastName}"
                : "Nieznany"));
    }   
}