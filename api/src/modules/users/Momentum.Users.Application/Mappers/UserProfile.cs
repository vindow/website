using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Momentum.Users.Application.Mappers
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<Core.Models.User, Dto.UserDto>()
                .ForMember(dest => dest.UserId, opts => opts.MapFrom(src => src.Id))
                .ForMember(dst => dst.IssuedAt, opts => opts.MapFrom(src => src.Authentication.IssuedAt)) //TODO: Nullable
                .ForMember(dst => dst.RefreshToken, opts => opts.MapFrom(src => src.Authentication.RefreshToken));//TODO: Nullable
        }
    }
}
