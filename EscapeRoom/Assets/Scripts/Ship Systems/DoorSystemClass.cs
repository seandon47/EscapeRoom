//
//  DoorSystemClass.cs
//  Class to handle the doors aboard a ship
//  Copyright 2018 Disi Studios LLC
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSystemClass : ShipSystemClass {

    public List<GameObject> DoorList = new List<GameObject>();
    public Material LockedIcon;
    public Material UnlockedIcon;
    public Material BrokenLockedIcon;
    public Material BrokenUnlockedIcon;

    public DoorSystemClass()
    {
        systemName = "Doors";
    }

	// Use this for initialization
	void Start () {
		
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
        GameController.Instance.MiniMap.GetComponent<MiniMapClass>().ToggleState();
    }
}
