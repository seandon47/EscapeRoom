using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttachToHand : MonoBehaviour {

    public GameObject rightHand, watch;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        watch.transform.position = rightHand.transform.position - (rightHand.transform.forward * .3f);
        watch.transform.rotation = new Quaternion(rightHand.transform.rotation.x, rightHand.transform.rotation.y, rightHand.transform.rotation.z, rightHand.transform.rotation.w);
    }
}
