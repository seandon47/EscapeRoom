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
    public Material LockedIcon;
    public Material UnlockedIcon;
    public Material BrokenLockedIcon;
    public Material BrokenUnlockedIcon;
    public GameObject DoorMenuPanelPrefab;
    public Text PowerDraw;

    public DoorSystemClass()
    {
        systemName = "Doors";
    }

	// Use this for initialization
	void Start ()
    {
        // Code to load EVERY door in the scene
        // But they come up in no particular order... JPR

        //DoorList.Clear();
        //Door[] Doors = FindObjectsOfType<Door>();

        //foreach (Door D in Doors)
        //{
        //    DoorList.Add(D.gameObject);
        //}

		for (int i = 0; i < DoorList.Count; i++)
        {
            Door D = DoorList[i].GetComponent<Door>();
            GameObject NewDoorMenuPanel = Instantiate(DoorMenuPanelPrefab);
            NewDoorMenuPanel.transform.SetParent(UiMenu.Content, false);

            DoorPanelScript DPS = NewDoorMenuPanel.GetComponent<DoorPanelScript>();
            DPS.Setup("Door " + (i + 1).ToString("00"), D);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            UiMenu.ToggleMenu();
        }
    }

    public override void TimeUpdate(int CurrentTime)
    {
        base.TimeUpdate(CurrentTime);
    }

    public override double PowerRequested()
    {
        double powerNeeded = DoorList.Count * 2;
        PowerDraw.text = $"{powerNeeded} kw";

        return powerNeeded;
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
        UiMenu.ToggleMenu();
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
