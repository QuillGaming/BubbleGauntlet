using UnityEngine;

public class Winzone : MonoBehaviour
{
    [SerializeField]
    private GameObject GameOver;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameOver.GetComponent<MinigameOver>().HandleGame(true);
    }
}
