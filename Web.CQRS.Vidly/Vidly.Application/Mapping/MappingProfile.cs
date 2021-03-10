using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Vidly.Application.Functions.Movies;
using Vidly.Application.Functions.Movies.Dtos;
using Vidly.Domain.Entities;

namespace Vidly.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Movie, MovieDto>().ReverseMap();
        }
    }
}
