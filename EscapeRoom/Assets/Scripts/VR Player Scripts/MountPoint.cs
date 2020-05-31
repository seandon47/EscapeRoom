using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountPoint : MonoBehaviour {
    Mountable MountedObject;
    GameObject VisibleMountPoint;

	// Use this for initialization
	void Start ()
    {
        MountPointPublisher.Instance.OnShowMountPoints += Instance_OnShowMountPoints;
        MountPointPublisher.Instance.OnHideMountPoints += Instance_OnHideMountPoints;		
	}

    private void Instance_OnShowMountPoints()
    {
        VisibleMountPoint = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        VisibleMountPoint.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        VisibleMountPoint.transform.SetParent(this.transform);
        VisibleMountPoint.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
    }

    private void Instance_OnHideMountPoints()
    {
        Destroy(VisibleMountPoint);
        VisibleMountPoint = null;
    }

    // Update is called once per frame
    void Update ()
    {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        Mountable MO = other.gameObject.GetComponent<Mountable>();

        if (MO != null)
        {
            MO.ShowMountCue();
            MO.SetMountPoint(this);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Mountable MO = other.gameObject.GetComponent<Mountable>();

        if (MO != null)
        {
            MO.CancelMountCue();
            MO.SetMountPoint(null);
        }
    }
}
