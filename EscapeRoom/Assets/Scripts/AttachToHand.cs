using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachToHand : MonoBehaviour {

    public GameObject hand, attachedObject;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (attachedObject.name == "Watch")
            attachedObject.transform.position = hand.transform.position - (hand.transform.forward * .3f);
        else
            attachedObject.transform.position = hand.transform.position;
            attachedObject.transform.rotation = new Quaternion(hand.transform.rotation.x, hand.transform.rotation.y, hand.transform.rotation.z, hand.transform.rotation.w);
    }
}
