using Agent_management_MVC_frontend.Models;

namespace Agent_management_MVC_frontend.Shared
{
    public class Distance
    {
        public static double GetDistance(Coordinates agentLocation, Coordinates targetLocation)
        {
            var distance = Math.Sqrt(Math.Pow(agentLocation.X - targetLocation.X, 2) + Math.Pow(agentLocation.Y - targetLocation.Y, 2));

            return distance;
        }
    }
}
