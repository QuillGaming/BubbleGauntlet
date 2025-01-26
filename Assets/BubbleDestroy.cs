using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

public class BubbleDestroy : MonoBehaviour

{
    public AudioClip pop;
    public AudioSource audioSource;
    public GameObject counterObject;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void OnMouseOver()
    {
        //pretend it's always a hit
        if (Input.GetMouseButtonDown(0)) {
            counterObject.GetComponent<CounterScript>().Hit = true;
            audioSource.clip = pop;
            audioSource.Play();
            Debug.Log("Over Bubble.");
            this.transform.GetChild(0).gameObject.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }

    void OnMouseExit()
    {
        Debug.Log("and Under Bubble");
    }
}