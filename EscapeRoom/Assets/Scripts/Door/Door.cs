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

    GameObject MiniMapLabel;

	// Use this for initialization
	void Start ()
    {
        StatusIcon.transform.eulerAngles = new Vector3(90, 0, 0);

        MiniMapLabel = new GameObject();
        MiniMapLabel.transform.position = StatusIcon.transform.position;
        MiniMapLabel.transform.SetParent(StatusIcon.transform);
        MiniMapLabel.transform.localRotation = new Quaternion(0, 0, 0, 0);
        MiniMapLabel.AddComponent<TextMesh>();
        MiniMapLabel.layer = 13;

        Vector3 pos = new Vector3(0, 0.75f, 0);
        MiniMapLabel.transform.localPosition = pos;

        TextMesh TM = MiniMapLabel.GetComponent<TextMesh>();
        TM.alignment = TextAlignment.Center;
        TM.anchor = TextAnchor.MiddleCenter;        
        TM.text = gameObject.name;
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
