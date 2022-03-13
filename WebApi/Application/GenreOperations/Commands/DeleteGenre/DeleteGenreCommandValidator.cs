using AutoMapper;
using WebApi.DBOperations;
using System.Linq;
using System.Collections.Generic;
using System;
using FluentValidation;


namespace WebApi.Application.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommandValidator : AbstractValidator<DeleteGenreCommand>
    {
        public DeleteGenreCommandValidator()
        {
            RuleFor(command=> command.GenreId).GreaterThan(0);
        }
    }
}