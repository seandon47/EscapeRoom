using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class ReactorClass : MonoBehaviour {

    public GameObject ParticleSystemObject;
    public GameObject LightObject;
    bool hasObject;

	// Use this for initialization
	void Start () {
        hasObject = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        ReactorCoreClass RCC = collision.gameObject.GetComponent<ReactorCoreClass>();
        PlayerController PC = collision.gameObject.GetComponent<PlayerController>();

        SubSystemClass SSC = GameController.Instance.PowerSystem.GetSubsystem("Reactor Core");


        if (!hasObject && PC == null)
        {
            hasObject = true;
            collision.gameObject.transform.SetParent(transform);
            collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            collision.gameObject.transform.rotation = new Quaternion(90, 0, 0, 0);
            collision.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z);
        }

        if (RCC != null &&
            SSC != null && 
            SSC.Status != ShipSystemClass.SystemStatusEnum.Functioning)
        { 
            SSC.Status = ShipSystemClass.SystemStatusEnum.Functioning;
            ParticleSystemObject.SetActive(true);
            LightObject.SetActive(true);
        }

        if (RCC == null)
        {
            // BAD SHIT GOES DOWN
            ParticleSystemObject.SetActive(false);
            LightObject.SetActive(false);
        }
        
    }

    private void OnTransformChildrenChanged()
    {
        if (transform.GetChild(0).gameObject.GetComponent<Throwable>() == null)
        {
            hasObject = false;
        }

        if( transform.GetChild(0).gameObject.GetComponent<ReactorCoreClass>() == null)
        {
            ParticleSystemObject.SetActive(false);
            LightObject.SetActive(false);

            GameController.Instance.PowerSystem.GetSubsystem("Reactor Core").Status = ShipSystemClass.SystemStatusEnum.Offline;
        }
    }
}
