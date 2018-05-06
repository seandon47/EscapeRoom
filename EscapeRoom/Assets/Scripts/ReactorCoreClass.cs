using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactorCoreClass : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnPickUp()
    {
        GameController.Instance.PowerSystem.GetSubsystem("reactor core").Status = ShipSystemClass.SystemStatusEnum.Offline;
    }
}
