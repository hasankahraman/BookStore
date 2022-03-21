using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApi;
using WebApi.DBOperations;

namespace WebApi.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand
    {
        private readonly IBookStoreDBContext _context;
        public int AuthorId { get; set; }
        public UpdateAuthorModel Model{get;set;}

        public UpdateAuthorCommand( BookStoreDBContext context)
        {
            _context = context;
        }

        public void Handle(){

            var author = _context.Authors.SingleOrDefault(x=> x.Id == AuthorId);

            if(author == null)
            {
                throw new InvalidOperationException("Author couldn't be found.");
            }

            author.Name = Model.Name != default ? Model.Name : author.Name;
            author.Surname = Model.Surname != default ? Model.Surname : author.Surname;
            author.Birthday = Model.Birthday != default ? Model.Birthday : author.Birthday;
            _context.SaveChanges();

        }
    }

    public class UpdateAuthorModel{

        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime? Birthday { get; set; }

    }
}