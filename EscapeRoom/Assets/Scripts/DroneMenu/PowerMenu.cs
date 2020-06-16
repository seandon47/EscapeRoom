//
//  PowerMenu.cs
//  Class to handle the doors aboard a ship
//  Copyright 2018 Disi Studios LLC
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerMenu : BaseSystemMenu
{
    public GameObject SubsystemPanelPrefab;

    // Use this for initialization
    protected override void Start () {
        base.Start();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            base.CloseAllSystemMenus();
        }
    }

    public override void AddSubsystemToMenu(SubSystemClass SubSystem)
    {
        GameObject NewSubsystemPanel = Instantiate(SubsystemPanelPrefab);
        NewSubsystemPanel.transform.SetParent(Content, false);

        SubsystemPanel SP = NewSubsystemPanel.GetComponent<SubsystemPanel>();
        SP.Setup(SubSystem);
    }
}
