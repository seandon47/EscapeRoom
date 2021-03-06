﻿//
//  BatterySystemClass.cs
//  Class to handle the functionality of the batteries aboard a ship
//  Copyright 2018 Disi Studios LLC
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatterySystemClass : ShipSystemClass {

    double charge;
    double maxCharge;
    SystemStatusEnum Battery1;
    SystemStatusEnum Battery2;
    SystemStatusEnum Battery3;
    SystemStatusEnum Battery4;


    public BatterySystemClass()
    {
    }

	// Use this for initialization
	void Start () {
        systemName = "Batteries";
        maxCharge = 100000;
        charge = maxCharge;		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnGUI()
    {
        //GUI.TextArea(new Rect(100, 100, 100, 100), charge.ToString());
    }

    public override void TimeUpdate(int CurrentTime)
    {
        base.TimeUpdate(CurrentTime);
    }

    public override double PowerRequested()
    {
        // Batteries don't need power
        return base.PowerRequested();
    }

    public double GetCharge()
    {
        return charge;
    }

    /// <summary>
    /// Adds to the battery systems charge
    /// </summary>
    /// <param name="IncomingPower">The amount of charge going into the battery system</param>
    public void ApplyCharge(double IncomingPower)
    {
        charge += IncomingPower;
        if (charge > maxCharge)
        {
            charge = maxCharge;
        }
    }

    /// <summary>
    /// Uses some of the battery systems power
    /// </summary>
    /// <param name="OutgoingPower">How much of the charge you need to use</param>
    /// <returns>true if the system had enough power, false otherwise</returns>
    public bool UseCharge(double OutgoingPower)
    {
        charge -= OutgoingPower;
        if (charge < 0)
        {
            charge = 0;
            return false;
        }
        return true;
    }
}
