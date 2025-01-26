using UnityEngine;

public class ObstacleEffect : MonoBehaviour
{
    [SerializeField]
    private GameObject GameOver;

    [SerializeField]
    private AudioSource Pop;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.SetActive(false);
            Pop.Play();
            GameOver.GetComponent<MinigameOver>().HandleGame(false);
        }
    }
}
