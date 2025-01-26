using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;
public class ShootyScript : MonoBehaviour
{

    //Wheever you end up doing audio for the projectile
    [SerializeField]
    public AudioClip pewpew;
    [SerializeField]
    public AudioSource audioSource;
    public GameObject playerShot;
    public GameObject counterObject;
    [SerializeField]
    public Transform playerAim;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        Vector3 mousePos = Mouse.current.position.ReadValue();
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        mousePos.z = 0;
        transform.up = mousePos - this.transform.position;

        if (Mouse.current.leftButton.IsPressed()) {
            //projectile stuff here
            // GameObject newShot = Instantiate(playerShot);
            // newShot.transform.position = playerAim.position;
            // newShot.transform.up = mousePos - this.transform.position;
            //play sfx
            audioSource.clip = pewpew;
            audioSource.Play();
        }
    }
}
