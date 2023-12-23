using System.ComponentModel;

namespace school.Models;
public class Person
{
    private string firstname;
    private string lastname;

    public Person(string firstname, string lastname) {
        this.firstname = firstname;
        this.lastname = lastname;
    }

    public string DisplayName() {
        return String.Format("{0} {1}", firstname, lastname);
    }

    public string Firstname {
        get {
            return firstname;
        }
    }

    public string Lastname {
        get {
            return lastname;
        }
    }
}
