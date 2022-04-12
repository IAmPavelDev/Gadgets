using AutoMapper;
namespace gadgets.Application.Common.Mapping
{
    public class IMapWIth<T>
    {
        void Mapping(Profile profile) => 
            profile.CreateMap(typeof(T), GetType());
    }
}
