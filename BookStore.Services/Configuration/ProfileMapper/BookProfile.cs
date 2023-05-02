using AutoMapper;
using BookStore.Domain.Entity;
using BookStore.Domain.Model;
using BookStore.Services.Feature.Books.Commands;
using BookStore.Services.Feature.Books.Queries;
using BookStore.Services.ViewModel;
using BookStore.Services.ViewModel.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Services.Configuration.ProfileMapper
{
    public class BookProfile : Profile
    {
        public BookProfile()
        {
            CreateMap<CreateBookViewModel, AddBookCommand>().ReverseMap();
            CreateMap<UpdateBookViewModel, UpdateBookCommand>().ReverseMap();
            CreateMap<DeleteBookViewModel, DeleteBookCommand>().ReverseMap();
            CreateMap<GetBookByIdViewModel, GetBookByIdQuery>().ReverseMap();
            CreateMap<SearchBookViewModel, SearchBookQuery>().ReverseMap();
        }
    }
}
