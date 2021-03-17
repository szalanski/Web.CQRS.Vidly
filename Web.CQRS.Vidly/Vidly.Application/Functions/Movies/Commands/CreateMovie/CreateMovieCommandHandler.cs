using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using MediatR;
using Vidly.Application.Contracts.Presistence;
using Vidly.Application.Functions.Movies.Commands.CreateMovie;
using Vidly.Domain.Entities;

namespace Vidly.Application.Functions.Movies.Commands
{
    public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommand, CreateMovieCommandResponse>
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IMapper _mapper;

        public CreateMovieCommandHandler(IMapper mapper, IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
        }

        public async Task<CreateMovieCommandResponse> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {
            var validator = new CreateMovieCommandValidator();
            var validationResult = await validator.ValidateAsync(request);
            if(!validationResult.IsValid)
                return new CreateMovieCommandResponse(validationResult);
         
            var movie = _mapper.Map<Movie>(request);
            movie = await _movieRepository.AddsAsync(movie);
            return new CreateMovieCommandResponse(movie.Id);
        }
    }
}
