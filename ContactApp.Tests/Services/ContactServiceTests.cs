using ContactApp.Api.Repositories.InMemory;
using ContactApp.Models;
using ContactApp.Services;

namespace ContactApp.Tests.Services
{
    public class ContactServiceTests
    {
        private readonly InMemoryContactRepository _repository;
        private readonly ContactService _service;

        public ContactServiceTests()
        {
            _repository = new InMemoryContactRepository();
            _service = new ContactService(_repository);
        }

        [Fact]
        public void Create_Assigns_Id_To_Contact()
        {
            // Arrange
            var contact = new Contact
            {
                name = "Test",
                phoneNumber = "12345"
            };

            // Act
            _service.Create(contact);

            // Assert
            Assert.True(contact.id > 0);
        }

        [Fact]
        public void Update_Existing_Contact_Changes_Values()
        {
            var contact = new Contact
            {
                name = "Original",
                phoneNumber = "12345"
            };
            _service.Create(contact);

            var updated = new Contact
            {
                id = contact.id,
                name = "Updated",
                phoneNumber = "123456"
            };

            _service.Update(updated);

            var result = _service.GetContactById(contact.id);

            Assert.NotNull(result);
            Assert.Equal("Updated", result.name);
            Assert.Equal("123456", result.phoneNumber);
        }

        [Fact]
        public void Delete_Removes_Contact()
        {
            var contact1 = new Contact
            {
                name = "Contact 1",
                phoneNumber = "123"
            };

            var contact2 = new Contact
            {
                name = "Contact 2",
                phoneNumber = "456"
            };

            _service.Create(contact1);
            _service.Create(contact2);

            _service.Delete(contact1.id);

            var deleted = _service.GetContactById(contact1.id);
            var remaining = _service.GetContactById(contact2.id);

            Assert.Null(deleted);
            Assert.NotNull(remaining);
        }
    }
}
