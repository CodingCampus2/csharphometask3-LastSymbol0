using System;
using CodingCampusCSharpHomework;

class Storage
{
    public bool LoadFromString(string descriptionString)
    {
        string[] fields = descriptionString.Split(';');
        bool isParseSucceed = fields.Length == 4;

        m_Name = fields[0];
        m_Address = fields[1];
        isParseSucceed = m_Coordinates.LoadFromString(fields[2], fields[3]);

        if (!isParseSucceed)
        {
            Console.Error.WriteLine("Storage parse error.");
        }

        return isParseSucceed;
    }

    public float GetDistanceToPoint(Coordinates point)
    {
        return m_Coordinates.GetDistanceToPoint(point);
    }

    public string GetUserDescription()
    {
        return $"Name: {m_Name}; Address: {m_Address}";
    }

    private string m_Name;
    private string m_Address;
    private Coordinates m_Coordinates = new Coordinates();
}

class Coordinates
{
    public bool LoadFromString(string longitudeString, string latitudeString)
    {
        float longitude = 0.0f, latitude = 0.0f;
        bool isParseSucceed = float.TryParse(longitudeString, out longitude) && float.TryParse(latitudeString, out latitude);

        if (!isParseSucceed)
        {
            Console.Error.WriteLine("Coordinates parse error.");
        }
        else
        {
            m_Longitude = longitude;
            m_Latitude = latitude;
        }

        return isParseSucceed;
    }

    public float GetDistanceToPoint(Coordinates point)
    {
        const float EarthRadiusKm = 6371;

        float x = (point.m_Longitude - m_Longitude) * MathF.Cos((m_Latitude + point.m_Latitude) / 2.0f);
        float y = point.m_Latitude - m_Latitude;

        return MathF.Sqrt(MathF.Pow(x, 2) + MathF.Pow(y, 2)) * EarthRadiusKm;
    }

    private float m_Longitude { get; set; }
    private float m_Latitude { get; set; }
}

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
                int placesAmount = task.DefibliratorStorages.Length;

                Coordinates userCoordinates = new Coordinates();
                userCoordinates.LoadFromString(task.UserLongitude, task.UserLatitude);

                Storage nearestStorage = new Storage();
                float distanceToNearestSorage = float.MaxValue;

                for (int i = 0; i < placesAmount; i++)
                {
                    string defibliratorStorage = task.DefibliratorStorages[i];

                    Storage storage = new Storage();
                    storage.LoadFromString(defibliratorStorage);
                    float distanseToStorage = storage.GetDistanceToPoint(userCoordinates);

                    if (distanseToStorage < distanceToNearestSorage)
                    {
                        distanceToNearestSorage = distanseToStorage;
                        nearestStorage = storage;
                    }
                }
                
                return nearestStorage.GetUserDescription();
            };

            Task3.CheckSolver(TaskSolver);
        }
    }
}
