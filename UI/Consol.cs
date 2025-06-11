using MalshinonPro.DAL;

namespace MalshinonPro.UI
{
    internal class Consol
    {
        internal static void Input()
        {
            Console.WriteLine("Welcome to the Sources Reporting System.\n" +
                              "Enter your ID:");
            int sourceSecretCode = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter your Name:");
            string sourceName = Console.ReadLine();

            Dictionary<string, object> sourceParameters = new Dictionary<string, object>
            {
                { "SecretCode", sourceSecretCode },
                { "Name", sourceName },
                { "Type", "source" },
                {"Title",title}
            };
            PeopleDAL.InsertSource(sourceParameters);

            Console.WriteLine("Enter The Target's CodeName:");
            int targetSecretCode = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter The Target's Name:");
            string targetName = Console.ReadLine();

            Dictionary<string, object> targetParameters = new Dictionary<string, object>
            {
                { "SecretCode", targetSecretCode },
                { "Name", targetName },
                { "Type", "target" },
                {"Title",title}
            };

            PeopleDAL.InsertSource(targetParameters);

            Console.WriteLine("Enter your report body");
            string reportBody = Console.ReadLine();
            Dictionary<string, object> rportParameters = new Dictionary<string, object>
            {
                { "TimeReported", DateTime.Now },
                { "SourceReporterID", sourceSecretCode },
                { "TargetRepotedID", targetSecretCode },
                { "ReportBody", reportBody }
            };
            ReportsCRUD.InsertReport(rportParameters);  
            Console.WriteLine("The Report has been created.\n" +
                              "Thank you!");
        }
    }
}

    
