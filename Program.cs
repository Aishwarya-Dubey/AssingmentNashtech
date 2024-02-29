using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssingmentNashtech
{
    internal class Program
    {


        static void Main(string[] args)
        {
            // Run the functionality of Program
            Console.WriteLine("PROGRAM 1 RUN");
            RunProgram();

            // Run the functionality of Program2
            Console.WriteLine("PROGRAM 2 RUN");
            Program2.Run();

            // Run the functionality of Program3
            Console.WriteLine("PROGRAM 3 RUN");
            Program3.Run();

            // Run the functionality of Program4
            Console.WriteLine("PROGRAM 4 RUN");
            Program4.Run();

            // Run the functionality of Program5
            Console.WriteLine("PROGRAM 5 RUN");
            Program5.Run();
        }
        static void RunProgram()
        {
            Console.WriteLine("Enter a few words separated by space:");
            string input = Console.ReadLine();

            string pascalCase = ConvertToPascalCase(input);

            Console.WriteLine("PascalCase variable name: " + pascalCase);
        }

        static string ConvertToPascalCase(string input)
        {
            StringBuilder result = new StringBuilder();
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            string[] words = input.ToLower().Split(' ');

            foreach (string word in words)
            {
                if (!string.IsNullOrEmpty(word))
                {
                    result.Append(textInfo.ToTitleCase(word));
                }
            }

            return result.ToString().Replace(" ", "");
        }

    }

    internal class Program2
    {
        public static void Run()
        {
            List<string> likes = new List<string>();

            Console.WriteLine("Enter names of people who liked your post (press Enter to finish):");
            string input;
            do
            {
                input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    likes.Add(input);
                }
            } while (!string.IsNullOrWhiteSpace(input));

            DisplayLikes(likes);
            // Display likes or perform other actions
        }

       
  

        static void DisplayLikes(List<string> likes)
        {
            int count = likes.Count;

            switch (count)
            {
                case 0:
                    Console.WriteLine("No one likes your post.");
                    break;
                case 1:
                    Console.WriteLine($"{likes[0]} likes your post.");
                    break;
                case 2:
                    Console.WriteLine($"{likes[0]} and {likes[1]} like your post.");
                    break;
                default:
                    Console.Write($"{likes[0]}, {likes[1]}");
                    if (count > 2)
                    {
                        Console.Write($" and {count - 2} others");
                    }
                    Console.WriteLine(" like your post.");
                    break;
            }
        }

    }




    internal  class Program3
    {
        public static void Run()
        {
            Stopwatch stopwatch = new Stopwatch();

            // Example usage
            stopwatch.Start();
            System.Threading.Thread.Sleep(2000); // Simulating some work
            stopwatch.Stop();

            // Start and stop again
            stopwatch.Start();
            System.Threading.Thread.Sleep(1500); // Simulating some work
            stopwatch.Stop();
        }
    }

    public class Stopwatch
    {
        private DateTime _startTime;
        private DateTime _stopTime;
        private bool _isRunning;

        public void Start()
        {
            if (_isRunning)
            {
                throw new InvalidOperationException("Stopwatch is already running.");
            }

            _startTime = DateTime.Now;
            _isRunning = true;
            Console.WriteLine("Stopwatch started.");
        }

        public void Stop()
        {
            if (!_isRunning)
            {
                throw new InvalidOperationException("Stopwatch is not running.");
            }

            _stopTime = DateTime.Now;
            _isRunning = false;
            TimeSpan duration = _stopTime - _startTime;
            Console.WriteLine($"Stopwatch stopped. Duration: {duration}");
        }
    }





    public class Post
    {
        private int _votes;

        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime CreationTime { get; private set; }

        public int Votes
        {
            get { return _votes; }
        }

        public Post(string title, string description)
        {
            Title = title;
            Description = description;
            CreationTime = DateTime.Now;
            _votes = 0;
        }

        public void UpVote()
        {
            _votes++;
        }

        public void DownVote()
        {
            _votes--;
        }
    }

    internal class Program4
    {
        public static void Run()
        {
            // Create a post
            Post myPost = new Post("Title of the post", "Description of the post");


            // Up-vote and down-vote
            myPost.UpVote();
            myPost.UpVote();
            myPost.DownVote();


            // Display current vote value
            Console.WriteLine($"Current vote value: {myPost.Votes}");
        }
    }




    public interface IActivity
    {
        void Execute();
    }

    // Define some sample activities
    public class Activity1 : IActivity
    {
        public void Execute()
        {
            Console.WriteLine("Executing Activity 1");
        }
    }

    public class Activity2 : IActivity
    {
        public void Execute()
        {
            Console.WriteLine("Executing Activity 2");
        }
    }

    public class Activity3 : IActivity
    {
        public void Execute()
        {
            Console.WriteLine("Executing Activity 3");
        }
    }

    // Define the workflow engine
    public class WorkflowEngine
    {
        public void Run(List<IActivity> workflow)
        {
            foreach (var activity in workflow)
            {
                activity.Execute();
            }
        }
    }

    // Example usage
    internal class Program5
    {
        public static void Run()
        {
            // Create a workflow
            List<IActivity> workflow = new List<IActivity>
        {
            new Activity1(),
            new Activity2(),
            new Activity3()
        };

            // Create and run the workflow engine
            WorkflowEngine workflowEngine = new WorkflowEngine();
            workflowEngine.Run(workflow);
        }
    }


}
