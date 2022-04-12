using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using gadgets.Domain;
using AutoMapper;
namespace gadgets.Application.gadgets.Queries.GetGadgetList
{
    public class GadgetLookupDto
    {
        public Guid Id { get; set; }
        public string Title{ get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<gadget, GadgetLookupDto>()
                .ForMember(gadgetDto => gadgetDto.Id,
                opt => opt.MapFrom(gadget => gadget.Id))
                .ForMember(gadgetDto => gadgetDto.Title,
                opt => opt.MapFrom(gadget => gadget.Title))
                .ForMember(gadgetDto => gadgetDto.Id,
                opt => opt.MapFrom(gadget => gadget.Id));
        }
    }
}
