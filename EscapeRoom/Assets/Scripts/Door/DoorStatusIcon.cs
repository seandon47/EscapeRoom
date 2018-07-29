//
//  DoorStatusIcon.cs
//  Class to handle the functionality of the status icon of a door
//  Copyright 2018 Disi Studios LLC
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorStatusIcon : MonoBehaviour {

    public GameObject DoorObject;
    Door doorInstance;
    Renderer rend;

	// Use this for initialization
	void Start () {
        rend = GetComponent<Renderer>();
        doorInstance = DoorObject.GetComponent<Door>();
        if (doorInstance.IsBroken)
        {
            if (doorInstance.IsLocked)
            {
                GetComponent<MeshRenderer>().material = GameController.Instance.DoorSystem.BrokenLockedIcon;
            }
            else
            {
                GetComponent<MeshRenderer>().material = GameController.Instance.DoorSystem.BrokenUnlockedIcon;
            }
        }
        else
        {
            if (doorInstance.IsLocked)
            {
                GetComponent<MeshRenderer>().material = GameController.Instance.DoorSystem.LockedIcon;
            }
            else
            {
                GetComponent<MeshRenderer>().material = GameController.Instance.DoorSystem.UnlockedIcon;
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
	}

    public void Clicked()
    {
        if (doorInstance.IsBroken)
        {
            // Make failure noise
            return;
        }

        doorInstance.IsLocked = !doorInstance.IsLocked;
        if (doorInstance.IsLocked)
        {
            // Set quad material to locked materal
            GetComponent<MeshRenderer>().material = GameController.Instance.DoorSystem.LockedIcon;
        }
        else
        {
            // Set quad material to unlocked materal
            GetComponent<MeshRenderer>().material = GameController.Instance.DoorSystem.UnlockedIcon;
        }
    }
}
