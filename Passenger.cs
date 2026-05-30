using System;

public class SensorArray
{
    private int _simulatedDistance;
    public SensorArray() => _simulatedDistance = 150;
    public void UpdateObstacleDistance(int meters) => _simulatedDistance = meters;
    public int GetObstacleDistance() => _simulatedDistance;
    public bool IsPathClear() => _simulatedDistance >= 15;

    // ВЕРСІЯ 4: Унарний оператор '-' (Примусове зменшення безпечної дистанції)
    public static SensorArray operator -(SensorArray s)
    {
        // Імітує сильне зашумлення чи збій (зменшує дистанцію фіксації вдвічі)
        s._simulatedDistance /= 2;
        return s;
    }
}
