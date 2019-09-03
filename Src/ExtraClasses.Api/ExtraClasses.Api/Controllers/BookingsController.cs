﻿using ExtraClasses.Api.Controllers;
using ExtraClasses.Application.Bookings.Commands.CreateBooking;
using ExtraClasses.Application.Bookings.Commands.DeleteBooking;
using ExtraClasses.Application.Bookings.Commands.UpdateBooking;
using ExtraClasses.Application.Bookings.Queries.GetBooking;
using ExtraClasses.Application.Bookings.Queries.GetBookingList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Bookings.Api.Controllers
{
    public class BookingsController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<BookingListViewModel>> GetAll()
        {
            return Ok(await Mediator.Send(new GetBookingListQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookingViewModel>> Get(int id)
        {
            return Ok(await Mediator.Send(new GetBookingQuery { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateBookingCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromBody]UpdateBookingCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteBookingCommand { Id = id });

            return NoContent();
        }
    }
}
