using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSound : MonoBehaviour {

    public void OnTriggerStay(Collider other)
    {
        // if staying in collider

        // press E
        if (Input.GetKeyDown(KeyCode.E))
        {
            // change variable to true
            if (SoundDynamic.IsPlayerTriggered == false)
                SoundDynamic.IsPlayerTriggered = true;

            else
                SoundDynamic.IsPlayerTriggered = false;
        }
        
    }

    
}
