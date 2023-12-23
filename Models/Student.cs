namespace school.Models;
public class Student : Person
{
    private List<Evaluation> evaluations;

    public Student(string firstname, string lastname) : base(firstname, lastname) {
        evaluations = new List<Evaluation>();
    }

    public void Add(Evaluation evaluation) {
        evaluations.Add(evaluation);
    }

    public double Average() {
        int total = 0;
        int ects = 0;
        foreach(var evaluation in evaluations) {
            total += evaluation.Note() * evaluation.Activity.ECTS;
            ects += evaluation.Activity.ECTS;
        }
        return total/ects;
    }

    public string Bulletin() {
        var lines = new List<String>
        {
            String.Format("Bulletin de {0}", DisplayName())
        };

        foreach(var evaluation in evaluations) {
            lines.Add(evaluation.ToString());
        }

        lines.Add(String.Format("Moyenne: {0}", Average()));

        return String.Join("\n", lines);
    }
}
