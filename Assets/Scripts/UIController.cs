using UnityEngine;

public class UIController : MonoBehaviour
{
    public RobotVacuum robot;

    public void IncreaseSpeed()
    {
        robot.speed = Mathf.Min(robot.speed + 1f, 10f); // max = 10
        Debug.Log("Speed increased!");
    }


    public void DecreaseSpeed()
    {
        robot.speed -= 1f; // giảm tốc độ robot o dayy
        Debug.Log("Speed decreased!");
    }
}
