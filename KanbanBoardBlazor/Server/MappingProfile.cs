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
                .ForMember(dest => dest.Assignees, opt => opt.MapFrom(src => src.Assignees.Select(a => new UserDto
                {
                    FirstName = a.User.FirstName,
                    LastName = a.User.LastName,
                    UserId = a.User.UserId
                })))
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.IssueTags.Select(a => new TagDto
                {
                    TagId = a.Tag.TagId,
                    CssClass = a.Tag.CssClass,
                    Text = a.Tag.Text
                })))
                .ForMember(dest => dest.Customers, opt => opt.MapFrom(src => src.IssueCustomers.Select(a => new CustomerDto
                {
                    CustomerId = a.Customer.CustomerId,
                    Name = a.Customer.Name
                })))
                .ReverseMap()
                .ForMember(dest => dest.StageId, opt => opt.MapFrom(src => !string.IsNullOrEmpty(src.StageKey) ? long.Parse(src.StageKey) : default(long?)))
                .ForMember(dest => dest.Assignees, opt => opt.MapFrom(src => src.Assignees.Select(a => new Assignment
                {
                    UserId = a.UserId//,
                    //User = new User
                    //{
                    //    UserId = a.UserId,
                    //    FirstName = a.FirstName,
                    //    LastName = a.LastName
                    //}
                })))
                .ForMember(dest => dest.IssueTags, opt => opt.MapFrom(src => src.Tags.Select(a => new IssueTag
                {
                    TagId = a.TagId
                })))
                .ForMember(dest => dest.IssueCustomers, opt => opt.MapFrom(src => src.Customers.Select(a => new IssueCustomer
                {
                    CustomerId = a.CustomerId
                })));
            //CreateMap<Assignment, UserDto>()
            //    .ConvertUsing((a, b, mapper) => mapper.Mapper.Map<UserDto>(a.User));

            //CreateMap<UserDto, Assignment>()
            //    .ConvertUsing((a, b, mapper) => b.User = mapper.Mapper.Map<Assignment>(a));

            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Tag, TagDto>().ReverseMap();
            CreateMap<Customer, CustomerDto>().ReverseMap();

            CreateMap<Application, ApplicationDto>().ReverseMap();
            //CreateMap<long, UserEntity>()
            //    .ConvertUsing(o => new UserEntity { userId = o });
            //CreateMap<UserEntity, long>()
            //    .ConvertUsing(o => o.userId);
        }
    }
}
