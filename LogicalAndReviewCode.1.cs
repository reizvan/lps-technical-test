using System;

class Program
{
    static void Main(string[] args)
    {
        Application application = new Application();
        application.Protected = new ProtectedClass();
        application.Protected.ShieldLastRun = true;

        bool? shieldLastRun = GetShieldLastRun(application);

        Console.WriteLine("shieldLastRun: " + shieldLastRun);

        Console.ReadLine();
    }

    public bool? GetShieldLastRun(Application application)
    {
        //if (application != null)
        //{
        //    if (application.Protected != null)
        //    {
        //        return application.protected.shieldLastRun;
        //    }
        //}

        // using the null conditional operator (?.) to improve the readability and cleanliness of the code safely access nested properties without worrying about null reference exceptions.

        return application?.Protected?.ShieldLastRun;
    }
}

public class Application
{
    public ProtectedClass Protected { get; set; }
}

public class ProtectedClass
{
    public bool ShieldLastRun { get; set; }
}
