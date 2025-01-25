using UnityEngine;
using System;
public class BubblewrapPopper : MonoBehaviour
{


    public static int bubblesLeft = 0;
    public void Start()
    {
        bubblesLeft = (GameObject.Find("GridGenerator").GetComponent<GenerateGrid>().bubblesToPop) + 2;
        Debug.Log(bubblesLeft);
    }


    public GameObject unpopped, popped;
    public void OnMouseOver()
    {
        Vector3 position = transform.position;
        if (Input.GetMouseButtonDown(0)) {
            //play sound
            this.gameObject.SetActive(false);
            Instantiate(popped, position, Quaternion.identity);
            popped.gameObject.SetActive(true);
            bubblesLeft -= 1;
            Debug.Log("There are" + bubblesLeft + "bubbles to pop");
        }
    }
    public void Update()
    {
        if (bubblesLeft == 0) { 
            //load next scene! or success scene
        }


    }
}
