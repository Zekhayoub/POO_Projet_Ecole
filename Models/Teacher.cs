using System.Xml.Linq;

namespace school.Models;

    public class Teacher : Person
    {
        public double salary;
        public  static List<Teacher> AllTeachers = new List<Teacher>();
        public string FileName;

        public Teacher(string firstname, string lastname, double salary) : base(firstname, lastname) {
            this.salary = salary;
            FileName =  $"{Path.GetRandomFileName()}.teacher.txt";  
        }

        public override string ToString()
        {
            return String.Format("{0} ({1})", DisplayName(), salary);
        }

        public double Salary {
            get {
                return salary;
            }
        }
        static public Teacher Load(string fileName){
            Console.WriteLine($"loading{fileName}");
            var fullfileName = Path.Combine(Connection.directpath,fileName);
            string content =  File.ReadAllText(fullfileName);
            var tokens = content.Split('\n');
            var teacher = new Teacher(tokens[0],tokens[1],Convert.ToDouble(tokens[2]));
            teacher.FileName = fileName;
            
            return teacher;
        }
        public void Save(){
            var fullfileName = Path.Combine(Connection.directpath,FileName);
            string content = $"{Firstname}\n{Lastname}\n{salary}";
            File.WriteAllText(fullfileName,content);
        }
        static public void LoadAll(){
            IEnumerable<Teacher> teachers = Directory
                .EnumerateFiles(Connection.directpath,"*.teachers.txt")
                .Select(FileName => Teacher.Load(Path.GetFileName(FileName)))
                .OrderBy(teacher =>teacher.DisplayName());
            foreach(var teacher in teachers){
                AllTeachers.Add(teacher);
            }
                
        }
    }
