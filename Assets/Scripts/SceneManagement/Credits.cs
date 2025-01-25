using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    [SerializeField]
    private GameObject Text;
    [SerializeField]
    private Vector3 StartPosition;
    [SerializeField]
    private Vector3 EndPosition;
    [SerializeField]
    private int duration;

    private float elapsedTime;

    private void Start()
    {
        elapsedTime = 0.0f;
        Invoke("Return", duration);
    }

    void Update()
    {
        if (elapsedTime < duration)
        {
            float t = elapsedTime / duration;
            Text.transform.position = Vector3.Lerp(StartPosition, EndPosition, t);
            elapsedTime += Time.deltaTime;
        }
    }

    private void Return()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
