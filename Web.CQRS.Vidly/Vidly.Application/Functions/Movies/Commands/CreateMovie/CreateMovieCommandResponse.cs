﻿using System;
using System.Collections.Generic;
using System.Text;
using Vidly.Application.Responses;

namespace Vidly.Application.Functions.Movies.Commands.CreateMovie
{
    public class CreateMovieCommandResponse : BaseResponse
    {
        public int? Id { get; set; }

        public CreateMovieCommandResponse() : base()
        {
        }
        public CreateMovieCommandResponse(string message) : base(message)
        {
        }

        public CreateMovieCommandResponse(string message, bool success) : base(message, success)
        {
        }

        public CreateMovieCommandResponse(int id)
        {
            Id = id;
        }
    }
}
