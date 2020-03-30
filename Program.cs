using System;
using CodingCampusCSharpHomework;

namespace HomeworkTemplate
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<Task3, string> TaskSolver = task =>
            {
                // Your solution goes here
                // You can get all needed inputs from task.[Property]
                // Good luck!
                string UserLongitude = task.UserLongitude;
                string UserLatitude = task.UserLatitude;
                int placesAmount = task.DefibliratorStorages.Length;

                for (int i = 0; i < placesAmount; i++)
                {
                    string defibliratorStorage = task.DefibliratorStorages[i];
                }   
                
                return "My answer";
            };

            Task3.CheckSolver(TaskSolver);
        }
    }
}
