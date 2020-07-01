using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControlPanel : DroneInteractable {
    public Door doorInstance;
    	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Activated()
    {
        base.Activated();
        // Play fixed it noise

        // Play fixed it animation?
        // At least show player that they fixed it
        // Maybe tell them in the console?

        if (doorInstance != null && doorInstance.IsBroken)
        {
            doorInstance.FixDoor();
        }
    }
}
