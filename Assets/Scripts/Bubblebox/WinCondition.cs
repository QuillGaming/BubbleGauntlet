using UnityEngine;

public class WinCondition : MonoBehaviour
{
    [SerializeField]
    private GameObject Timer;
    [SerializeField]
    private GameObject GameOver;

    // Update is called once per frame
    void Update()
    {
        if (Timer.GetComponent<Timer>().GetFailureStatus())
        {
            GameOver.GetComponent<MinigameOver>().HandleGame(false);
        }
    }
}
