//
//  LifeSupportClass.cs
//  Class to handle the life support aboard a ship
//  Copyright 2018 Disi Studios LLC
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSupportClass : ShipSystemClass {

    public int NumberOfRooms;

    public LifeSupportClass()
    {
        systemName = "Life Support";
        NumberOfRooms = 10;
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
        return NumberOfRooms * 100;
    }

    public override void ChargeFailed()
    {
        base.ChargeFailed();
    }
}
