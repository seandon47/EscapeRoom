using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountPoint : MonoBehaviour {
    MountableObject MountedObject;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        MountableObject MO = other.gameObject.GetComponent<MountableObject>();

        if (MO != null)
        {
            MO.ShowMountCue();
            MO.SetMountPoint(this);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        MountableObject MO = other.gameObject.GetComponent<MountableObject>();

        if (MO != null)
        {
            MO.CancelMountCue();
            MO.SetMountPoint(null);
        }
    }
}
