using LibraryManager.Application.Models;
using MediatR;

namespace LibraryManager.Application.Queries.UserQueries.GetUserById
{
    public class GetUserByIdQuery : IRequest<ResultViewModel<UserViewModel>>
    {

        public int Id { get; set; }

        public GetUserByIdQuery(int id)
        {
            this.Id = id;
        }
    }
}
