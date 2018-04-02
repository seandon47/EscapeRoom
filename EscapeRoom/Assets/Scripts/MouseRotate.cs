using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseRotate : MonoBehaviour {

    public GameObject HeadObject;
    private Texture2D BG_Green;
    private Texture2D BG_Yellow;
    private Texture2D BG_Red;
    private Texture2D BG_Grey;


    private bool controllingRobot = true;
    private float yaw = 0;
    private float pitch = 0;

	// Use this for initialization
	void Start () {

        Cursor.lockState = CursorLockMode.Locked;
        //Cursor.lockState = CursorLockMode.None;

        //SetTextureColor(BG_Green, Color.green);
        //SetTextureColor(BG_Yellow, Color.yellow);
        //SetTextureColor(BG_Red, Color.red);
        //SetTextureColor(BG_Grey, Color.grey);

    }

    //private void SetTextureColor(Texture2D NovaTexture, Color NovaColor)
    //{
    //    int size = 8;
    //    NovaTexture = new Texture2D(size, size);
    //    for (int i = 0; i < size; i++)
    //    {
    //        for (int j = 0; j < size; j++)
    //        {
    //            NovaTexture.SetPixel(i, j, NovaColor);
    //        }
    //    }
    //    NovaTexture.Apply();
    //}

    private void OnGUI()
    {
        //if (controllingRobot)
        //    return;

        //float W = Screen.width;
        //float Y = 0;
        //Texture2D Background = BG_Green;


        //for (int i = 0; i < GameController.Instance.shipSystems.Count; i++)
        //{
        //    ShipSystemClass System = GameController.Instance.shipSystems[i];
        //    //switch (System.GetStatus())
        //    //{
        //    //    case ShipSystemClass.SystemStatusEnum.Functioning:
        //    //        Background = BG_Green;
        //    //        break;
        //    //    case ShipSystemClass.SystemStatusEnum.Compromised:
        //    //        Background = BG_Yellow;
        //    //        break;
        //    //    case ShipSystemClass.SystemStatusEnum.Malfunctioning:
        //    //        Background = BG_Red;
        //    //        break;
        //    //    case ShipSystemClass.SystemStatusEnum.Offline:
        //    //        Background = BG_Grey;
        //    //        break;
        //    //    default:
        //    //        break;
        //    //}
                        
        //    GUI.Button(new Rect(W - 100, Y, 100, 25), System.GetSystemName());
        //    Y += 50;
        //}
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
