using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubSystemClass {

    public ShipSystemClass.SystemStatusEnum Status;
    public string Name;
    string RepairInstructions;

    public SubSystemClass(ShipSystemClass.SystemStatusEnum StartingStatus, string NovaName)
    {
        Status = StartingStatus;
        Name = NovaName;
    }

    public void SetRepairInstructions(string Instructions)
    {
        RepairInstructions = Instructions;
    }

    public string GetRepairInstructions()
    {
        return RepairInstructions;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
