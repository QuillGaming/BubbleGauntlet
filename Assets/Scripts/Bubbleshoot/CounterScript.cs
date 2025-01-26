using UnityEngine;
using TMPro;

public class CounterScript : MonoBehaviour
{
    public TextMeshProUGUI TimerText;
    public TextMeshProUGUI CounterText;
    public int CounterLimit = 100;
    public int bubblesPopped;
    public GameObject GameOverObject;
    public bool Hit = false;
    private void Update()
    {
        if (Hit && CounterText.text.Length <= CounterLimit) {
            Hit = false;
            CounterText.text += "O";
            bubblesPopped++;

            if (bubblesPopped == 10 && TimerText.text != "0.00") {
                GameOverObject.GetComponent<MinigameOver>().HandleGame(true);
            }
        }
        if (TimerText.text == "0.00") {
            GameOverObject.GetComponent<MinigameOver>().HandleGame(false);
        }
    }
}
