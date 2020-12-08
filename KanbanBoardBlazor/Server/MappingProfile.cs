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
            CreateMap<ProjectEntity, Project>().ReverseMap();

            CreateMap<StageEntity, Stage>()
                .ForMember(dest => dest.stageKey, opt => opt.MapFrom(src => src.stageId.ToString()))
                .ReverseMap()
                .ForMember(dest => dest.stageId, opt => opt.MapFrom(src => long.Parse(src.stageKey)));

            CreateMap<IssueEntity, Issue>().ReverseMap();
        }
    }
}
