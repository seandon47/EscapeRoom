using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

[RequireComponent(typeof(Throwable))]
public class MountableObject : MonoBehaviour {
    public Vector3 MountedOrientation;
    public Vector3 MountedPosition;
    public bool IsMounted;
    Quaternion MountedRotation;
    Color OriginalColor;
    MountPoint mountPoint;

	// Use this for initialization
	void Start () {
        IsMounted = false;
        MountedRotation = Quaternion.Euler(MountedOrientation.x, MountedOrientation.y, MountedOrientation.z);
        Throwable throwable = GetComponent<Throwable>();
        throwable.onPickUp.AddListener(OnPickUp);
        throwable.onDetachFromHand.AddListener(OnDetachHand);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetMountPoint(MountPoint MP)
    {
        mountPoint = MP;
    }

    public virtual void ShowMountCue()
    {
        MeshRenderer MR = GetComponent<MeshRenderer>();
        if(MR != null && !IsMounted)
        {
            OriginalColor = MR.material.color;
            MR.material.color = Color.blue;
        }
    }

    public virtual void CancelMountCue()
    {
        MeshRenderer MR = GetComponent<MeshRenderer>();
        if (MR != null)
        {
            MR.material.color = OriginalColor;
        }
    }

    public virtual void MountObject(GameObject NewParent)
    {
        Debug.Log($"MountObject {gameObject.name} to {NewParent.name}");
        transform.SetParent(NewParent.transform);
        gameObject.GetComponent<Rigidbody>().isKinematic = true;

        transform.localPosition = MountedPosition;
        transform.localRotation = MountedRotation;

        MeshRenderer MR = GetComponent<MeshRenderer>();
        if (MR != null)
        {
            MR.material.color = OriginalColor;
        }

        IsMounted = true;
    }

    public void OnPickUp()
    {
        Debug.Log($"{name} was picked up");
        IsMounted = false;
    }

    public void OnDetachHand()
    {
        Debug.Log($"{name} was detached from hand. Mount Point was: {mountPoint}");
        if (mountPoint != null)
        {
            MountObject(mountPoint.gameObject);
        }
        else
        {
            IsMounted = false;
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
