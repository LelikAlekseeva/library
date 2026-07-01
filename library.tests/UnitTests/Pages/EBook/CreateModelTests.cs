using FluentAssertions;
using library.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using library.Data;
using library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library.Tests.UnitTests.Pages.Book
{
    public class CreateModelTests
    {
        private ApplicationDbContext GetDbContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            return new ApplicationDbContext(options);
        }

        [Fact]
        public void OnPost_ShouldReturnPage_WhenModelStateIsInvalid()
        {
            // Arrange
            var context = GetDbContext();
            var pageModel = new library.Pages.ElectronicAudioBook.CreateModel(context);

            pageModel.ModelState.AddModelError("Title", "Required");

            // Act
            var result = pageModel.OnPost();

            // Assert
            object value = result.Should().BeOfType<PageResult>();
            context.ElectronicAudioBook.Count().Should().Be(0);
        }
    }
}
