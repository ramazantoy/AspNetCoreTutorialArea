using System.Collections.Generic;
using AutoMapper;
using Project_6.Business.Mappings.AutoMapper;

namespace Project_6.Business.Helpers
{
    public static class ProfileHelper
    {
        public static List<Profile> GetMapperProfiles()
        {
            return new List<Profile>()
            {
                new ProvidedServiceProfile(),
                new AdvertisementProfile(),
                new AppUserProfile(),
                new GenderProfile(),
            };
        }
    }
}