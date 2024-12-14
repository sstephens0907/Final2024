using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RabbitScript : MonoBehaviour
{
    public GameObject Rabbit;
    public GameObject Caterpillar;
    public GameObject Cat;
    public float respawnInterval;
    public ParticleSystem dust;
    private List<Transform> platformPositions = new List<Transform>();

    void Start()
    {
        // Create list to hold platforms
        GameObject[] platforms = GameObject.FindGameObjectsWithTag("Platform");
        foreach (GameObject platform in platforms)
        {
            platformPositions.Add(platform.transform);
        }

        StartCoroutine(RespawnRabbit());
    }

    IEnumerator RespawnRabbit()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnInterval);

            if (platformPositions.Count > 0)
            {
                // Get Caterpillar's current platform position
                Vector3 caterpillarPosition = Caterpillar.transform.position;
                Vector3 catPosition = Cat.transform.position;

                // Filter out the platform occupied by the Caterpillar
                List<Transform> availablePlatforms = platformPositions.FindAll(platform => 
                    platform.position != caterpillarPosition && platform.position != catPosition);

                if (availablePlatforms.Count > 0)
                {
                    //Play particle system
                    dust.transform.position = Rabbit.transform.position;
                    dust.Emit(3);
                    
                    //let play
                    yield return new WaitForSeconds(dust.main.duration);
                    // Choose a random platform from the available ones
                    Transform randomPlatform = availablePlatforms[Random.Range(0, availablePlatforms.Count)];
                    Rabbit.transform.position = randomPlatform.position;
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Win();
            Debug.Log("Collision detected with: " + other.gameObject.name);
        }
        
    }

    public void Win()
    {
        SceneManager.LoadScene("You Win");
    }
    
}
