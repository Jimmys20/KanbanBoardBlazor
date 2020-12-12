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
                .ForMember(dest => dest.stageKey, opt => opt.MapFrom(src => src.stageId.ToString()))
                .ReverseMap()
                .ForMember(dest => dest.stageId, opt => opt.MapFrom(src => long.Parse(src.stageKey)));

            CreateMap<Issue, IssueDto>()
                .ForMember(dest => dest.stageKey, opt => opt.MapFrom(src => src.stageId.HasValue ? src.stageId.Value.ToString() : default(string)))
                .ReverseMap()
                .ForMember(dest => dest.stageId, opt => opt.MapFrom(src => !string.IsNullOrEmpty(src.stageKey) ? long.Parse(src.stageKey) : default(long?)));

            CreateMap<User, UserDto>().ReverseMap();
            //CreateMap<long, UserEntity>()
            //    .ConvertUsing(o => new UserEntity { userId = o });
            //CreateMap<UserEntity, long>()
            //    .ConvertUsing(o => o.userId);
        }
    }
}
