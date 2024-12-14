using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaterpillarScript : MonoBehaviour
{
    public GameObject Caterpillar;
    public GameObject Rabbit;
    public GameObject Cat;
	public float respawnInterval;
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
		StartCoroutine(RespawnCaterpillar());
    }

	IEnumerator RespawnCaterpillar()
    {
    while (true)
    {
        yield return new WaitForSeconds(respawnInterval);

        //check for platforms, move Caterpillar to new available platform
        if (platformPositions.Count > 0)
        {
	        // Get Rabbit's current platform position
	        Vector3 rabbitPosition = Rabbit.transform.position;
	        Vector3 catPosition = Cat.transform.position;

	        // Filter out the platform occupied by the Rabbit
	        List<Transform> availablePlatforms = platformPositions.FindAll(platform => 
		        platform.position != rabbitPosition && platform.position != catPosition);

	        if (availablePlatforms.Count > 0)
	        {
		        // Choose a random platform from the available ones
		        Transform randomPlatform = availablePlatforms[Random.Range(0, availablePlatforms.Count)];
		        Caterpillar.transform.position = randomPlatform.position;
	        }
        }
    }

	}
}