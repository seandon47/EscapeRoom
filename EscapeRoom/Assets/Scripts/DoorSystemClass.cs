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
        return DoorList.Count * 10;
    }

    public override void ChargeFailed()
    {
        base.ChargeFailed();
    }
}
