using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

[RequireComponent(typeof(Throwable))]
[RequireComponent(typeof(ItemBehaviour))]
public class Mountable : MonoBehaviour {
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

    internal ItemBehaviour GetBehavior()
    {
        return GetComponent<ItemBehaviour>();
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
        ReturnOriginalMaterialColor();
    }

    public void OnPickUp()
    {
        // Debug.Log($"{name} was picked up");
        IsMounted = false;
        MountPointPublisher.Instance.ShowMountPoints(this.gameObject);
        mountPoint?.UnMount();
    }

    public void OnDetachHand()
    {
        //Debug.Log($"{name} was detached from hand. Mount Point was: {mountPoint}");
        if (mountPoint != null)
        {
            MountObject(mountPoint.gameObject);
            mountPoint.Mount(this);
        }
        else
        {
            IsMounted = false;
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
        MountPointPublisher.Instance.HideMountPoints(this.gameObject);
    }

    protected virtual void MountObject(GameObject NewParent)
    {
        // Debug.Log($"MountObject {gameObject.name} to {NewParent.name}");
        Reparent(NewParent);
        ReturnOriginalMaterialColor();

        IsMounted = true;
    }

    private void Reparent(GameObject NewParent)
    {
        transform.SetParent(NewParent.transform);
        gameObject.GetComponent<Rigidbody>().isKinematic = true;

        transform.localPosition = MountedPosition;
        transform.localRotation = MountedRotation;
    }

    private void ReturnOriginalMaterialColor()
    {
        MeshRenderer MR = GetComponent<MeshRenderer>();
        if (MR != null)
        {
            MR.material.color = OriginalColor;
        }
    }
}
