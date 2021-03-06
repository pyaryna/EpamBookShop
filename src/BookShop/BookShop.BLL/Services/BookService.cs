﻿using AutoMapper;
using Microsoft.AspNetCore.Hosting;
using PublishingHouse.BLL.DTOs;
using PublishingHouse.BLL.Interfaces;
using PublishingHouse.DAL;
using PublishingHouse.DAL.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublishingHouse.BLL.Services
{
    public class BookService: IBookService
    {
        private readonly IPublishingHouseUnitOfWork _unitOfWork;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly IMapper _mapper;

        public BookService(
            IPublishingHouseUnitOfWork unitOfWork,
            IHostingEnvironment hostingEnvironment,
            IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _hostingEnvironment = hostingEnvironment;
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<BookPreviewDto>> GetAllBooksInfoAsync()
        {
            IEnumerable<Book> books = await _unitOfWork.Books.GetAllBooksAsync();                  

            return books.Select(_mapper.Map<Book, BookPreviewDto>)
                .ToArray();            
        }

        public async Task<BookDto> GetOneBookInfoAsync(int id) 
        {
            return _mapper.Map<Book, BookDto>(await _unitOfWork.Books.FindAsync(id));
        }

        public async Task<BookPreviewDto> GetOneBookPreviewAsync(int id)
        {
            return _mapper.Map<Book, BookPreviewDto>(await _unitOfWork.Books.FindAsync(id));
        }

        public async Task<BookDto> AddBookAsync(AddBookDto addBook)
        {
            var bookEntity = _unitOfWork.Books.Add(_mapper.Map<AddBookDto, Book>(addBook));

            string uploadsFolder = @"E:\me\epam\EpamBookShop\src\BookShopClient\src\assets\images\";
            string uniqueFileName = Guid.NewGuid().ToString() + "_" + addBook.Image.FileName;
            string filePath = Path.Combine(uploadsFolder, uniqueFileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                addBook.Image.CopyTo(fileStream);
            }

            bookEntity.ImageUrl = "~/images/" + uniqueFileName;

            var bookAuthors = new List<BookAuthor>()
            {
                new BookAuthor()
                {
                     AuthorId = addBook.AuthorId,
                     Book = bookEntity
                }               
            };
            _unitOfWork.BookAuthors.AddRange(bookAuthors);
            
            var bookCategories = new List<BookCategory>()
            {
                new BookCategory()
                {
                     CategoryId = addBook.CategoryId,
                     Book = bookEntity
                }
            };

            _unitOfWork.BookCategories.AddRange(bookCategories);

            await _unitOfWork.CommitAsync();

            return _mapper.Map<Book, BookDto>(bookEntity);
        }

        public async Task<BookDto> UpdateBookAsync(int id, UpdateBookDto updateBook)
        {            
            var bookEntity = await _unitOfWork.Books.FindAsync(id);

            _mapper.Map(updateBook, bookEntity);

            if(updateBook.Image != null)
            {
                string uploadsFolder = @"E:\me\epam\EpamBookShop\src\BookShopClient\src\assets\images";
                System.IO.File.Delete(String.Concat(uploadsFolder, updateBook.ExistingImagePath.Substring(10)));
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + updateBook.Image.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using(var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    updateBook.Image.CopyTo(fileStream);
                }                

                bookEntity.ImageUrl = "~/images/" + uniqueFileName;
            }
            else
            {
                bookEntity.ImageUrl = updateBook.ExistingImagePath;
            }

            var bookAuthors = new List<BookAuthor>()
            {
                new BookAuthor()
                {
                     AuthorId = updateBook.AuthorId,
                     Book = bookEntity
                }
            };

            _unitOfWork.BookAuthors.AddRange(bookAuthors);

            var bookCategories = new List<BookCategory>()
            {
                new BookCategory()
                {
                     CategoryId = updateBook.CategoryId,
                     Book = bookEntity
                }
            };

            _unitOfWork.BookCategories.AddRange(bookCategories);

            await _unitOfWork.CommitAsync();

            return _mapper.Map<Book, BookDto>(bookEntity);
        }
        public async Task RemoveBookByIdAsync(int id)
        {
            var book = await _unitOfWork.Books.FindAsync(id);

            _unitOfWork.Books.Remove(book);

            await _unitOfWork.CommitAsync();
        }
    }
}
