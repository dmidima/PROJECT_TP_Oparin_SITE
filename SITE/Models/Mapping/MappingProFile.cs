using AutoMapper;
using SITE.Data.Identity;

namespace SITE.Models.Mapping
{
    public class MappingProFile : Profile
    {
        public MappingProFile()
        {
            this.CreateMap<Student, StudentModel>()
                .ForMember(dst => dst.BirthData,
                opt => opt.MapFrom(src => src.BirthData.Date))

                .ForMember(dst => dst.FullName,
                opt => opt.MapFrom(src => src.Name + "" + src.Id));

            this.CreateMap<StudentModel, Student>();
        }
    }
}
