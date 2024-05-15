using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashManager : MonoBehaviour
{
    // This script will be placed inside a trash can, in which the player will be prompted to toss trash and other reffuse in order to make their living environment better

    // It should be simple
    public GameState gameState;
    public int trashCount = 0;

    public void Update()
    {
        if (trashCount >= 8)
        {
            gameState.markTaskComplete(0);
        }
    }


    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Trash")
        {
            Trash trash = other.GetComponent<Trash>();
            if (!trash.isTrashed)
            {
                trash.isTrashed = true;
                StartCoroutine(DestroyTrash(other.gameObject));
            }
        }

    }

    // Script to destroy the trash object after 3 seconds, To prevent the trash can from being overfilled. 
    IEnumerator DestroyTrash(GameObject gameObject)
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject.gameObject);
        trashCount++;
    }
}
