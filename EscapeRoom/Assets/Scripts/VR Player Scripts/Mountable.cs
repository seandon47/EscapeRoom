using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

[RequireComponent(typeof(Throwable))]
public class Mountable : MonoBehaviour {
    public Vector3 MountedOrientation;
    public Vector3 MountedPosition;
    public bool IsMounted;

    Quaternion MountedRotation;
    Color OriginalColor;
    MountPoint CurrentMountPoint;
    ItemBehaviour Behaviour;

	// Use this for initialization
	void Start () {
        IsMounted = false;
        Behaviour = GetComponent<ItemBehaviour>();
        MountedRotation = Quaternion.Euler(MountedOrientation.x, MountedOrientation.y, MountedOrientation.z);
        Throwable throwable = GetComponent<Throwable>();
        throwable.onPickUp.AddListener(OnPickUp);
        throwable.onDetachFromHand.AddListener(OnDetachHand);

        if (Behaviour == null)
            Behaviour = new NullBehaviour();
	}

    internal ItemBehaviour GetBehavior()
    {
        return Behaviour;
    }

    // Update is called once per frame
    void Update () {
		
	}

    public void SetMountPoint(MountPoint MP)
    {
        CurrentMountPoint = MP;
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
        CurrentMountPoint?.UnMount();
    }

    public void OnDetachHand()
    {
        //Debug.Log($"{name} was detached from hand. Mount Point was: {mountPoint}");
        if (CurrentMountPoint != null)
        {
            MountObject(CurrentMountPoint.gameObject);
            CurrentMountPoint.Mount(this);
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
