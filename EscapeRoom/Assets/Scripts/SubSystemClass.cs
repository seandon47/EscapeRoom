using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubSystemClass {

    public ShipSystemClass.SystemStatusEnum Status;
    public string Name;

    public SubSystemClass(ShipSystemClass.SystemStatusEnum StartingStatus, string NovaName)
    {
        Status = StartingStatus;
        Name = NovaName;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
