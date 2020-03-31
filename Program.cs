using System;
using CodingCampusCSharpHomework;

class Storage
{
    public Storage(string descriptionString) => LoadFromString(descriptionString);
    public bool LoadFromString(string descriptionString)
    {
        string[] fields = descriptionString.Split(';');

        if (fields.Length != 4)
        {
            Console.Error.WriteLine("Storage parse error.");
            return false;
        }

        m_Name = fields[0];
        m_Address = fields[1];
        m_Coordinates = new Coordinates(fields[2], fields[3]);

        return true;
    }

    public float GetDistanceToPoint(Coordinates point) => m_Coordinates.GetDistanceToPoint(point);

    public string GetUserDescription() => $"Name: {m_Name}; Address: {m_Address}";

    private string m_Name;
    private string m_Address;
    private Coordinates m_Coordinates;
}

struct Coordinates
{
    public Coordinates(string longitudeString, string latitudeString)
    {
        if (float.TryParse(longitudeString, out float longitude)
            && float.TryParse(latitudeString, out float latitude))
        {
            m_Longitude = longitude;
            m_Latitude = latitude;
        }
        else
        {
            Console.Error.WriteLine("Coordinates parse error.");
            m_Longitude = 0f;
            m_Latitude = 0f;
        }
    }

    public float GetDistanceToPoint(Coordinates point)
    {
        const float EarthRadiusKm = 6371f;

        float x = (point.m_Longitude - m_Longitude) * MathF.Cos((m_Latitude + point.m_Latitude) / 2f);
        float y = point.m_Latitude - m_Latitude;

        return MathF.Sqrt(MathF.Pow(x, 2f) + MathF.Pow(y, 2f)) * EarthRadiusKm;
    }

    private float m_Longitude { get; set; }
    private float m_Latitude { get; set; }
}


namespace HomeworkTemplate
{
    using System.Linq;
    class Program
    {
        static void Main(string[] args)
        {
            Func<Task3, string> TaskSolver = task =>
            {
                Coordinates userCoordinates = new Coordinates(task.UserLongitude, task.UserLatitude);

                return task.DefibliratorStorages
                    .Select(storageDescription => {
                        Storage storage = new Storage(storageDescription);
                        return new { storage, distance = storage.GetDistanceToPoint(userCoordinates) };
                    })
                    .Aggregate((s1, s2) => s1.distance < s2.distance ? s1 : s2)
                    .storage.GetUserDescription();
            };

            Task3.CheckSolver(TaskSolver);
        }
    }
}
