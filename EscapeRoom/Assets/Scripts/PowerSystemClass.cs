//
//  PowerSystemClass.cs
//  Class to handle the power system on board a ship
//  Copyright 2018 Disi Studios LLC
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerSystemClass : ShipSystemClass {

    SystemStatusEnum reactorCore;
    SystemStatusEnum coolingCoil;
    SystemStatusEnum energyEqualizer;
    SystemStatusEnum processingUnit;
    bool canBreakAtRandom;
    double output;

    public PowerSystemClass()
    {
        systemName = "Power System";

        reactorCore = SystemStatusEnum.Functioning;
        coolingCoil = SystemStatusEnum.Functioning;
        energyEqualizer = SystemStatusEnum.Functioning;
        processingUnit = SystemStatusEnum.Functioning;

        SubSystemList.AddRange(new SystemStatusEnum[] { reactorCore, coolingCoil, energyEqualizer, processingUnit});

        canBreakAtRandom = false;
    }

    public double GetOutput()
    {
        return output;
    }

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void TimeUpdate(int CurrentTime)
    {
        if(canBreakAtRandom)
        {
            BreakAtRandom();
        }

        output = CalculateOutput();
        base.TimeUpdate(CurrentTime);
    }

    public override double PowerRequested()
    {
        // So the thing that makes power needs some power.
        // It's got a computer system that does stuff, right?
        return 100;
    }

    public override void ChargeFailed()
    {
        base.ChargeFailed();
    }

    public override string GetRepairInstructions()
    {
        return "System is stable";
    }

    double CalculateOutput()
    {
        // Do something with subsystems and their status to calculate the output
        // This way if the output drops we can make lights flicker, or doors jam
        // that sort of thing.
        return 1000;
    }

    public bool UseCharge(double Usage)
    {
        output -= Usage;
        if (output <= 0)
        {
            output = 0;
            return false;
        }
        return true;
    }

    public bool SystemIsFunctional()
    {
        for (int i = 0; i < SubSystemList.Count; i++)
        {
            if (SubSystemList[i] != SystemStatusEnum.Functioning)
                return false;
        }
        return true;
    }

    void BreakAtRandom()
    {
        for (int i = 0; i < SubSystemList.Count; i++)
        {
            float R = Random.Range(0, 1);
            if (R < 0.05)
            {
                // 5% chance something breaks every second? too often?
                // is this too high? We can run with it on sometime and check.
            }
        }
    }
}
