using UnityEngine;
using System;
public class BubblewrapPopper : MonoBehaviour
{
    public AudioClip popSound;

    public static int bubblesLeft = 0;
    public void Start()
    {
        bubblesLeft = (GameObject.Find("GridGenerator").GetComponent<GenerateGrid>().bubblesToPop) + 2;
    }
    public void Update() {
        //
        GameObject Timer = GameObject.Find("Timer");
        GameObject GameOverCanvas = GameObject.Find("GameOver");
        if (Timer.GetComponent<Timer>().GetFailureStatus())
        {
            GameOverCanvas.GetComponent<MinigameOver>().HandleGame(false);
        }
        //
    }

    public GameObject unpopped, popped;
    public void OnMouseOver()
    {
        Vector3 position = transform.position;
        if (Input.GetMouseButtonDown(0)) {

            this.gameObject.SetActive(false);
            Instantiate(popped, position, Quaternion.identity);
            popped.gameObject.SetActive(true);
            bubblesLeft -= 1;
            if (bubblesLeft == 0) 
            {
                GameObject Timer = GameObject.Find("Timer");
                GameObject GameOverCanvas = GameObject.Find("GameOver");
                if (Timer.GetComponent<Timer>().GetFailureStatus())
                {
                    GameOverCanvas.GetComponent<MinigameOver>().HandleGame(false);
                }
                else
                {
                    Timer.GetComponent<Timer>().StopTimer();
                    GameOverCanvas.GetComponent<MinigameOver>().HandleGame(true);
                }
            }
        }
    }
}
