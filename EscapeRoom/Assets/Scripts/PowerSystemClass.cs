//
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

    SubSystemClass reactorCore;
    SubSystemClass coolingCoil;
    SubSystemClass energyEqualizer;
    SubSystemClass processingUnit;
    bool canBreakAtRandom;
    double output;

    public PowerSystemClass()
    {
        systemName = "Power System";

        reactorCore = new SubSystemClass(SystemStatusEnum.Malfunctioning, "reactor core");
        coolingCoil = new SubSystemClass(SystemStatusEnum.Functioning, "cooling coil");
        energyEqualizer = new SubSystemClass(SystemStatusEnum.Functioning, "energy equalizer");
        processingUnit = new SubSystemClass(SystemStatusEnum.Functioning, "processing unit");

        //SubSystemNames.Add(reactorCore, "reactor core");
        //SubSystemNames.Add(coolingCoil, "cooling coil");
        //SubSystemNames.Add(energyEqualizer, "energy equalizer");
        //SubSystemNames.Add(processingUnit, "processing unit");
        SubSystemList.AddRange(new SubSystemClass[] { reactorCore, coolingCoil, energyEqualizer, processingUnit });

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

        foreach (SubSystemClass SubSystem in SubSystemList)
        {
            if (SubSystem.Status == SystemStatusEnum.Malfunctioning)
            {
                status = SystemStatusEnum.Malfunctioning;
            }

            if (SubSystem.Status == SystemStatusEnum.Compromised)
            {
                status = SystemStatusEnum.Compromised;
            }

            if (SubSystem.Status == SystemStatusEnum.Offline)
            {
                status = SystemStatusEnum.Offline;
            }
        }

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
}
