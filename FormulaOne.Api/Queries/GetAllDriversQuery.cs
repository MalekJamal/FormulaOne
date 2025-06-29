using FormulaOne.Entities.Dtos.Responses;
using MediatR;

namespace FormulaOne.Api.Queries
{
    // create the response for the MediateR
    public class GetAllDriversQuery : IRequest<IEnumerable<GetDriverResponse>>
    {
        public GetAllDriversQuery()
        {

        }
    }
}