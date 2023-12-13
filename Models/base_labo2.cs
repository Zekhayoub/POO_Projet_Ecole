
public class Appreciation : Eval
{
    private string appreciation;
    public Appreciation(string appreciation,Activite activite): base(activite)
    {
        this.appreciation = appreciation;
    }
    public override int Note()
    {
        if (appreciation == "X"){return 20;}
        else if (appreciation == "TB"){return 16;}
        else if (appreciation == "B"){return 12;}
        else if (appreciation == "C"){return 8;}
        else if (appreciation == "N"){return 4;}
        else{return 0;}
    }
    public void setNote(string note)
    {
        appreciation = note;
    }
}
public class Activite
{
    public int ECTS;
    public string Name;
    public string Code;
    public Enseignant enseignant;
    public Activite(string Name,string Code,Enseignant enseignant,int ECTS)
    {
        this.Name = Name;
        this.Code = Code;
        this.enseignant = enseignant;
        this.ECTS = ECTS;
    }
}

public class Cote : Eval
{
    private int note;
    public Cote(int note,Activite activite): base(activite)
    {
        this.note = note;

    }
    public override int Note()
    {
        return note;
    }
    public void SetNote(int note)
    {
        this.note = note;
    }

}

public abstract class Eval
{
    public Activite activite;
    public Eval(Activite activite)
    {
        this.activite = activite;
    }
    public abstract int Note();
    

}
public class Person
{
    private readonly string firstName;
    private readonly string lastName;
    public Person(string firstName,string lastName)
    {
        this.firstName = firstName;
        this.lastName = lastName;
    }
	public string displayName()
    {
        return firstName + " " + lastName;
    }
    public string FirstName
    {
        get {
            return firstName;
        }
    }
    public string LasttName
    {
        get {
            return lastName;
        }
    }
}
public class Etudiant : Person
{
    List<Eval> evaluations;
    public Etudiant(string firstName,string lastName,List<Eval> evaluations) :
    base(firstName,lastName)
    {
        this.evaluations = evaluations;
    }
    public void Add(Eval eval)
    {
        evaluations.Add(eval);
    }
    public double Average()
    {
        int numOfEval = 0;
        int sumOfValues = 0;
        int sumOfECTS = 0;
        foreach(Eval eval in evaluations)
        {
            numOfEval += 1;
            sumOfValues += eval.activite.ECTS * eval.Note();
            sumOfECTS = eval.activite.ECTS;
        }
        return sumOfValues/sumOfECTS/numOfEval;
    }
}
public class Enseignant : Person
{
    private int salaire;
    public Enseignant(int salaire,string firstName,string lastName) :
    base(firstName,lastName)
    {
        this.salaire = salaire;
    }
    public string ReturnSalary()
    {
        return salaire.ToString();
    }
}