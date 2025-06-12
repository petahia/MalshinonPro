using MalshinonPro.DAL;

namespace MalshinonPro.UI
{
    internal class Console
    {
        internal static void Input()
        {
            System.Console.WriteLine("Welcome to the Sources Reporting System.\n" +
                                     "Enter your ID:");
            int sourceSecretCode = int.Parse(System.Console.ReadLine());
            System.Console.WriteLine("Enter your Name:");
            string sourceName = System.Console.ReadLine();

            string title = "";
            Dictionary<string, object> sourceParameters = new Dictionary<string, object>
            {
                { "SecretCode", sourceSecretCode },
                { "Name", sourceName },
                { "Type", "source" },
                {"Title",title}
            };

            System.Console.WriteLine("Enter The Target's CodeName:");
            int targetSecretCode = int.Parse(System.Console.ReadLine());
            System.Console.WriteLine("Enter The Target's Name:");
            string targetName = System.Console.ReadLine();

            Dictionary<string, object> targetParameters = new Dictionary<string, object>
            {
                { "SecretCode", targetSecretCode },
                { "Name", targetName },
                { "Type", "target" },
                { "Title",title }
            };


            System.Console.WriteLine("Enter your report body");
            string reportBody = System.Console.ReadLine();
            Dictionary<string, object> rportParameters = new Dictionary<string, object>
            {
                { "TimeReported", DateTime.Now },
                { "SourceReporterID", sourceSecretCode },
                { "TargetRepotedID", targetSecretCode },
                { "ReportBody", reportBody }
            };
            PeopleDAL.InsertSource(targetParameters);
            PeopleDAL.InsertSource(sourceParameters);
            ReportsDAL.InsertReport(rportParameters);
            int grade = PeopleDAL.AnalaisisSource(sourceSecretCode);
            if (grade >= 100)
            {
                title = "Agent";
            }
            else
            {
                title = "notAgent";
            }

            Dictionary<string, object> newTitle = new Dictionary<string, object>
            {
                { "Title", title }
            };
            PeopleDAL.UpdateTitle(newTitle,sourceSecretCode);

            System.Console.WriteLine("The Report has been created.\n" +
                                     "Thank you!");
        }
    }
}

    
