﻿//
//  PowerSystemClass.cs
//  Class to handle the power system on board a ship
//  Copyright 2018 Disi Studios LLC
//
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class PowerSystemClass : ShipSystemClass {

    public GameObject ReactorObject;
    SubSystemClass reactorCore;
    SubSystemClass coolingCoil;
    SubSystemClass energyEqualizer;
    SubSystemClass processingUnit;
    bool canBreakAtRandom;
    double output;

    public PowerSystemClass()
    {
    }

    public double GetOutput()
    {
        return output;
    }

	// Use this for initialization
	void Start ()
    {
        systemName = "Power System";

        reactorCore = new SubSystemClass(SystemStatusEnum.Malfunctioning, "reactor core");
        coolingCoil = new SubSystemClass(SystemStatusEnum.Functioning, "cooling coil");
        energyEqualizer = new SubSystemClass(SystemStatusEnum.Functioning, "energy equalizer");
        processingUnit = new SubSystemClass(SystemStatusEnum.Functioning, "processing unit");
        
        SubSystemList.AddRange(new SubSystemClass[] { reactorCore, coolingCoil, energyEqualizer, processingUnit });

        canBreakAtRandom = false;
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

        bool AllUp = true;
        foreach (SubSystemClass SubSystem in SubSystemList)
        {
            if (SubSystem.Status == SystemStatusEnum.Malfunctioning)
            {
                status = SystemStatusEnum.Malfunctioning;
                AllUp = false;
            }

            if (SubSystem.Status == SystemStatusEnum.Compromised)
            {
                status = SystemStatusEnum.Compromised;
                AllUp = false;
            }

            if (SubSystem.Status == SystemStatusEnum.Offline)
            {
                status = SystemStatusEnum.Offline;
                AllUp = false;
            }
        }

        if (AllUp && status != SystemStatusEnum.Functioning)
        {
            status = SystemStatusEnum.Functioning;
        }

        base.TimeUpdate(CurrentTime);
    }

    public override double PowerRequested()
    {
        // So the thing that makes power needs some power.
        // It's got a computer system that does stuff, right?
        if (status == SystemStatusEnum.Functioning)
            return 10;
        else
            return 1;
    }

    public override void ChargeFailed()
    {
        // This is an interesting situation.
        // What to do if the power system has no power?
        base.ChargeFailed();
    }

    public override string GetRepairInstructions()
    {
        StringBuilder SB = new StringBuilder();
        if (status == SystemStatusEnum.Functioning)
        {
            return "System is stable.";
        }
        else
        {
            foreach (SubSystemClass SubSystem in SubSystemList)
            {
                SB.Append(SubSystem.Name + " " + GetStatusString(SubSystem.Status));
                if (SubSystem.Status != SystemStatusEnum.Functioning)
                {
                    if (SubSystem.Status == SystemStatusEnum.Offline)
                    {
                        SB.Append(" bring system online.\n");
                    }
                    else
                    {
                        SB.Append(" replace " + SubSystem.Name + ".\n");
                    }
                }
                else
                {
                    SB.Append("\n");
                }
            }
        }
        return SB.ToString();
    }

    double CalculateOutput()
    {
        // Do something with subsystems and their status to calculate the output
        // This way if the output drops we can make lights flicker, or doors jam
        // that sort of thing.
        if (status == SystemStatusEnum.Functioning)
        {
            return 1000;
        }
        else
        {
            return 0;
        }
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
            if (SubSystemList[i].Status != SystemStatusEnum.Functioning)
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

    public SubSystemClass GetSubsystem(string SName)
    {
        return SubSystemList.Find(S => S.Name == SName);
    }
}
