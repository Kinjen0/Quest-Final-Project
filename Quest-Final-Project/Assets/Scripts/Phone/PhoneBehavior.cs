using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// So this script will handle the behavior of the phone object. In particular, we want the phone to be "hard" to pickup. 
public class PhoneBehavior : MonoBehaviour
{
    // Counter for the number of current attempts to pickup the phone.
    public int pickupCount;
    // The number of attempts to pick up the object we want to have. 
    public int pickupAttempts;
    public OVRGrabbable grabbable;

    public void Start()
    {
        pickupCount = 0;
        grabbable = GetComponent<OVRGrabbable>();
    }


    // So the point of this will be to manage the dropping of the phone, it will take i which will be the pickup count
    IEnumerator dropPhone(int i)
    { 
        // Multiplier to handle each attempt taking longer to drop it. 
        int dropMult = 2;
        yield return new WaitForSeconds(i * dropMult);
        // After the time limit, make the phone drop
        grabbable.grabbedBy.ForceRelease(grabbable);

    }

    
}
