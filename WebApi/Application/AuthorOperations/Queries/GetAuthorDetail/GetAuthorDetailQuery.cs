using System.Collections.Generic;
using System.Linq;
using WebApi.Common;
using WebApi.DBOperations;
using System;
using Microsoft.AspNetCore.Mvc;
using WebApi;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Application.AuthorOperations.Queries.GetAuthorDetail
{
    public class GetAuthorDetailQuery
    {
        private readonly IBookStoreDBContext _dbContext;
        private readonly IMapper _mapper;
        public int AuthorId {get; set;}

        public GetAuthorDetailQuery(BookStoreDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public AuthorDetailViewModel Handle()
        {
            var author = _dbContext.Authors.SingleOrDefault(author=> author.Id == AuthorId);

            if(author is null)
                throw new InvalidOperationException("Author couldn't be found.");

            AuthorDetailViewModel vm = _mapper.Map<AuthorDetailViewModel>(author); //new AuthorDetailViewModel();
            return vm;
        }

        public class AuthorDetailViewModel
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public DateTime? Birthday { get; set; }
        }
    }

}