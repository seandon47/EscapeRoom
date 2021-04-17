//
//  LifeSupportClass.cs
//  Class to handle the life support aboard a ship
//  Copyright 2018 Disi Studios LLC
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeSupportClass : ShipSystemClass {

    public int NumberOfRooms;   // Obvious
    public float Oxygen;        // Percent Needed
    public Text PowerDraw;

    SubSystemClass oxygenGenerator;
    SubSystemClass ventilationFan;
    SubSystemClass radiationFilter;

    public LifeSupportClass()
    {
    }

	// Use this for initialization
	void Start () {
        systemName = "Life Support";
        NumberOfRooms = 5;
        Oxygen = 100;

        oxygenGenerator = new SubSystemClass(SystemStatusEnum.Functioning, "Oxygen Generator");
        oxygenGenerator.SetRepairInstructions("Replace electrolysis module");

        ventilationFan = new SubSystemClass(SystemStatusEnum.Functioning, "Ventilation Fan");
        ventilationFan.SetRepairInstructions("Replace fan");

        radiationFilter = new SubSystemClass(SystemStatusEnum.Functioning, "Radiation Filter");
        radiationFilter.SetRepairInstructions("Recalibrate radiation sensor array");

        SubSystemList.AddRange(new SubSystemClass[] { oxygenGenerator, ventilationFan, radiationFilter });

        foreach (SubSystemClass SSC in SubSystemList)
        {
            UiMenu.AddSubsystemToMenu(SSC);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            UiMenu.ToggleMenu();
        }
    }

    public override void ClickEvent()
    {
        UiMenu.ToggleMenu();
    }

    public override void TimeUpdate(int CurrentTime)
    {
        base.TimeUpdate(CurrentTime);
        ManageOxygen();
    }

    public override double PowerRequested()
    {
        double powerNeeded = NumberOfRooms * 2;
        PowerDraw.text = $"{powerNeeded} kw";
        
        return powerNeeded;
    }

    public override void ChargeFailed()
    {
        Oxygen = Oxygen - 0.5f;
        if (Oxygen < 0)
        {
            Oxygen = 0;
        }
    }

    void ManageOxygen()
    {
        if (oxygenGenerator.Status == SystemStatusEnum.Functioning &&
            ventilationFan.Status == SystemStatusEnum.Functioning)
        {
            Oxygen += 0.25f;
            if (Oxygen > 100)
            {
                Oxygen = 100;
            }
        }
        else
        {
            Oxygen -= 0.5f;
            if (Oxygen < 0)
            {
                Oxygen = 0;
            }
        }
    }
}
