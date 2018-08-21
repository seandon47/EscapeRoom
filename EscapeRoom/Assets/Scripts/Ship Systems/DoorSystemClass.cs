//
//  DoorSystemClass.cs
//  Class to handle the doors aboard a ship
//  Copyright 2018 Disi Studios LLC
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorSystemClass : ShipSystemClass {

    public List<GameObject> DoorList = new List<GameObject>();
    public DoorMenu Menu;
    public Material LockedIcon;
    public Material UnlockedIcon;
    public Material BrokenLockedIcon;
    public Material BrokenUnlockedIcon;
    public GameObject DoorMenuPanelPrefab;

    public DoorSystemClass()
    {
        systemName = "Doors";
    }

	// Use this for initialization
	void Start ()
    {
		for (int i = 0; i < DoorList.Count; i++)
        {
            Door D = DoorList[i].GetComponent<Door>();
            GameObject NewDoorMenuPanel = Instantiate(DoorMenuPanelPrefab);
            NewDoorMenuPanel.transform.SetParent(Menu.Content, false);

            DoorPanelScript DPS = NewDoorMenuPanel.GetComponent<DoorPanelScript>();
            DPS.Setup("Door " + i.ToString("00"), D);
        }
	}
	
	// Update is called once per frame
	void Update () {

    }

    public override void TimeUpdate(int CurrentTime)
    {
        base.TimeUpdate(CurrentTime);
    }

    public override double PowerRequested()
    {
        return DoorList.Count * 2;
    }

    public override void ChargeFailed()
    {
        foreach(GameObject Door in DoorList)
        {
            // Randomly disable doors.
            // Oh shit, doors need some sort of little door system of their own as a component.
            // FUCK that's more code I have to write.
        }
        base.ChargeFailed();
    }

    public override void ClickEvent()
    {
        //GameController.Instance.MiniMap.GetComponent<MiniMapClass>().ToggleState();
        if(Menu.gameObject.activeInHierarchy)
        {
            Menu.gameObject.SetActive(false);
        }
        else
        {
            Menu.gameObject.SetActive(true);
        }
    }

    public void SetDoorStatusIconScale(float Scale)
    {
        foreach (GameObject GO in DoorList)
        {
            Door door = GO.GetComponent<Door>();
            if (door == null)
                continue;

            DoorStatusIcon DSI = door.StatusIcon.GetComponent<DoorStatusIcon>();
            DSI.transform.localScale = new Vector3(Scale, Scale, Scale);
        }
    }
}
