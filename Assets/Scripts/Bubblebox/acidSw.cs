using UnityEngine;

public class acidSw : MonoBehaviour
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
        GameObject.Find("launch_bubble").GetComponent<SpriteRenderer>().color = (Color)new Color32(71, 255, 87, 255);
    }
}
