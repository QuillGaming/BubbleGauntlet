using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    private AudioSource pop;
    public void StartGame()
    {
        string games = "0123";
        int wins = 0;
        PlayerPrefs.SetString("RemainingGames", games);
        PlayerPrefs.SetInt("Wins", wins);
        PlayerPrefs.Save();
        pop.Play();
        StartCoroutine(SceneLoad("GameTransition"));
    }

    public void Credits()
    {
        pop.Play();
        StartCoroutine(SceneLoad("Credits"));
    }

    public void Exit()
    {
        pop.Play();
        Application.Quit();
    }

    IEnumerator SceneLoad(string sceneName)
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(sceneName);
    }
}
