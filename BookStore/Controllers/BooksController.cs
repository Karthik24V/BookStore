using AutoMapper;
using BookStore.Domain;
using BookStore.Services.Feature.Books.Commands;
using BookStore.Services.Feature.Books.Queries;
using BookStore.Services.ViewModel.Books;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace BookStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public BooksController(IMapper mapper, IMediator mediator) 
        { 
            _mapper = mapper;
            _mediator = mediator;
        }
        // GET: api/<BooksController>
        //[HttpGet("GetAllBooks")]
        //public async Task<IActionResult> GetAllBooks()
        //{
        //    try
        //    {
        //        var response = await _mediator.Send();
        //    }
        //    catch(Exception ex) 
        //    {
        //    }

        //}

        // GET api/<BooksController>/5
        [HttpPost("GetBook")]
        public async Task<object> GetBookById([FromBody] GetBookByIdViewModel data)
        {
            try
            {
                if(!ModelState.IsValid)
                {
                    return ApiResponse.BadResponse(ModelState);
                }
                var item = _mapper.Map<GetBookByIdQuery>(data);
                var response = await _mediator.Send(item);

                return ApiResponse.OkResponse(response);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpPost("SearchBook")]
        public async Task<object> SearchBook([FromBody] SearchBookViewModel data)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return ApiResponse.BadResponse(ModelState);
                }
                var item = _mapper.Map<SearchBookQuery>(data);
                var response =await _mediator.Send(item);

                return ApiResponse.OkResponse(response);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // POST api/<BooksController>
        [HttpPost("AddBook")]
        public async Task<object> Addbook([FromBody] CreateBookViewModel data)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return ApiResponse.BadResponse(ModelState);
                }
                var item = _mapper.Map<AddBookCommand>(data);
                var response =await _mediator.Send(item);

                return ApiResponse.OkResponse(response);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // PUT api/<BooksController>/5
        [HttpPut("UpdateBook")]
        public async Task<object> UpdateBook(UpdateBookViewModel data)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return ApiResponse.BadResponse(ModelState);
                }
                var item = _mapper.Map<UpdateBookCommand>(data);
                var response = await _mediator.Send(item);

                return ApiResponse.OkResponse(response);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("DeleteBook")]
        public async Task<object> Delete(DeleteBookViewModel data)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return ApiResponse.BadResponse(ModelState);
                }
                var item = _mapper.Map<DeleteBookCommand>(data);
                var response = await _mediator.Send(item);

                return ApiResponse.OkResponse(response);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
