using UnityEngine;

public class bubbleClr : MonoBehaviour
{
    [SerializeField]
    private GameObject film;

    [SerializeField]
    private GameObject bubble;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void clear()
    {
        film.GetComponent<SpriteRenderer>().color = (Color)new Color32(255, 255, 255, 0);
        bubble.GetComponent<bubble>().clearFilm();
    }
}
