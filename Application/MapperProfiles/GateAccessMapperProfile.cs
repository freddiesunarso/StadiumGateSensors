using Application.Gates.Commands.PublishAddGateAccessEvent;
using AutoMapper;
using Domain.Entities;

namespace Application.MapperProfiles
{
    public class GateAccessMapperProfile : Profile
    {
        public GateAccessMapperProfile()
        {
            CreateMap<PublishAddGateAccessEventCommand, GateAccess>();
        }
    }
}
