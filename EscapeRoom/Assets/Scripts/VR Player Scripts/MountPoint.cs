using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountPoint : MonoBehaviour {
    Mountable MountedObject;

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
        Mountable MO = other.gameObject.GetComponent<Mountable>();

        if (MO != null)
        {
            MO.ShowMountCue();
            MO.SetMountPoint(this);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Mountable MO = other.gameObject.GetComponent<Mountable>();

        if (MO != null)
        {
            MO.CancelMountCue();
            MO.SetMountPoint(null);
        }
    }
}
