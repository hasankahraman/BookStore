using AutoMapper;
using WebApi.DBOperations;
using System.Linq;
using System.Collections.Generic;
using System;
using FluentValidation;


namespace WebApi.Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommand>
    {
        public UpdateGenreCommandValidator()
        {
            RuleFor(command=> command.Model.Name).MinimumLength(4).When(x=> x.Model.Name != string.Empty);
        }
    }
}