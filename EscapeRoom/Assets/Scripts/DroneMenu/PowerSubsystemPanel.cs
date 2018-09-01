//
//  PowerSubsystemPanel.cs
//  Class to handle the doors aboard a ship
//  Copyright 2018 Disi Studios LLC
//
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerSubsystemPanel : MonoBehaviour {
    public Image Picture;
    public Text Name;
    public Text Status;
    public Text Instructions;
    SubSystemClass SubSystem;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GameUpdate()
    {
        UpdateInstructions();
    }

    public void Setup(SubSystemClass System)
    {
        SubSystem = System;
        Name.text = SubSystem.Name;
        Status.text = ShipSystemClass.GetStatusString(SubSystem.Status);
        UpdateInstructions();
    }

    void UpdateInstructions()
    {
        if (SubSystem.Status != ShipSystemClass.SystemStatusEnum.Functioning)
        {
            if (!Instructions.gameObject.activeInHierarchy)
                Instructions.gameObject.SetActive(true);
        }
        else
        {
            if (Instructions.gameObject.activeInHierarchy)
                Instructions.gameObject.SetActive(false);
        }
    }
}
