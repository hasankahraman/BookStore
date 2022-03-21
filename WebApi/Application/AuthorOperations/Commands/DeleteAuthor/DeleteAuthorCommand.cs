using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApi;
using WebApi.DBOperations;

namespace WebApi.Application.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        private readonly IBookStoreDBContext _context;
        public int AuthorId { get; set; }

        public DeleteAuthorCommand(BookStoreDBContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var author = _context.Authors.SingleOrDefault(x=> x.Id == AuthorId);

            if(author == null)
            {
                throw new InvalidOperationException("Author couldn't found.");
            }
            if (_context.Books.Any(x => x.AuthorId == AuthorId))
            {
                throw new Exception("An author who has published books can not be deleted. Delete author's books first.");
            }

            _context.Authors.Remove(author);
            _context.SaveChanges();
        }
    }
}