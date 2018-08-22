using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorPanelScript : MonoBehaviour {

    Door MyDoor;
    public Text NameLabel;
    public Text StatusLabel;
    public Button LockButton;
    public Button OpenButton;

	// Use this for initialization
	void Start ()
    {
        LockButton.onClick.AddListener(LockButtonClick);
        OpenButton.onClick.AddListener(OpenButtonClick);
    }

    public void Setup(string Name, Door InDoor)
    {
        MyDoor = InDoor;
        NameLabel.text = MyDoor.gameObject.name;
        StatusLabel.text = MyDoor.IsBroken ? "Malfunctioning" : "Functioning";
        LockButton.GetComponentInChildren<Text>().text = MyDoor.IsLocked ? "Locked" : "Unlocked";
        OpenButton.GetComponentInChildren<Text>().text = MyDoor.IsOpen ? "Open" : "Closed";
    }

    public void LockButtonClick()
    {
        if (MyDoor.IsBroken)
            return;

        if (MyDoor.IsLocked)
        {
            MyDoor.IsLocked = false;
        }
        else
        {
            MyDoor.IsLocked = true;
        }
        LockButton.GetComponentInChildren<Text>().text = MyDoor.IsLocked ? "Locked" : "Unlocked";
    }

    public void OpenButtonClick()
    {
        if (MyDoor.IsBroken)
            return;

        // Run animation coroutine
        MyDoor.ToggleDoor();
        if (MyDoor.IsOpen)
        {
            MyDoor.IsOpen = false;
        }
        else
        {
            MyDoor.IsOpen = true;
        }
        OpenButton.GetComponentInChildren<Text>().text = MyDoor.IsOpen ? "Open" : "Closed";
    }
}
