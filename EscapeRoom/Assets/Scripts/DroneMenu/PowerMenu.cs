//
//  PowerMenu.cs
//  Class to handle the doors aboard a ship
//  Copyright 2018 Disi Studios LLC
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerMenu : BaseMenu
{
    // Reference to the content of the scrollable window
    public Transform Content;
    public GameObject SubsystemPanelPrefab;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddSubsystemToMenu(SubSystemClass SubSystem)
    {
        GameObject NewSubsystemPanel = Instantiate(SubsystemPanelPrefab);
        NewSubsystemPanel.transform.SetParent(Content, false);

        SubsystemPanel SP = NewSubsystemPanel.GetComponent<SubsystemPanel>();
        SP.Setup(SubSystem);
    }
}
