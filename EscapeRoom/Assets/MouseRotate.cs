using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRotate : MonoBehaviour {

    public GameObject HeadObject;

    private bool controllingRobot = true;
    private float yaw = 0;
    private float pitch = 0;

	// Use this for initialization
	void Start () {

        Cursor.lockState = CursorLockMode.Locked;
        //Cursor.lockState = CursorLockMode.None;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (controllingRobot)
            {
                controllingRobot = false;
                Cursor.lockState = CursorLockMode.None;
            }
            else
            {
                controllingRobot = true;
                Cursor.lockState = CursorLockMode.Locked;
            }
        }

        if (controllingRobot)
        {
            yaw += 2 * Input.GetAxis("Mouse X");
            pitch += 2 * -1 * Input.GetAxis("Mouse Y");

            transform.eulerAngles = new Vector3(pitch, yaw, 0);
            HeadObject.transform.eulerAngles = new Vector3(0, yaw, 0);
        }
    }
}
