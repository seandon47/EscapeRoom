//
//  LifeSupportClass.cs
//  Class to handle the life support aboard a ship
//  Copyright 2018 Disi Studios LLC
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSupportClass : ShipSystemClass {

    public int NumberOfRooms;   // Obvious
    public float Oxygen;        // Percent Needed

    public LifeSupportClass()
    {
    }

	// Use this for initialization
	void Start () {
        systemName = "Life Support";
        NumberOfRooms = 5;
        Oxygen = 100;
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
        return NumberOfRooms * 2;
    }

    public override void ChargeFailed()
    {
        Oxygen = Oxygen - 0.5f;
    }
}
