using library.Models;
using System.ComponentModel.DataAnnotations;

namespace library.Tests.UnitTests.Model
{
    public class EBookTests
    {
        [Fact]
        public void Book_WithValidData_ShouldBeValid()
        {
            // Arrange
            var author = new Author
            {
                Name = "Пушкин"
            };

            var book = new ElectronicAudioBook
            {
                Name = "C# in Depth",     // Обязательное поле из EFModel
                Title = "Подробное руководство",
                Author = author,
                AuthorID = author.Id,
                Language = "Русский",
                Genre = "Научный"
            };

            var context = new ValidationContext(book);
            var result = new List<ValidationResult>();

            // Act
            var isValid = Validator.TryValidateObject(book, context, result, true);

            // Assert
            Assert.True(isValid);
            Assert.Empty(result);
        }

        [Fact]
        public void Book_WithEmptyName_ShouldBeInvalid()
        {
            // Arrange
            var author = new Author
            {
                Name = "Пушкин"
            };

            var book = new ElectronicAudioBook
            {
                Name = "", // Пустое имя - должно вызвать ошибку валидации
                Title = "Подробное руководство",
                Author = author,
                AuthorID = author.Id,
                Language = "Русский",
                Genre = "Научный"
            };

            var context = new ValidationContext(book);
            var results = new List<ValidationResult>();

            // Act
            var isValid = Validator.TryValidateObject(book, context, results, true);

            // Assert
            Assert.False(isValid);
            Assert.Contains(results, r => r.ErrorMessage.Contains("Наименование должно быть заполнено"));
        }

        [Fact]
        public void Book_WithNullName_ShouldBeInvalid()
        {
            // Arrange
            var author = new Author
            {
                Name = "Пушкин"
            };

            var book = new ElectronicAudioBook
            {
                Name = null, // Null имя - должно вызвать ошибку валидации
                Title = "Подробное руководство",
                Author = author,
                AuthorID = author.Id,
                Language = "Русский",
                Genre = "Научный"
            };

            var context = new ValidationContext(book);
            var results = new List<ValidationResult>();

            // Act
            var isValid = Validator.TryValidateObject(book, context, results, true);

            // Assert
            Assert.False(isValid);
            Assert.Contains(results, r => r.ErrorMessage.Contains("Наименование должно быть заполнено"));
        }

        [Fact]
        public void Book_ShouldHaveAuthorNavigationProperty()
        {
            // Arrange
            var author = new Author
            {
                Name = "Толстой"
            };

            var book = new ElectronicAudioBook
            {
                Name = "Война и мир",
                Author = author,
                AuthorID = author.Id
            };

            // Assert
            Assert.NotNull(book.Author);
            Assert.Equal("Толстой", book.Author.Name);
            Assert.Equal(author.Id, book.AuthorID);
        }

        [Fact]
        public void Book_ShouldInheritFromEFModel()
        {
            // Arrange
            var book = new ElectronicAudioBook();

            // Assert
            Assert.IsAssignableFrom<EFModel>(book);
        }
    }
}