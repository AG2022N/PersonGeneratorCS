using System.Text;
using System.Threading.Channels;
class Program
{
    static void Main()
    {
        //Setup Start
        string FirstNamesMalePath = @"NamesMale.txt";
        string FirstNamesFemalePath = @"NamesFemale.txt";
        string LastNamesPath = @"LastNames.txt";
        string JobsPath = @"Jobs.txt";
        Initialize(FirstNamesMalePath, FirstNamesFemalePath, LastNamesPath, JobsPath);
        string[] FirstNamesMale = File.ReadAllLines(FirstNamesMalePath);
        string[] FirstNamesFemale = File.ReadAllLines(FirstNamesFemalePath);
        string[] LastNames = File.ReadAllLines(LastNamesPath);
        string[] Jobs = File.ReadAllLines(JobsPath);
        string Filepath;
        //Setup End

        //Program Start
        Console.WriteLine("Writing...");
        for (int i = 1; i <= 50;)
        {
            Filepath = (@"OutputPerson" + i + ".json");
            Random rand = new Random();
            bool IsFemale = rand.Next(2) == 1;
            string[] FirstName = FirstNamesMale; if (IsFemale) { FirstName = FirstNamesFemale; }
            Person PersonInst = PersonGenerate(IsFemale, FirstName, LastNames, Jobs, rand);
            PersonObjectToJson(Filepath, PersonInst);
            Console.WriteLine(i + "/50");
            Console.WriteLine("Name: " + PersonInst.FirstName + " " + PersonInst.LastName);
            Console.WriteLine("Job: " + PersonInst.Job);
            i++;
        }
        Console.Write("Finished!");
        Console.ReadKey();
        //Program End
    }
    public class Person(string ConstSex, string ConstFirstName, string ConstLastName, string ConstJob)
    {
        public string Sex = ConstSex;
        public string FirstName = ConstFirstName;
        public string LastName = ConstLastName;
        public string Job = ConstJob;
    }
    public static Person PersonGenerate(bool IsFemale, string[] FirstNames, string[] LastNames, string[] Jobs, Random rand)
    {
        string Sex = "Male"; if (IsFemale) { Sex = "Female"; }
        string RandomFirstName = FirstNames[rand.Next(FirstNames.Length)];
        string RandomLastName = LastNames[rand.Next(LastNames.Length)];
        string RandomJob = Jobs[rand.Next(Jobs.Length)];
        Person p = new Person(Sex, RandomFirstName, RandomLastName, RandomJob);
        return p;
    }
    public static void PersonObjectToJson(string Filepath, Person Person)
    {
        string Path = Filepath;
        var JsonFormatting = Newtonsoft.Json.JsonConvert.SerializeObject(Person);
        System.IO.File.WriteAllText(Path, JsonFormatting);
    }
    static void Initialize(string FirstNamesMalePath, string FirstNamesFemalePath, string LastNamesPath, string JobsPath)
    {
        if (!File.Exists(FirstNamesMalePath))
        {
            File.Create(FirstNamesMalePath).Close();
            var WriteNamesMale = new StreamWriter(FirstNamesMalePath, true, Encoding.ASCII);
            WriteNamesMale.Write("FirstName1\nFirstName2\nFirstName3\nFirstName4\nFirstName5");
            WriteNamesMale.Close();
        }
        if (!File.Exists(FirstNamesFemalePath))
        {
            File.Create(FirstNamesFemalePath).Close();
            var WriteNamesFemale = new StreamWriter(FirstNamesFemalePath, true, Encoding.ASCII);
            WriteNamesFemale.Write("FirstName1\nFirstName2\nFirstName3\nFirstName4\nFirstName5");
            WriteNamesFemale.Close();
        }
        if (!File.Exists(LastNamesPath))
        {
            File.Create(LastNamesPath).Close();
            var WriteNamesLast = new StreamWriter(LastNamesPath, true, Encoding.ASCII);
            WriteNamesLast.Write("LastName1\nLastName2\nLastName3\nLastName4\nLastName5");
            WriteNamesLast.Close();
        }
        if (!File.Exists(JobsPath))
        {
            File.Create(JobsPath).Close();
            var WriteNamesLast = new StreamWriter(JobsPath, true, Encoding.ASCII);
            WriteNamesLast.Write("Jobs1\nJobs2\nJobs3\nJobs4\nJobs5");
            WriteNamesLast.Close();
        }
    }
}