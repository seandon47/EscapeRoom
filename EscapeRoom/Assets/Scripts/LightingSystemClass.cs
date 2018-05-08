//
//  LightingSystemClass.cs
//  Class to handle the lights aboard a ship
//  Copyright 2018 Disi Studios LLC
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingSystemClass : ShipSystemClass {

    public List<GameObject> LightList = new List<GameObject>();

    public LightingSystemClass()
    {
        systemName = "Lighting";
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
        // Do something cute in the future.
        // Right now, we'll just make some shit up
        // return LightList.Count * 100;
        return 10;
    }

    public override void ChargeFailed()
    {
        base.ChargeFailed();
    }
}
