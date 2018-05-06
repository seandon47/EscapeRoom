using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinScript : MonoBehaviour {

    Vector3 RotateVector = new Vector3();
	// Use this for initialization
	void Start () {
        RotateVector = transform.eulerAngles;
	}
	
	// Update is called once per frame
	void Update () {
        RotateVector.y += 1;
        transform.eulerAngles = RotateVector;
	}
}
