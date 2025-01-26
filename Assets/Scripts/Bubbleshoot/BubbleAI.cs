using NUnit;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class BubbleAI : MonoBehaviour
{
    private bool isMoving;

    private Vector2 screenBounds;
    private float width;
    private float height;

    private float speed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        isMoving = false;
        UnityEngine.Random.InitState((int)Time.time);

        width = this.transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        height = this.transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        speed = 3.0f;
    }

    // Update is called once per frame
    private void Update()
    {
        if (!isMoving)
        {
            isMoving = true;
            StartCoroutine("Move");
        }
    }

    IEnumerator Move()
    {
        bool goodPos = false;
        Vector2 startPos = this.transform.position;
        Vector2 endPos = new Vector2(0.0f, 0.0f);
        while (!goodPos)
        {
            float xCoord = UnityEngine.Random.Range(-screenBounds.x + (2 * width), screenBounds.x - (2 * width));
            float yCoord = UnityEngine.Random.Range(-screenBounds.y + (2 * height), screenBounds.y - (2 * height));
            if (xCoord > 2 || xCoord < -2 || yCoord > 2 || yCoord < -2)
            {
                goodPos = true;
                endPos = new Vector2(xCoord, yCoord);
            }
        }

        float distance = Vector3.Distance(startPos, endPos);
        float duration = distance / speed;
        float t = 0.0f;
        while (t < duration)
        {
            t += Time.deltaTime;
            this.transform.position = Vector3.Lerp(startPos, endPos, t / duration);
            yield return null;
        }
        isMoving = false;
    }
}
