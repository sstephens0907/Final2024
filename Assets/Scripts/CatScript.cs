using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatScript : MonoBehaviour
{
    public GameObject Caterpillar;
    public GameObject Rabbit;
    public GameObject Alice;
    public GameObject Cat;
    public float respawnInterval;
    public float stunRadius;
    private List <Transform> platformPositions = new List <Transform>();
    // Start is called before the first frame update
    void Start()
    {
        //create list to hold platforms
        GameObject[] platforms = GameObject.FindGameObjectsWithTag("Platform");
        foreach (GameObject platform in platforms)
        {
            platformPositions.Add(platform.transform);
        }
        StartCoroutine(RespawnCat());
    }

    void Update()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, stunRadius);
        foreach (Collider2D hit in hits)
        {
            if (hit.CompareTag("Player"))
            {
                AliceScript alice = hit.GetComponent<AliceScript>();
                if (alice != null)
                {
                    alice.Stun();
                }
            }
        }
    }
    
    IEnumerator RespawnCat()
    {
            while (true)
            {
                yield return new WaitForSeconds(respawnInterval);

                //check for platforms, move Cat to new available platform
                if (platformPositions.Count > 0)
                {
                    // Get Rabbit and Caterpillar current platform position
                    Vector3 rabbitPosition = Rabbit.transform.position;
                    Vector3 caterpillarPosition = Caterpillar.transform.position;
                    Vector3 alicePosition = Alice.transform.position;
                    // Filter out the platform occupied by the Caterpillar
                    List<Transform> availablePlatforms = platformPositions.FindAll(platform => 
                        platform.position != rabbitPosition && platform.position != caterpillarPosition && platform.position != alicePosition);

                    if (availablePlatforms.Count > 0)
                    {
                        // Choose a random platform from the available ones
                        Transform randomPlatform = availablePlatforms[Random.Range(0, availablePlatforms.Count)];
                        Cat.transform.position = randomPlatform.position;
                    }
                }
            }

        
    }
}
