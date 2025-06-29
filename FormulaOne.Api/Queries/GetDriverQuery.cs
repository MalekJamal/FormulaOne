using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormulaOne.Entities.Dtos.Responses;
using MediatR;

namespace FormulaOne.Api.Queries
{
    public class GetDriverQuery : IRequest<GetDriverResponse>
    {
        public Guid DriverId { get; }

        public GetDriverQuery(Guid driverId)
        {
            DriverId = driverId;
        }
        
    }
}