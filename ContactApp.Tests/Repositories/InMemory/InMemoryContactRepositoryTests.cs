using ContactApp.Api.Repositories.InMemory;
using ContactApp.Models;

namespace ContactApp.Tests.Repositories.InMemory
{
    public class InMemoryContactRepositoryTests
    {
        private readonly InMemoryContactRepository _repository;

        public InMemoryContactRepositoryTests()
        {
            _repository = new InMemoryContactRepository();
        }

        [Fact]
        public void Add_And_GetById_Returns_Contact()
        {
            var contact = new Contact
            {
                id = 1,
                name = "Test",
                phoneNumber = "123"
            };

            _repository.Add(contact);
            var result = _repository.GetContactById(1);

            Assert.NotNull(result);
            Assert.Equal("Test", result!.name);
        }

        [Fact]
        public void Update_Replaces_Existing_Contact()
        {
            var contact = new Contact
            {
                id = 1,
                name = "Original",
                phoneNumber = "111"
            };

            _repository.Add(contact);

            var updated = new Contact
            {
                id = 1,
                name = "Updated",
                phoneNumber = "222"
            };

            _repository.Update(updated);
            var result = _repository.GetContactById(1);

            Assert.NotNull(result);
            Assert.Equal("Updated", result!.name);
            Assert.Equal("222", result.phoneNumber);
        }

        [Fact]
        public void Delete_Removes_Contact()
        {
            var contact = new Contact
            {
                id = 1,
                name = "Test",
                phoneNumber = "123"
            };
            _repository.Add(contact);

            _repository.Delete(contact);
            var result = _repository.GetContactById(1);

            Assert.Null(result);
        }

        [Fact]
        public void GetContacts_Returns_All_Contact()
        {
            _repository.Add(new Contact { id = 1, name = "A", phoneNumber = "111" });
            _repository.Add(new Contact { id = 2, name = "B", phoneNumber = "222" });

            var result = _repository.GetContacts();
            Assert.Equal(2, result.Count());
        }
    }
}
