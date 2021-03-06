﻿//
//  LightingSystemClass.cs
//  Class to handle the lights aboard a ship
//  Copyright 2018 Disi Studios LLC
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightingSystemClass : ShipSystemClass {

    public GameObject LightMenuPanelPrefab;
    public Text PowerDraw;
    /// <summary>
    /// Element 1 Left side
    /// Element 2 Center
    /// Element 3 Top Left
    /// Element 4 Top Right
    /// </summary>
    public CircuitClass LightingCircuits;
    public Material DimGreen;
    public Material BrightGreen;
    public Material DimRed;
    public Material BrightRed;

    public LightingSystemClass()
    {
        systemName = "Lighting";
    }

	// Use this for initialization
	void Start () {
		foreach (LightList LL in LightingCircuits.AllMyCircuits)
        {
            LL.Setup();
            foreach (LightClass LC in LL.Lights)
            {
                // Get the child light point and set it!
                Transform t = LC.gameObject.transform.GetChild(0);
                Light L = t.GetComponent<Light>();
                LC.PointLight = L;
                LC.LoadAllValues();

                GameObject NewLightPanel = Instantiate(LightMenuPanelPrefab);
                NewLightPanel.transform.SetParent(UiMenu.Content, false);

                LightPanelScript LPS = NewLightPanel.GetComponent<LightPanelScript>();
                LPS.Setup("Oh shit", LightingCircuits.AllMyCircuits.IndexOf(LL), LL.Lights.IndexOf(LC), LC);

                LC.SetLightColor(Color.red);
            }
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            UiMenu.ToggleMenu();
        }
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
        double powerNeeded = 10;
        PowerDraw.text = $"{powerNeeded} kw";
        return powerNeeded;
    }

    public override void ChargeFailed()
    {
        base.ChargeFailed();
    }

    public override void ClickEvent()
    {
        UiMenu.ToggleMenu();
    }

    protected override void StatusChanged()
    {
        foreach (LightList LL in LightingCircuits.AllMyCircuits)
        {
            foreach (LightClass LC in LL.Lights)
            {
                switch (status)
                {
                    case SystemStatusEnum.Functioning:
                        LC.SetState(LightClass.LightState.ON);
                        break;
                    case SystemStatusEnum.Compromised:
                        break;
                    case SystemStatusEnum.Malfunctioning:
                        LC.SetState(LightClass.LightState.OFF);
                        break;
                    case SystemStatusEnum.Offline:
                        LC.SetState(LightClass.LightState.OFF);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
