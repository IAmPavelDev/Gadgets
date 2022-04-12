using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using gadgets.Application.Common.Mapping;
using gadgets.Domain;
using AutoMapper;
namespace gadgets.Application.gadgets.Queries.GetGadgetDetails
{
    public class gadgetsDetailsVm : IMapWIth<gadget>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<gadget, gadgetsDetailsVm>()
                .ForMember(gadgetVM => gadgetVM.Title,
                opt => opt.MapFrom(gadget => gadget.Title))
                .ForMember(gadgetVm => gadgetVm.Details,
                    opt => opt.MapFrom(gadget => gadget.Details))
                .ForMember(gadgetVm => gadgetVm.Id,
                    opt => opt.MapFrom(gadget => gadget.Id))
                .ForMember(gadgetVm => gadgetVm.CreationDate,
                    opt => opt.MapFrom(gadget => gadget.CreationDate))
                .ForMember(gadgetVm => gadgetVm.EditDate,
                    opt => opt.MapFrom(gadget => gadget.EditDate));
        }
    }
}
