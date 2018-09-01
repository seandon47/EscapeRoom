//
//  PowerMenu.cs
//  Class to handle the doors aboard a ship
//  Copyright 2018 Disi Studios LLC
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerMenu : MonoBehaviour
{
    // Reference to the content of the scrollable window
    // All of the door panels will be put in there.
    public Transform Content;
    public GameObject PowerSubsystemPanelPrefab;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddSubsystemToMenu(SubSystemClass SubSystem)
    {
        GameObject NewPowerSubsystemPanel = Instantiate(PowerSubsystemPanelPrefab);
        NewPowerSubsystemPanel.transform.SetParent(Content, false);

        PowerSubsystemPanel PSP = NewPowerSubsystemPanel.GetComponent<PowerSubsystemPanel>();
        PSP.Setup(SubSystem);
    }
}
