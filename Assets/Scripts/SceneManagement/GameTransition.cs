using System.Collections;
using System.Linq;
using TMPro;
using Unity.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameTransition : MonoBehaviour
{
    [SerializeField]
    private TMP_Text Text;
    [SerializeField]
    private AudioSource pop;
    private char game;

    void Start()
    {
        UnityEngine.Random.InitState((int)Time.time);
        string remainingGames = PlayerPrefs.GetString("RemainingGames");
        if (remainingGames == "")
        {
            pop.Play();
            Text.text = "Congratulations! You won " + PlayerPrefs.GetInt("Wins").ToString() + 
                " out of 4 minigames!";
            Invoke("GoToCredits", 3.0f);
        }
        else
        {
            pop.Play();
            string gamesLeft = "";
            int numGames = remainingGames.Length;
            int i = Random.Range(0, numGames);
            game = remainingGames[i];
            string gameStr = game.ToString();

            for (int j = 0; j < numGames; j++)
            {
                if (j.ToString() != gameStr)
                {
                    gamesLeft += remainingGames[j];
                }
            }

            PlayerPrefs.SetString("RemainingGames", gamesLeft);
            PlayerPrefs.Save();
            StartCoroutine("Transition");
        }
    }

    private void GoToCredits()
    {
        SceneManager.LoadScene("Credits");
    }

    IEnumerator Transition()
    {
        yield return new WaitForSeconds(2.0f);
        Text.text = "3";
        pop.Play();
        yield return new WaitForSeconds(1.0f);
        Text.text = "2";
        pop.Play();
        yield return new WaitForSeconds(1.0f);
        Text.text = "1";
        pop.Play();
        yield return new WaitForSeconds(1.0f);
        Text.text = "Go!!!";
        pop.Play();
        yield return new WaitForSeconds(0.5f);
        switch (game)
        {
            case '0':
                SceneManager.LoadScene("BubbleBox");
                break;
            case '1':
                SceneManager.LoadScene("BubbleWrap");
                break;
            case '2':
                SceneManager.LoadScene("BubbleShoot");
                break;
            case '3':
                SceneManager.LoadScene("BubbleMaze");
                break;
        }
    }
}
