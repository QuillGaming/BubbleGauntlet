using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinigameOver : MonoBehaviour
{
    [SerializeField]
    private GameObject Bubble;
    [SerializeField]
    private TMP_Text Text;
    [SerializeField]
    private AudioSource Pop;

    public void HandleGame(bool win)
    {
        Bubble.SetActive(true);
        Pop.Play();
        if (win)
        {
            int temp = PlayerPrefs.GetInt("Wins");
            PlayerPrefs.SetInt("Wins", temp + 1);
            PlayerPrefs.Save();
        }
        else
        {
            Text.text = "Uh-oh! You lost!";
        }
        Invoke("ChangeScene", 2.0f);
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene("GameTransition");
    }
}
