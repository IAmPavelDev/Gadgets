using gadgets.Application.gadgets.Commands.CreateGadget;
using gadgets.Application.Common.Mapping;
using AutoMapper;
namespace gadgets.WebAPI.Models
{
    public class CreateGadgetDto : IMapWIth<CreateGadgetCommand>
    {
        public int gadgetId { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateGadgetDto, CreateGadgetCommand>()
                .ForMember(gadgetCommand => gadgetCommand.Title,
                    opt => opt.MapFrom(gadgetDto => gadgetDto.Title))
                .ForMember(gadgetCommand => gadgetCommand.Details,
                opt => opt.MapFrom(gadgetDto => gadgetDto.Details));
        }
    }
}