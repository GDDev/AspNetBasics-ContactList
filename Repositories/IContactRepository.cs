using ContactApp.Models;

namespace ContactApp.Repositories
{
    public interface IContactRepository
    {
        IEnumerable<Contact> GetContacts();
        Contact? GetContactById(int id);
        Contact? GetContactByName(string name);
        Contact? GetContactByPhoneNumber(string phoneNumber);
        void Add(Contact contact);
        void Update(Contact contact);
        void Delete(Contact contact);
    }
}
