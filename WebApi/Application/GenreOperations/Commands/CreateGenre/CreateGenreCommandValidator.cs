using AutoMapper;
using WebApi.DBOperations;
using System.Linq;
using System.Collections.Generic;
using System;
using FluentValidation;


namespace WebApi.Application.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommandValidator : AbstractValidator<CreateGenreCommand>
    {
        public CreateGenreCommandValidator()
        {
            RuleFor(command=> command.Model.Name).NotEmpty().MinimumLength(4);
        }
    }
}