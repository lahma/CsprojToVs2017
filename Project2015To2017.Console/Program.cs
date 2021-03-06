using System;
using System.Linq;

namespace Project2015To2017.Console
{
    class Program
    {
        static void Main(string[] args)
        {
	        if (args.Length == 0)
	        {
		        System.Console.WriteLine("Please specify a project file.");
		        return;
	        }

			var writer = new Writing.ProjectWriter();

	        var progress = new Progress<string>(System.Console.WriteLine);

	        var convertedProjects = ProjectConverter.Convert(args[0], progress)
													.Where(x => x != null)
													.ToList();

	        if (!args.Contains("--dry-run"))
	        {
		        foreach (var project in convertedProjects)
		        {
			        writer.Write(project, progress);
		        }
	        }
        }
    }
}
