using ContactApp.Models;

namespace ContactApp.Services
{
    public interface IContactService
    {
        IEnumerable<Contact> GetContacts();
        Contact? GetContactById(int id);
        void Create(Contact contact);
        void Update(Contact contact);
        void Delete(int id);
    }
}
