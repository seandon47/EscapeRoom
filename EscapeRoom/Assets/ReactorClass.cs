using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReactorClass : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        ReactorCoreClass RCC = collision.gameObject.GetComponent<ReactorCoreClass>();
        if (RCC != null)
        {
            SubSystemClass SSC = GameController.Instance.PowerSystem.GetSubsystem("reactor core");
            if (SSC != null && SSC.Status != ShipSystemClass.SystemStatusEnum.Functioning)
            {
                RCC.transform.position = transform.position;
                SSC.Status = ShipSystemClass.SystemStatusEnum.Functioning;
            }
        }
    }
}
