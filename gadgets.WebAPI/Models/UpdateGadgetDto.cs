using gadgets.Application.gadgets.Commands.UpdateGadget;
using gadgets.Application.Common.Mapping;
using AutoMapper;
namespace gadgets.WebAPI.Models
{
    public class UpdateGadgetDto : IMapWIth<UpdateGadgetCommand>
    {
        public Guid Id { get; set; }
        public int gadgetId { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateGadgetDto, UpdateGadgetCommand>()
                .ForMember(gadgetCommand => gadgetCommand.Id,
                    opt => opt.MapFrom(gadgetDto => gadgetDto.Id))
                .ForMember(gadgetCommand => gadgetCommand.Title,
                    opt => opt.MapFrom(gadgetDto => gadgetDto.Title))
                .ForMember(gadgetCommand => gadgetCommand.Details,
                opt => opt.MapFrom(gadgetDto => gadgetDto.Details));
        }
    }
}
