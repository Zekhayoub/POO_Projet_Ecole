namespace projet_progra_objet.Models;
public class Activite
{
    private int ects;
    private string name;
    private string code;
    private Enseignant? enseignant;
    private static List<Activite> listActivite = new List<Activite>();

    public Activite(string name, string code, Enseignant enseignant, int ects)
    {
        this.name = name;
        this.code = code;
        this.enseignant = enseignant;
        this.ects = ects;
        listActivite.Add(this);
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string Code
    {
        get { return code; }
        set { code = value; }
    }

    public Enseignant Enseignant
    {
        get { return enseignant; }
        set { enseignant = value; }
    }

    public int Ects
    {
        get { return ects; }
        set { ects = value; }
    }

    public static List<Activite> ListActivite
    {
        get { return listActivite; }
    }
}

public class Appreciation : Eval
{
    private string appreciation;
    private static List<Appreciation> listAppreciation = new List<Appreciation>();

    public Appreciation(string appreciation, Activite activite) : base(activite)
    {
        this.appreciation = appreciation;
        listAppreciation.Add(this);
    }

    public string AppreciationValue
    {
        get { return appreciation; }
        set { appreciation = value; }
    }

    public override int Note()
    {
        if (appreciation == "X") { return 20; }
        else if (appreciation == "TB") { return 16; }
        else if (appreciation == "B") { return 12; }
        else if (appreciation == "C") { return 8; }
        else if (appreciation == "N") { return 4; }
        else { return 0; }
    }

    public static List<Appreciation> ListAppreciation
    {
        get { return listAppreciation; }
    }
}
public class Cote : Eval
{
    private int note;
    private static List<Cote> listCote = new List<Cote>();

    public Cote(int note, Activite activite) : base(activite)
    {
        this.note = note;
        listCote.Add(this);
    }

    public int NoteValue
    {
        get { return note; }
        set { note = value; }
    }

    public override int Note()
    {
        return note;
    }

    public static List<Cote> ListCote
    {
        get { return listCote; }
    }
}
public class Enseignant : Person
{
    private int salaire;
    private static List<Enseignant> listEnseignant = new List<Enseignant>();

    public Enseignant(int salaire, string firstName, string lastName) :
        base(firstName, lastName)
    {
        this.salaire = salaire;
        listEnseignant.Add(this);
    }

    public int Salaire
    {
        get { return salaire; }
        set { salaire = value; }
    }

    public void Raise(int amt)
    {
        salaire += amt;
    }

    public static List<Enseignant> ListEnseignant
    {
        get { return listEnseignant; }
    }
}
public class Etudiant : Person
{
    private List<Eval> evaluations;
    private static List<Etudiant> listEtudiant = new List<Etudiant>();

    public Etudiant(string firstName, string lastName, List<Eval> evaluations) :
        base(firstName, lastName)
    {
        this.evaluations = evaluations;
        listEtudiant.Add(this);
    }

    public List<Eval> Evaluations
    {
        get { return evaluations; }
        set { evaluations = value; }
    }

    public void AddEvaluation(Eval eval)
    {
        evaluations.Add(eval);
    }

    public double Average()
    {
        int numOfEval = 0;
        int sumOfValues = 0;
        int sumOfECTS = 0;

        foreach (Eval eval in evaluations)
        {
            numOfEval += 1;
            sumOfValues += eval.Activite.Ects * eval.Note();
            sumOfECTS += eval.Activite.Ects;
        }

        return (double)sumOfValues / sumOfECTS / numOfEval;
    }

    public string Bulletin()
    {
        string output = "";

        foreach (Eval eval in evaluations)
        {
            output += string.Format("Pour le cours de {0}, vous avez une note de {1}. {2} Crédits",
                eval.Activite.Name, eval.Note(), eval.Activite.Ects);
        }

        output += string.Format("Pour une fabuleuse moyenne de {0}. Bravo {1}!", Average(), DisplayName());
        return output;
    }

    public static List<Etudiant> ListEtudiant
    {
        get { return listEtudiant; }
    }
}

public abstract class Eval
{
    private Activite activite;
    private static List<Eval> listEval = new List<Eval>();

    public Eval(Activite activite)
    {
        this.activite = activite;
        listEval.Add(this);
    }

    public Activite Activite
    {
        get { return activite; }
        set { activite = value; }
    }

    public abstract int Note();

    public static List<Eval> ListEval
    {
        get { return listEval; }
    }
}
public class Person
{
    private readonly string firstName;
    private readonly string lastName;
    private static List<Person> listPerson = new List<Person>();

    public Person(string firstName, string lastName)
    {
        this.firstName = firstName;
        this.lastName = lastName;
        listPerson.Add(this);
    }

    public string DisplayName()
    {
        return firstName + " " + lastName;
    }

    public string FirstName
    {
        get { return firstName; }
    }

    public string LastName
    {
        get { return lastName; }
    }

    public static List<Person> ListPerson
    {
        get { return listPerson; }
    }
}