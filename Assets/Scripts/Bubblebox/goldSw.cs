using UnityEngine;

public class goldSw : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void select()
    {
        GameObject.Find("launch_bubble").GetComponent<SpriteRenderer>().color = (Color)new Color32(255, 255, 0, 255);
    }
}
