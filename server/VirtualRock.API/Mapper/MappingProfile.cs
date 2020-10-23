using System;
using AutoMapper;
using VirtualRock.API.Resources;
using VirtualRock.Core.Models;

namespace VirtualRock.API.Mapper
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
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
