using Application.Contract.Features.Categories.Queries.GetCategoriesListWithEvents;
using Application.Contract.Features.Events;
using Application.Contract.Features.Events.Commands.CreateEvent;
using Application.Contract.Features.Events.Commands.DeleteEvent;
using Application.Contract.Features.Events.Commands.UpdateEvent;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contract.Features.Profiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, EventListVm>().ReverseMap();
            CreateMap<Event, EventDetailVm>().ReverseMap();
            CreateMap<Category, CategoryDto>();
            CreateMap<Category, CategoryListVm>();
            CreateMap<Category, CategoryEventListVm>();
            CreateMap<Event, CreateEventCommand>().ReverseMap();
            CreateMap<Event, UpdateEventCommand>().ReverseMap();
            CreateMap<Event, DeleteEventCommand>().ReverseMap();

        }
        
    }
}
