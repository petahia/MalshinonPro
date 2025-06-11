namespace MalshinonPro.UI
{
    internal class Consol
    {
        internal static void Input()
        {
            Console.WriteLine("Welcome to the Sources Reporting System.\n" +
                              "Enter your ID:");
            string sourceSecretCode = Console.ReadLine();
            Console.WriteLine("Enter your Name:");
            string sourceName = Console.ReadLine();
            
            // (אם לא קיים) חסר הוספת מקור חדש לטבלת אנשים
            
            Console.WriteLine("Enter The Target's CodeName:");
            string targetSecretCode = Console.ReadLine();
            Console.WriteLine("Enter The Target's Name:");
            string targetName = Console.ReadLine();
            
            // חסר הוספת מטרה חדשה לטבלת אנשים (אם לא קיים)
            
            Console.WriteLine("Enter your report body");
            string reportBody = Console.ReadLine();
            
            // חסר הוספת דיווח חדש כולל שעה המקור והיעד לטבלת דיווחים
            
            
        }
    }
}
    
