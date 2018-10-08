//
//  LightingSystemClass.cs
//  Class to handle the lights aboard a ship
//  Copyright 2018 Disi Studios LLC
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingSystemClass : ShipSystemClass {

    public LightsMenu Menu;
    public GameObject LightMenuPanelPrefab;
    /// <summary>
    /// Element 1 Left side
    /// Element 2 Center
    /// Element 3 Top Left
    /// Element 4 Top Right
    /// </summary>
    public CircuitClass LightingCircuits;

    public LightingSystemClass()
    {
        systemName = "Lighting";
    }

	// Use this for initialization
	void Start () {
		foreach (LightList LL in LightingCircuits.AllMyCircuits)
        {
            foreach (LightClass LC in LL.Lights)
            {
                // Get the child light point and set it!
                Transform t = LC.gameObject.transform.GetChild(0);
                Light L = t.GetComponent<Light>();
                LC.PointLight = L;
                LC.LoadAllValues();

                GameObject NewLightPanel = Instantiate(LightMenuPanelPrefab);
                NewLightPanel.transform.SetParent(Menu.Content, false);

                LightPanelScript LPS = NewLightPanel.GetComponent<LightPanelScript>();
                LPS.Setup("Oh shit", LightingCircuits.AllMyCircuits.IndexOf(LL), LL.Lights.IndexOf(LC), LC);
            }
        }
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

    public override void ClickEvent()
    {
        if(Menu.gameObject.activeInHierarchy)
        {
            Menu.gameObject.SetActive(false);
        }
        else
        {
            Menu.gameObject.SetActive(true);
        }
    }
}
