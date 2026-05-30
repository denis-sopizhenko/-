using System;

public class SensorArray
{
    private int _simulatedDistance;

    public SensorArray() => _simulatedDistance = 150;
    public SensorArray(SensorArray other) => this._simulatedDistance = other._simulatedDistance;

    public void UpdateObstacleDistance(int meters) => _simulatedDistance = meters;
    public int GetObstacleDistance() => _simulatedDistance;
    public bool IsPathClear() => _simulatedDistance >= 15;

    public static SensorArray operator -(SensorArray s)
    {
        s._simulatedDistance /= 2;
        return s;
    }
}
