using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApi;
using WebApi.DBOperations;
using AutoMapper;
using WebApi.Entities;


namespace WebApi.Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommand
    {
        public CreateAuthorModel Model {get; set;}
        private readonly IBookStoreDBContext _dbContext;
        private readonly IMapper _mapper;

        public CreateAuthorCommand(BookStoreDBContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public void Handle(){
            
            var author = _dbContext.Authors.SingleOrDefault(x=> 
                (x.Name == Model.Name) && 
                (x.Surname == Model.Surname)&&
                (x.Birthday == Model.Birthday));

            if(author != null)
            {
               throw new InvalidOperationException("Author already exists.");
            }

            author = _mapper.Map<Author>(Model);
            _dbContext.Authors.Add(author);
            _dbContext.SaveChanges();
        }

        public class CreateAuthorModel
        {

            public string Name { get; set; }
            public string Surname { get; set; }
            public DateTime? Birthday { get; set; }

        }
    }

    
}