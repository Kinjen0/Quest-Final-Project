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



    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Trash")
        {
            StartCoroutine(DestroyTrash(other.gameObject));
        }
        if(trashCount > 3)
        {
            gameState.markTaskComplete(0);
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
