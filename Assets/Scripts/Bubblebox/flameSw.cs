using UnityEngine;

public class flameSw : MonoBehaviour
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
        GameObject.Find("launch_bubble").GetComponent<SpriteRenderer>().color = (Color)new Color32(255, 0, 0, 255);
    }
}
