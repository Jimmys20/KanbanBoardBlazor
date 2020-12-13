using AutoMapper;
using KanbanBoardBlazor.Server.Dal.Entities;
using KanbanBoardBlazor.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanbanBoardBlazor.Server
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Project, ProjectDto>().ReverseMap();

            CreateMap<Stage, StageDto>()
                .ForMember(dest => dest.StageKey, opt => opt.MapFrom(src => src.StageId.ToString()))
                .ReverseMap()
                .ForMember(dest => dest.StageId, opt => opt.MapFrom(src => long.Parse(src.StageKey)));

            CreateMap<Issue, IssueDto>()
                .ForMember(dest => dest.StageKey, opt => opt.MapFrom(src => src.StageId.HasValue ? src.StageId.Value.ToString() : default(string)))
                .ReverseMap()
                .ForMember(dest => dest.StageId, opt => opt.MapFrom(src => !string.IsNullOrEmpty(src.StageKey) ? long.Parse(src.StageKey) : default(long?)));

            CreateMap<User, UserDto>().ReverseMap();
            //CreateMap<long, UserEntity>()
            //    .ConvertUsing(o => new UserEntity { userId = o });
            //CreateMap<UserEntity, long>()
            //    .ConvertUsing(o => o.userId);
        }
    }
}
