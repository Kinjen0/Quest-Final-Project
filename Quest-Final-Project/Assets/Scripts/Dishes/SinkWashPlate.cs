using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinkWashPlate : MonoBehaviour
{
    // This script is primarally meant to allow us to mark plates as having been washed
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Plate")
        {
            Plate plate = other.GetComponent<Plate>();
            plate.plateWashed = true;
        }
    }
}
