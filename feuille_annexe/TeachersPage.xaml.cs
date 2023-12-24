
namespace school.feuille_annexe;

public partial class TeachersPage : ContentPage
{
	public string truc {get;} = "";
	public List<Teacher> AllTeachers {get {
		return  Teacher.AllTeachers;
	}}
	public List<Teacher> teacherlist;


	public TeachersPage()
	{
		Teacher.LoadAll();
		teacherlist = Teacher.AllTeachers.ToList();
		InitializeComponent();
		BindingContext = this;
	}
}