//
//  DoorStatusIcon.cs
//  Class to handle the functionality of the status icon of a door
//  Copyright 2018 Disi Studios LLC
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorStatusIcon : MonoBehaviour {

    public GameObject Door;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Clicked()
    {
        Door D = Door.GetComponent<Door>();
        if (D != null)
        {
            D.IsLocked = !D.IsLocked;
            if (D.IsLocked)
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
}
