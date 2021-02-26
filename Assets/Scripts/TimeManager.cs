using UnityEngine;

public class TimeManager : MonoBehaviour
{

    public float slowdownFactor = 0.05f; // the more, the slower
    public float slowdownLength = 2f; // slowdown for 2 secs

    void DoSlowMotion()
    {
        Time.timeScale = slowdownFactor; // 1/0.05 = 20 => 20x slower
    }
}
