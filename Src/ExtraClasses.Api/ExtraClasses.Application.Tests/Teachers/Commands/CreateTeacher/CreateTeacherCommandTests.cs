﻿using ExtraClasses.Application.Teachers.Commands.CreateTeacher;
using ExtraClasses.Application.Tests.Infrastructure;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Xunit;

namespace ExtraClasses.Application.Tests.Teachers.Commands.CreateTeacher
{
    public class CreateTeacherCommandTests : CommandTestBase
    {
        [Fact]
        public async void CreateTeacherCommandHandler_ShouldAddTeacherToContext()
        {
            // Arrange
            var sut = new CreateTeacherCommandHandler(_context);
            var firstName = "Saruman";
            var lastName = "The White";
            var email = "sthewhite@wizzardcouncil.com";

            // Act
            var result = await sut.Handle(new CreateTeacherCommand
            {
                FirstName = firstName,
                LastName = lastName,
                Email = email
            }, CancellationToken.None);

            // Assert
            _context.Teachers.Where(t => t.FirstName == firstName).FirstOrDefault().FirstName.ShouldBe("Saruman");
        }
    }
}
