using System.Text;
class Program
{
    static void Main()
    {
        //Setup Start
        string FirstNamesMale = @"NamesMale.txt";
        string FirstNamesFemale = @"NamesFemale.txt";
        string LastNames = @"LastNames.txt";
        string Jobs = @"Jobs.txt";
        if (!File.Exists(FirstNamesMale))
        {
            File.Create(FirstNamesMale).Close();
            var WriteNamesMale = new StreamWriter(FirstNamesMale, true, Encoding.ASCII);
            WriteNamesMale.Write("FirstName1\nFirstName2\nFirstName3\nFirstName4\nFirstName5");
            WriteNamesMale.Close();
        }
        if (!File.Exists(FirstNamesFemale))
        {
            File.Create(FirstNamesFemale).Close();
            var WriteNamesFemale = new StreamWriter(FirstNamesFemale, true, Encoding.ASCII);
            WriteNamesFemale.Write("FirstName1\nFirstName2\nFirstName3\nFirstName4\nFirstName5");
            WriteNamesFemale.Close();
        }
        if (!File.Exists(LastNames))
        {
            File.Create(LastNames).Close();
            var WriteNamesLast = new StreamWriter(LastNames, true, Encoding.ASCII);
            WriteNamesLast.Write("LastName1\nLastName2\nLastName3\nLastName4\nLastName5");
            WriteNamesLast.Close();
        }
        if (!File.Exists(Jobs))
        {
            File.Create(Jobs).Close();
            var WriteNamesLast = new StreamWriter(Jobs, true, Encoding.ASCII);
            WriteNamesLast.Write("Jobs1\nJobs2\nJobs3\nJobs4\nJobs5");
            WriteNamesLast.Close();
        }
        //Setup End

        Console.WriteLine("Writing...");
        for (int i = 1; i <= 50;)
        {
            //Person Person = PersonGenerate();
            Console.WriteLine(i + "/50");
            string Filepath = (@"OutputPerson" + i + ".json");
            //PersonObjectToJson(Filepath, Person);
            i++;
        }
        Console.Write("Finished!");
        Console.ReadKey();
    }
    public class Person(bool ConstIsFemale, string ConstFirstName, string ConstLastName, string ConstJob)
    {
        public bool IsFemale = ConstIsFemale;
        public string FirstName = ConstFirstName;
        public string LastName = ConstLastName;
        public string Job = ConstJob;
    }
    //static Person PersonGenerate()
    //{
    //    Random rand = new Random();
    //    bool IsFemale = rand.Next(2) == 1;
    //    string RandomFirstName = FirstNames[random.Next(FirstNames.Length)];
    //    string RandomLastName = LastNames[random.Next(LastNames.Length)];
    //    string RandomJob = Jobs[rand.Next(Jobs.Length)];
    //    Person p = new Person(false, RandomFirstName, RandomLastName, RandomJob);
    //    return p;
    //}

    public void PersonObjectToJson(string Filepath, Person Person)
    {
        string Path = Filepath;
        var JsonFormatting = Newtonsoft.Json.JsonConvert.SerializeObject(Person);
        System.IO.File.WriteAllText(Path, JsonFormatting);
    }
}