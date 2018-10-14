using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MountableObject : MonoBehaviour {
    public bool IsMounted;
    Color OriginalColor;
    MountPoint mountPoint;

	// Use this for initialization
	void Start () {
        IsMounted = false;
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
        if(MR != null)
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
            OriginalColor = MR.material.color;
            MR.material.color = OriginalColor;
        }
    }

    public virtual void MountObject(GameObject NewParent)
    {
        //Debug.Log("MountObject " + gameObject.name + " to " + NewParent.name);
        transform.SetParent(NewParent.transform);

        transform.localPosition = new Vector3(0, 0, 0);
        transform.rotation = new Quaternion(NewParent.transform.rotation.x, NewParent.transform.rotation.y, NewParent.transform.rotation.z, NewParent.transform.rotation.w);

        MeshRenderer MR = GetComponent<MeshRenderer>();
        if (MR != null)
        {
            MR.material.color = OriginalColor;
        }

        IsMounted = true;
    }

    public void OnPickUp()
    {
        //Debug.Log(name + " was picked up");
        IsMounted = false;
    }

    public void OnDetachHand()
    {
        //Debug.Log(name + " was detached from hand");
        if (mountPoint != null)
        {
            MountObject(mountPoint.gameObject);
        }
        else
        {
            IsMounted = false;
        }
    }
}
