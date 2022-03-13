using AutoMapper;
using WebApi.DBOperations;
using System.Linq;
using System.Collections.Generic;
using System;
using FluentValidation;


namespace WebApi.Application.GenreOperations.Queries.GetGenreDetail
{
    public class GetGenreDetailQueryValidator : AbstractValidator<GetGenreDetailQuery>
    {
        public GetGenreDetailQueryValidator()
        {
            RuleFor(query=> query.GenreId).GreaterThan(0);
        }
    }
}