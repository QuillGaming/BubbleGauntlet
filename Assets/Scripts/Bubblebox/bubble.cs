using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class bubble : MonoBehaviour
{
    [SerializeField]
    private GameObject film;

    [SerializeField]
    private AudioClip[] clips;

    [SerializeField]
    private AudioSource audioOutput;

    private float currTime;
    private float totDur;
    private Vector2 startVec = new Vector2(3, -5);
    private Vector2 destVec;
    private Vector3 startScale = new Vector3(0.15f, 0.15f, 0.15f);
    private Vector3 destScale = new Vector3(0.05f, 0.05f, 0.05f);
    private bool pos = false;
    private bool play = false;
    private bool isMethane = false;
    private bool isOil = false;
    private bool isElectric = false;
    private bool isFire = false;
    private bool isFrozen = false;
    private bool isWet = false;
    private bool changeCol = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currTime = 0;
        totDur = 0.7f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !pos)
        {
            Vector3 mousePos = Mouse.current.position.ReadValue();
            if (mousePos.x > 507 && mousePos.x < 1477 && mousePos.y > 148 && mousePos.y < 670) //THESE NUMBERS ARE VERY RESOLUTION SPECIFIC
            {
                mousePos.z = Camera.main.nearClipPlane + 1;
                destVec = Camera.main.ScreenToWorldPoint(mousePos);
                currTime = 0;
                pos = true;
                play = true;
            }
            Color32 color = GetComponent<SpriteRenderer>().color;
            if ((color.r == 255 && color.g == 0 && color.b == 0 && isMethane)
                || (color.r == 67 && color.g == 67 && color.b == 67 && isFire))
            {
                audioOutput.clip = clips[2];
                audioOutput.Play();
            }
        }

        if (pos)
        {
            float t = currTime / totDur;
            transform.position = Vector3.Lerp(startVec, destVec, t);
            transform.localScale = Vector2.Lerp(startScale, destScale, t);
            currTime += Time.deltaTime;
            if (currTime >= totDur && play)
            {
                Color color = GetComponent<SpriteRenderer>().color;
                color.a = 0;
                GetComponent<SpriteRenderer>().color = color;
                doThing(color);
                play = false;
            }
            if (currTime >= totDur + 0.1)
            {
                pos = false;
            }
        }
        else
        {
            transform.position = startVec;
            transform.localScale = startScale;
            Color color = GetComponent<SpriteRenderer>().color;
            color.a = 1;
            GetComponent<SpriteRenderer>().color = color;
        }
    }

    void doThing(Color color)
    {
        Color32 nColor = color;
        nColor.a = 127;
        if (nColor.r == 121 && nColor.g == 201 && nColor.b == 255) //water
        {
            isWet = true;
            if (isFrozen)
            {
                audioOutput.clip = clips[8];
                nColor.r = 255;
                nColor.g = 255;
                nColor.b = 255;
            }
            else
            {
                audioOutput.clip = clips[4];
                isFire = false;
                isOil = false;
                isMethane = false;
                isElectric = false;
            }
        }
        else if (nColor.r == 255 && nColor.g == 255 && nColor.b == 255) //oil
        {
            if (isFire)
            {
                audioOutput.clip = clips[3];
                changeCol = false;
            }
            else
            {
                audioOutput.clip = clips[4];
                isOil = true;
                nColor.a = 50;
                isMethane = false;
                isElectric = false;
                isWet = false;
                isFrozen = false;
            }
        }
        else if (nColor.r == 67 && nColor.g == 67 && nColor.b == 67) //methane
        {
            if (isFire)
            {
                isFire = false;
                nColor.a = 0;
            }
            else
            {
                audioOutput.clip = clips[0];
                isMethane = true;
                isOil = false;
                isElectric = false;
                isFrozen = false;
                isWet = false;
            }
        }
        else if (nColor.r == 255 && nColor.g == 255 && nColor.b == 0) //gold
        {
            if (isElectric)
            {
                audioOutput.clip = clips[5];
                nColor.b = 127;
            }
            else
            {
                audioOutput.clip = clips[6];
                isFire = false;
                isOil = false;
                isMethane = false;
                isFrozen = false;
                isWet = false;
            }
        }
        else if (nColor.r == 255 && nColor.g == 149 && nColor.b == 0) //copper
        {
            audioOutput.clip = clips[6];
            isElectric = true;
            isFire = false;
            isOil = false;
            isMethane = false;
            isFrozen = false;
            isWet = false;
        }
        else if (nColor.r == 0 && nColor.g == 0 && nColor.b == 255) //liquid nitrogen
        {
            isFrozen = true;
            if (isWet)
            {
                audioOutput.clip = clips[8];
                nColor.r = 255;
                nColor.g = 255;
                nColor.b = 255;
            }
            else
            {
                audioOutput.clip = clips[4];
                isElectric = false;
                isFire = false;
                isOil = false;
                isMethane = false;
            }
        }
        else if (nColor.r == 255 && nColor.g == 0 && nColor.b == 0) //fire
        {
            if (isMethane)
            {
                isMethane = false;
                nColor.a = 0;
            }
            else if (isOil)
            {
                audioOutput.clip = clips[3];
                isOil = false;
                isFire = true;
            }
            else
            {
                audioOutput.clip = clips[4];
                changeCol = false;
                isElectric = false;
                isFrozen = false;
                isWet = false;
            }
        }
        else if (nColor.r == 71 && nColor.g == 255 && nColor.b == 87) //acid
        {
            audioOutput.clip = clips[7];
            isFire = false;
            isOil = false;
            isMethane = false;
            isElectric = false;
            isFrozen = false;
            isWet = false;
        }
        else if (nColor.r == 137 && nColor.g == 82 && nColor.b == 0) //soda
        {
            audioOutput.clip = clips[1];
            isFire = false;
            isOil = false;
            isMethane = false;
            isElectric = false;
            isFrozen = false;
            isWet = false;
        }
        audioOutput.Play();
        if (changeCol)
        {
            film.GetComponent<SpriteRenderer>().color = (Color)nColor;
        }
        else
        {
            changeCol = true;
        }
    }
}
