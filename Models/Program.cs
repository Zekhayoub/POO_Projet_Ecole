// See https://aka.ms/new-console-template for more information
using school.Models;

Teacher goku = new Teacher("Son", "Goku", 10_000);
Teacher khoi = new Teacher("Khoi", "Nguyen", 3210);

Activity oop = new Activity("Object Oriented Programming", "OOP", 5, goku);
Activity math = new Activity("Mathématique", "MATH", 8, khoi);

Cote c = new Cote(oop);
c.SetNote(17);
Appreciation a = new Appreciation(math);
a.SetAppreciation("X");

Student lur = new Student("Quentin", "Lurkin");
lur.Add(c);
lur.Add(a);

Console.WriteLine(lur.Bulletin());


