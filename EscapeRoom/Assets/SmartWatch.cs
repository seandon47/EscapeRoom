using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartWatch : MonoBehaviour {
    GameObject MountPoint1;
    GameObject MountPoint2;

	// Use this for initialization
	void Start () {
        MountPoint1 = CreateMountPoint("Primary Mount Point", new Vector3(-0.1f, 0, 0));
        MountPoint2 = CreateMountPoint("Secondary Mount Point", new Vector3(0.1f, 0, 0));
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    protected GameObject CreateMountPoint(string Name, Vector3 Offset)
    {
        GameObject NovaMountPoint = new GameObject();
        NovaMountPoint.name = Name;
        SphereCollider SC = NovaMountPoint.AddComponent<SphereCollider>();
        SC.center = Vector3.zero;
        SC.radius = 0.05f;
        SC.isTrigger = true;

        NovaMountPoint.AddComponent<MountPoint>();

        NovaMountPoint.transform.SetParent(transform.parent, false);
        NovaMountPoint.transform.localPosition = Offset;

        // DEBUG CODE
        //GameObject sphere = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        //sphere.transform.localPosition = Offset;
        //sphere.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
        //sphere.transform.SetParent(transform.parent, false);

        return NovaMountPoint;
    }
}
