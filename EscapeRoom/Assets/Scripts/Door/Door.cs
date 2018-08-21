using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public GameObject OpenSwitch;
    public GameObject StatusIcon;
    public bool IsBroken;
    public bool IsLocked;
    public bool IsOpen;
    public bool isOpenAtStart = false;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void FixDoor()
    {
        if (IsBroken)
        {
            IsBroken = false;
            StatusIcon.GetComponent<DoorStatusIcon>().UpdateIcon();
        }
    }

    public void ToggleDoor()
    {
        OpenSwitch.GetComponent<OpenDoorButton>().ToggleDoor();
    }
}
