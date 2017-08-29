using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRotate : MonoBehaviour {

    private float yaw = 0;
    private float pitch = 0;
    public GameObject HeadObject;

	// Use this for initialization
	void Start () {

        Cursor.lockState = CursorLockMode.Locked;
        //Cursor.lockState = CursorLockMode.None;
    }
	
	// Update is called once per frame
	void Update () {
        yaw += 2 * Input.GetAxis("Mouse X");
        pitch += 2 * -1 * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0);
        
        HeadObject.transform.eulerAngles = new Vector3(0, yaw, 0);
    }
}
