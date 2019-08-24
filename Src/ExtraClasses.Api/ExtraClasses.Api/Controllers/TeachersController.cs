﻿using ExtraClasses.Application.Teachers.Commands.CreateTeacher;
using ExtraClasses.Application.Teachers.Commands.DeleteTeacher;
using ExtraClasses.Application.Teachers.Commands.UpdateTeacher;
using ExtraClasses.Application.Teachers.Queries.GetTeacher;
using ExtraClasses.Application.Teachers.Queries.GetTeacherList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExtraClasses.Api.Controllers
{
    public class TeachersController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<TeacherListViewModel>> GetAll()
        {
            return Ok(await Mediator.Send(new GetTeacherListQuery()));
        }

        [HttpGet]
        public async Task<ActionResult<TeacherDto>> Get(int id)
        {
            return Ok(await Mediator.Send(new GetTeacherQuery { Id = id }));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Create([FromBody] CreateTeacherCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromBody]UpdateTeacherCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteTeacherCommand { Id = id });

            return NoContent();
        }
    }
}
