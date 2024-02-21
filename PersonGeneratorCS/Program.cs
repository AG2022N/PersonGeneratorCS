using System.Text;
class Program
{
    static void Main()
    {
        //Setup Start
        string FirstNamesMalePath = @"DataNamesMale.txt";
        string FirstNamesFemalePath = @"DataNamesFemale.txt";
        string LastNamesPath = @"DataLastNames.txt";
        string OccupationsPath = @"DataOccupations.txt";
        Initialize(FirstNamesMalePath, FirstNamesFemalePath, LastNamesPath, OccupationsPath);
        string[] FirstNamesMale = File.ReadAllLines(FirstNamesMalePath);
        string[] FirstNamesFemale = File.ReadAllLines(FirstNamesFemalePath);
        string[] LastNames = File.ReadAllLines(LastNamesPath);
        string[] Occupations = File.ReadAllLines(OccupationsPath);
        string Filepath;
        //Setup End

        //Program Start
        int Quantity = 100;
        for (int Counter = 1; Counter <= Quantity;)
        {
            Filepath = (@"OutputPerson" + Counter + ".json");
            Random rand = new Random();
            bool IsFemale = rand.Next(2) == 1;
            string[] FirstName = FirstNamesMale; if (IsFemale) { FirstName = FirstNamesFemale; }
            Person PersonInst = PersonGenerate(IsFemale, FirstName, LastNames, Occupations, rand);
            PersonObjectToJson(Filepath, PersonInst);
            Console.WriteLine(Counter + "/" + Quantity);
            Console.WriteLine("Name: " + PersonInst.FirstName + " " + PersonInst.LastName);
            Console.WriteLine("Sex: " + PersonInst.Sex);
            Console.WriteLine("Occupation: " + PersonInst.Occupation);
            Counter++;
        }
        Console.Write("Finished!");
        Console.ReadKey();
        //Program End
    }
    public class Person(string ConstSex, string ConstFirstName, string ConstLastName, string ConstOccupation)
    {
        public string Sex = ConstSex;
        public string FirstName = ConstFirstName;
        public string LastName = ConstLastName;
        public string Occupation = ConstOccupation;
    }
    public static Person PersonGenerate(bool IsFemale, string[] FirstNames, string[] LastNames, string[] Occupations, Random rand)
    {
        string Sex = "Male"; if (IsFemale) { Sex = "Female"; }
        string RandomFirstName = FirstNames[rand.Next(FirstNames.Length)];
        string RandomLastName = LastNames[rand.Next(LastNames.Length)];
        string RandomOccupation = Occupations[rand.Next(Occupations.Length)];
        Person p = new Person(Sex, RandomFirstName, RandomLastName, RandomOccupation);
        return p;
    }
    public static void PersonObjectToJson(string Filepath, Person Person)
    {
        string Path = Filepath;
        var JsonFormatting = Newtonsoft.Json.JsonConvert.SerializeObject(Person);
        System.IO.File.WriteAllText(Path, JsonFormatting);
    }
    static void Initialize(string FirstNamesMalePath, string FirstNamesFemalePath, string LastNamesPath, string OccupationsPath)
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
        if (!File.Exists(OccupationsPath))
        {
            File.Create(OccupationsPath).Close();
            var WriteNamesLast = new StreamWriter(OccupationsPath, true, Encoding.ASCII);
            WriteNamesLast.Write("Occupation1\nOccupation2\nOccupation3\nOccupation4\nOccupation5");
            WriteNamesLast.Close();
        }
    }
}