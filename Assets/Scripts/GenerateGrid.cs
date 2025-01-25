using UnityEngine;

public class GenerateGrid : MonoBehaviour
{
    [SerializeField] public float spawnX;
    [SerializeField] public float spawnY;
    [SerializeField] public float timeLeft;

    public GameObject[] itemsToPickFrom;
    public int gridX;
    public int gridY;
    public float gridSpacingOffset = 1f;
    public Vector3 gridOrigin = Vector3.zero;

    public int bubblesToPop = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gridOrigin.Set(spawnX, spawnY, 0);
        SpawnGrid(); 
    }

    public void SpawnGrid() 
    {
        for (int x = 0; x < gridX; x++) 
        {
            for (int y = 0; y < gridY; y++) 
            {
                Vector3 spawnPosition = new Vector3(x * gridSpacingOffset, y * gridSpacingOffset, 0) + gridOrigin;
                PickAndSpawn(spawnPosition, Quaternion.identity);
            }
            //Debug.Log("There are" + bubblesToPop + "bubbles to pop");
        }
    }

    public void PickAndSpawn(Vector3 positionToSpawn, Quaternion rotationToSpawn) 
    {
        int randomIndex = Random.Range(0, itemsToPickFrom.Length);
        GameObject clone = Instantiate(itemsToPickFrom[randomIndex], positionToSpawn, rotationToSpawn);
        //count amount of bubbles to pop for win condition
        if (randomIndex == 0) {
            bubblesToPop += 1;
        }
    }


}
