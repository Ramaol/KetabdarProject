﻿using System;
using System.Collections.Generic;
using ShopManagement.Domain.BookCateguryAgg;
using ShopManageMent.Application.Contract.BookCategury;
using Zero_Framework.Application;

namespace ShopManagement.Application
{
    public class BookCateguryApplication : IBookCateguryApplication
    {
        private readonly IBookCateguryRepository _bookCateguryRepository;

        public BookCateguryApplication(IBookCateguryRepository bookCateguryRepository)
        {
            _bookCateguryRepository = bookCateguryRepository;
        }

        public OperationResult Create(CreateBookCategury command)
        {
            var operation = new OperationResult();

            if(_bookCateguryRepository.Exist( x => command.Name == command.Name))
            {
                return operation.Failed(".این رکورد قبلا ثبت شده است");
            } 
            else
            {
                var bookCategury = new BookCategury(command.Name , command.KeyWords , command.MetaDescrption , command.Slug);
                _bookCateguryRepository.Create(bookCategury);
                _bookCateguryRepository.SaveChanges();
                return operation.Succedded();
            }
        }

        public OperationResult Edit(EditBookCategury command)
        {
            var operation = new OperationResult();
            var BookCategury = _bookCateguryRepository.Get(command.Id);
            
            if(BookCategury == null)
                return operation.Failed("رکورد با اطلاعات درخواست شده یافت نشد");
            
            if(_bookCateguryRepository.Exist(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed("امکان ثبت رکورد تکراری وجود ندارد مجددا تلاش کنید");

            BookCategury.Edit(command.Name , command.KeyWords , command.MetaDescrption , command.Slug); 
            _bookCateguryRepository.SaveChanges();
            return operation.Succedded();   
        }

        public BookCategury GetBookCateguryBy(long id)
        {
            return _bookCateguryRepository.Get(id);
        }

        public EditBookCategury GetDatails(long id)
        {
            throw new NotImplementedException();
        }

        public List<BookCateguryViewModel> Search(BookCategurySearchModel command)
        {
            var Result = new List<BookCateguryViewModel>();
            var Items = _bookCateguryRepository.Search(command.Name);

            foreach (var item in Items)
            {
                Result.Add(new BookCateguryViewModel{
                    CreationDate = item.CreationDate.ToString(),
                    Name = item.Name,  
                    Id = item.Id,                    
                });
            }

            return Result;
        }
    }
}