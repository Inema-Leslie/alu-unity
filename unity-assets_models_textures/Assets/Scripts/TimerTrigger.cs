using UnityEngine;

public class TimerTrigger : MonoBehaviour
{
    private Timer timer;
    private bool timerStarted = false;

    void Start()
    {
        // Find the Timer script on the Player
        timer = FindObjectOfType<Timer>();
    }

    void OnTriggerExit(Collider other)
    {
        // When Player exits the trigger, start the timer
        if (other.CompareTag("Player") && !timerStarted)
        {
            timer.enabled = true;
            timer.StartTimer();
            timerStarted = true;
        }
    }
}