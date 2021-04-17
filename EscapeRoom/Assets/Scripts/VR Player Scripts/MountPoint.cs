using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MountPoint : MonoBehaviour {
    
    public MountableUnityEvent OnItemMounted;
    public MountableUnityEvent OnItemUnmounted;

    Mountable MountedObject;
    GameObject VisibleMountPoint;

	// Use this for initialization
	void Start ()
    {
        Initialize();
	}

    protected virtual void Initialize()
    {
        MountedObject = null;
        MountPointPublisher.Instance.OnShowMountPoints += Instance_OnShowMountPoints;
        MountPointPublisher.Instance.OnHideMountPoints += Instance_OnHideMountPoints;
    }

    protected virtual void Instance_OnShowMountPoints(GameObject mountableObject)
    {
        VisibleMountPoint = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        VisibleMountPoint.transform.localScale = new Vector3(0.01f, 0.01f, 0.01f);
        VisibleMountPoint.transform.SetParent(this.transform);
        VisibleMountPoint.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
    }

    protected virtual void Instance_OnHideMountPoints(GameObject mountableObject)
    {
        Destroy(VisibleMountPoint);
        VisibleMountPoint = null;
    }

    // Update is called once per frame
    void Update ()
    {
		
	}

    public virtual void Mount(Mountable mountable)
    {
        MountedObject = mountable;
        OnItemMounted?.Invoke(mountable);
    }

    public virtual void UnMount()
    {
        OnItemUnmounted?.Invoke(MountedObject);
        MountedObject = null;
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

    public void ExecuteMountedObject()
    {

    }
}
