using AutoMapper;
using InvenTracker.Application.Dtos;
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
            .ForMember(dest =>dest.Departments, opt=>opt.MapFrom(src => src.Departments));
        
        CreateMap<Department, GetDepartmentDto>()
            .ForMember(dest => dest.AddressDepartment, opt => opt.MapFrom(src => src.Address));
        
        CreateMap<CreateCompanyDto, Company>()
            .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.AddressCompany));
        
        CreateMap<AddressDepartment, GetAddressDepartmentDto>().ReverseMap();
        
        CreateMap<AddressCompany, GetAddressCompanyDto>().ReverseMap();
    }
}