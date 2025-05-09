using FRD.Application;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Threading;

namespace FRD.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CreateCustomerCommand createCustomerCommand)
        {
            var result = await _mediator.Send(createCustomerCommand);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> DeleteCustomer(DeleteCustomerCommand deleteCustomerCommand)
        {
            var result = await _mediator.Send(deleteCustomerCommand);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> RestoreCustomer(RestoreCustomerCommand restoreCustomerCommand)
        {
            var result = await _mediator.Send(restoreCustomerCommand);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateCustomerCommand updateCustomerCommand)
        {
            var result = await _mediator.Send(updateCustomerCommand);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomerById([FromQuery] GetCustomerByIdQuery getCustomerByIdQuery)
        {
            var result = await _mediator.Send(getCustomerByIdQuery);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomerByEmail([FromQuery] GetCustomerByEmailQuery getCustomerByIdQuery)
        {
            var result = await _mediator.Send(getCustomerByIdQuery);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetCustomersList([FromQuery] GetCustomersListQuery getCustomersListQuery)
        {

            var result = await _mediator.Send(getCustomersListQuery);
            return Ok(result);
        }

    }
}
