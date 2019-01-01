using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakerButtonPress : MonoBehaviour {

    public delegate void ButtonPressedEvent();
    public event ButtonPressedEvent Pressed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (Pressed != null)
            Pressed.Invoke();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (Pressed != null)
            Pressed.Invoke();
    }
}
