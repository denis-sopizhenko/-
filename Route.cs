using System;

public class Route
{
    public string StartPoint { get; set; }
    public string Destination { get; set; }
    public int DistanceKm { get; set; }

    public Route(string startPoint, string destination, int distanceKm)
    {
        StartPoint = startPoint;
        Destination = string.IsNullOrEmpty(destination) ? "Unknown Destination" : destination;
        DistanceKm = distanceKm;
    }
}