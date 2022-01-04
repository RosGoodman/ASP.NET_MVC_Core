

using System.Collections;

namespace Common.Entityes;

public class ContactsEnumertor : IEnumerator
{
    private Contact[] _contacts;
    private int position = -1;

    public ContactsEnumertor(Contact[] contacts) => _contacts = contacts;

    public object Current
    {
        get
        {
            if (position == -1 || position >= _contacts.Length)
                throw new InvalidOperationException();
            return _contacts[position];
        }
    }

    public bool MoveNext()
    {
        if(position <= _contacts.Length - 1)
        {
            position++;
            return true;
        }
        else
            return false;
    }

    public void Reset()
    {
        position = -1;
    }
}
