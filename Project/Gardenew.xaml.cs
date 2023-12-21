
using System;
using System.Text.Json;
using projet_progra_objet.feuille_annexe;
namespace projet_progra_objet;



public partial class Gardenew : ContentPage
{
	public Gardenew()
	{
		InitializeComponent();
	}
	private void OnAddStudentclicked(object sender, EventArgs e)
	{	
		var Pagestudent = new Studentnew();
		Navigation.PushAsync(Pagestudent);
		
    } 
    private void OnAddTeacherclicked(object sender, EventArgs e)
	{	
		var Pageteacher = new Teachernew();
		Navigation.PushAsync(Pageteacher);
		
    } 
    private void OnAddActivityClicked(object sender, EventArgs e)
	{	
		var Pageactivity = new Activitynew();
		Navigation.PushAsync(Pageactivity);
		
    } 
	private void OnAsignEvaltoStudentClicked(object sender, EventArgs e)
	{	
		var Pageval = new Evalutionew();
		Navigation.PushAsync(Pageval);
		
    } 
	private void OnDisplayBulletinClicked(object sender, EventArgs e)
	{	
		var Pagebullet = new Bulletinew();
		Navigation.PushAsync(Pagebullet);
		
    } 
}