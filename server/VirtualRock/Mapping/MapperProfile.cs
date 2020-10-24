using System;
using AutoMapper;
using VirtualRock.Domain.Models;
using VirtualRock.Resources;

namespace VirtualRock.Mapping
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            CreateMap<NominationResource, Nomination>();
            CreateMap<SaveNominationResource, Nomination>();
            CreateMap<Nomination, NominationResource>();

            CreateMap<UserResource, User>();
            CreateMap<SaveUserResource, User>();
            CreateMap<User, UserResource>();
        }
    }
}
