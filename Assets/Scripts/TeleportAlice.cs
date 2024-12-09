using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportAlice : MonoBehaviour
{
    public Vector2 targetPosition;
	public float delay;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(TeleportAfterDelay(collision.transform));
        }
    }
	private IEnumerator TeleportAfterDelay(Transform playerTransform)
		{
			yield return new WaitForSeconds(delay);
			playerTransform.position = targetPosition;
	}

}
