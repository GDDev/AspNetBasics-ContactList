using ContactApp.Models;

namespace ContactApp.Repositories
{
    public class InMemoryContactRepository : IContactRepository
    {
        private readonly List<Contact> _contacts = [];
        private int _nextId = 1;

        public IEnumerable<Contact> GetContacts() => _contacts;

        public Contact? GetContactById(int id) =>
            _contacts.FirstOrDefault(c => c.id == id);

        public Contact? GetContactByName(string name) => 
            _contacts.FirstOrDefault(c => name.Equals(c.name, StringComparison.OrdinalIgnoreCase));

        public Contact? GetContactByPhoneNumber(string phoneNumber) =>
            _contacts.FirstOrDefault(c => phoneNumber.Equals(c.phoneNumber));

        public void Add(Contact contact)
        {
            contact.id = _nextId++;
            _contacts.Add(contact);
        }

        public void Update(Contact contact)
        {
            var index = _contacts.FindIndex(c => c.id == contact.id);
            if (index != -1) _contacts[index] = contact;
        }

        public void Delete(Contact contact)
        {
            _contacts.Remove(contact);
        }
    }
}
