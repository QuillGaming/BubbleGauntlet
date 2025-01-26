using UnityEngine;
using TMPro;

public class endScript : MonoBehaviour
{
    [SerializeField]
    private GameObject gameOverObject;

    [SerializeField]
    private TextMeshProUGUI timerText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (timerText.text == "0.00")
        {
            gameOverObject.GetComponent<MinigameOver>().HandleGame(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
