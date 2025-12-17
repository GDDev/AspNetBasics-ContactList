using ContactApp.Api.Repositories.Abstractions;
using ContactApp.Models;

namespace ContactApp.Services
{
    public class ContactService(IContactRepository repository) : IContactService
    { 
        private readonly IContactRepository _repo = repository;

        public Contact? GetContactById(int id) => _repo.GetContactById(id);

        public IEnumerable<Contact> GetContacts() => _repo.GetContacts();

        public void Create(Contact contact) => _repo.Add(contact);

        public void Update(Contact contact) => _repo.Update(contact);

        public void Delete(int id)
        {
            Contact? contact = _repo.GetContactById(id);
            if (contact != null) _repo.Delete(contact);
        }
    }
}
