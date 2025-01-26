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
        if (Hit) {
            Hit = false;
            bubblesPopped++;
        }
        if (Hit && CounterText.text.Length <= CounterLimit) {
            CounterText.text += "O";

            if (bubblesPopped == 50 && TimerText.text != "0.00") {
                GameOverObject.GetComponent<MinigameOver>().HandleGame(true);
            }
        }
        if (TimerText.text == "0.00") {
            GameOverObject.GetComponent<MinigameOver>().HandleGame(false);
        }
    }
}
