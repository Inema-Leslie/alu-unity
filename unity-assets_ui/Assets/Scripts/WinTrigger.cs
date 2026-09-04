using UnityEngine;
using UnityEngine.UI;

public class WinTrigger : MonoBehaviour
{
    private Timer timer;
    private Text timerText;

    void Start()
    {
        timer = FindObjectOfType<Timer>();
        timerText = timer.TimerText;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Stop the timer
            timer.enabled = false;

            // Increase font size
            timerText.fontSize = 60;

            // Change color to green
            timerText.color = Color.green;
        }
    }
}