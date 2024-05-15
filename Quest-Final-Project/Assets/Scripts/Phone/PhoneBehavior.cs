using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// So this script will handle the behavior of the phone object. In particular, we want the phone to be "hard" to pickup. 
public class PhoneBehavior : MonoBehaviour
{
    // Counter for the number of current attempts to pickup the phone.
    public int pickupCount;
    // The number of attempts to pick up the object we want to have. Can be set in inspector
    public int NumberOfPickupAttempts;

    public OVRGrabbable grabbable;

    // GameState manager to allow us to mark the task as completed. Set in inspector. 
    public GameState gameState;

    // AudioSource for the ringtone
    private AudioSource ringtone; 

    public bool isDropping;

    // Boolean to let me test the completion of the task 
    public bool testDone = false;

    // Bool to let me keep track of if the song has been played
    private bool hasPlayed = false;

    public void Start()
    {
        pickupCount = 0;
        grabbable = GetComponent<OVRGrabbable>();
        isDropping = false;
        ringtone = GetComponent<AudioSource>();
    }

    public void Update()
    {
        if(grabbable.isGrabbed && !isDropping)
        {
            if (pickupCount < NumberOfPickupAttempts)
            {
                isDropping = true;
                pickupCount++;
                startDropPhone();
            }
            else
            {
                PlayPhoneSound();
                gameState.markTaskComplete(1);
            }
            
        }
        if (testDone)
        {
            gameState.markTaskComplete(1);
        }


    }

    // I got some help from this source to manage only having a single coroutine at once
    //https://forum.unity.com/threads/ensure-that-theres-only-one-instance-of-a-coroutine-per-gameobject.545947/
    // and later https://docs.unity3d.com/ScriptReference/MonoBehaviour.StopAllCoroutines.html#:~:text=However%2C%20StopAllCoroutines%20is%20used%20to,on%20a%20script%20are%20stopped.

    public void startDropPhone()
    {
        StopAllCoroutines();
        StartCoroutine(dropPhone(pickupCount + 1));

    }



    // So the point of this will be to manage the dropping of the phone, it will take i which will be the pickup count
    IEnumerator dropPhone(int i)
    { 
        // (REMOVED) Multiplier to handle each attempt taking longer to drop it. 
        //int dropMult = 2;
        yield return new WaitForSeconds(i);
        // After the time limit, make the phone drop
        // Have a check to make sure that the phone is still being grabbed
        if (grabbable.isGrabbed)
        {
            grabbable.grabbedBy.ForceRelease(grabbable);

        }
        isDropping = false;

    }

    // Playing the phone sound exactly one time
    private void PlayPhoneSound()
    {
        if(!hasPlayed)
        {
            hasPlayed = true;
            ringtone.Play();
        }
    }

    
}
