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

        SubSystemClass SSC = GameController.Instance.PowerSystem.GetSubsystem("reactor core");
        
        collision.gameObject.transform.SetParent(transform);
        collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        collision.gameObject.transform.rotation = new Quaternion(90, 0, 0, 0);
        collision.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);

        if (RCC != null &&
            SSC != null && 
            SSC.Status != ShipSystemClass.SystemStatusEnum.Functioning)
        { 
            SSC.Status = ShipSystemClass.SystemStatusEnum.Functioning;
        }

        if (RCC == null)
        {
            // BAD SHIT GOES DOWN
        }
        
    }
}
