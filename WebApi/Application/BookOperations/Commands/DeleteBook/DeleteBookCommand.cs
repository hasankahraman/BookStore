using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebApi;
using WebApi.DBOperations;

namespace WebApi.Application.BookOperations.Commands.DeleteBook
{
    public class DeleteBookCommand
    {
        private readonly IBookStoreDBContext _context;
        public int BookId { get; set; }

        public DeleteBookCommand(BookStoreDBContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var book = _context.Books.SingleOrDefault(x=> x.Id == BookId);

            if(book == null)
            {
                throw new InvalidOperationException("Silinecek Kitap Bulunamadı.");
            }

            _context.Books.Remove(book);
            _context.SaveChanges();
        }
    }
}