﻿using ExtraClasses.Application.Subjects.Commands.CreateSubject;
using ExtraClasses.Application.Subjects.Commands.DeleteSubject;
using ExtraClasses.Application.Subjects.Commands.UpdateSubject;
using ExtraClasses.Application.Subjects.Queries.GetSubject;
using ExtraClasses.Application.Subjects.Queries.GetSubjects;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ExtraClasses.Api.Controllers
{
    public class SubjectsController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<SubjectListViewModel>> GetAll()
        {
            return Ok(await Mediator.Send(new GetSubjectListQuery()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SubjectViewModel>> Get(int id)
        {
            return Ok(await Mediator.Send(new GetSubjectQuery { Id = id }));
        }

        [HttpPost]
        [ProducesDefaultResponseType]
        public async Task<ActionResult> Create([FromBody] CreateSubjectCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update([FromBody]UpdateSubjectCommand command)
        {
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteSubjectCommand { Id = id });

            return NoContent();
        }
    }
}
