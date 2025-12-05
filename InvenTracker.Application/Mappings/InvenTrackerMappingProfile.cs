using System.Net.Security;
using AutoMapper;
using InvenTracker.Application.Dtos;
using InvenTracker.Application.InvenTracker.Commands.CreateDepartaments;
using InvenTracker.Application.InvenTracker.Commands.CreateDrawers;
using InvenTracker.Application.InvenTracker.Commands.CreateWardrobe;
using InvenTracker.Application.InvenTracker.Commands.UpdateDepartaments;
using InvenTracker.Application.InvenTracker.Commands.UpdateDrawers;
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
            .ForMember(dest=>dest.Drawers, opt => opt.MapFrom(src => src.Drawers));

        CreateMap<CreateWardrobeCommand, Wardrobe>()
            .ForMember(dest => dest.CompanyId, opt => opt.MapFrom(src => src.CompanyId))
            .ForMember(dest => dest.DepartmentId, opt => opt.MapFrom(src => src.DepartmentId));

        CreateMap<UpdateWardrobeDto, Wardrobe>();
        
        CreateMap<Drawer, GetDrawerDto>();
        
        CreateMap<Drawer, GetDetailsDrawerDto>()
            .ForMember(dest=>dest.Items, opt=>opt.MapFrom(src=>src.Items));
       
        CreateMap<CreateDrawerCommand, Drawer>()
            .ForMember(dest => dest.WardrobeId, opt => opt.MapFrom(src => src.WardrobeId));

        CreateMap<UpdateDrawerCommand, Drawer>();
        
        CreateMap<Item, GetItemDto>().ReverseMap();
    }   
}