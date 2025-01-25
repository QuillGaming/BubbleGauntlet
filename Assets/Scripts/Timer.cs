using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI TimerText;

    public float currentTime;
    public bool countDown = true;

    public bool hasLimit;
    public float timerLimit;

    void Start()
    {

    }

    void Update()
    {
        currentTime -= Time.deltaTime;

        if (hasLimit && ((countDown && currentTime <= timerLimit))) {
            currentTime = timerLimit;
            SetTimerText();
            TimerText.color = Color.red;
            enabled = false;
            //load fail scene
        }

        SetTimerText();
    }
    private void SetTimerText() {
        TimerText.text = currentTime.ToString("0.00");

    }
}