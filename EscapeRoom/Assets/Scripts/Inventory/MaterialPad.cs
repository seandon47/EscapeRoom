using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class MaterialPad : MonoBehaviour
{
    private bool HasObject;
    private GameObject ItemMaterial;

    // Start is called before the first frame update
    void Start()
    {
        HasObject = false;        
    }

    // Update is called once per frame
    void Update()
    {
        if (HasObject)
        {
            // Maybe spin object?
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (ItemMaterial != null)
            return;

        collision.gameObject.transform.SetParent(transform);
        collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        collision.gameObject.transform.rotation = new Quaternion(90, 0, 0, 0);
        collision.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        ItemMaterial = collision.gameObject;
    }

    private void OnTransformChildrenChanged()
    {
        if (transform.GetChild(0).gameObject.GetComponent<Throwable>() == null)
        {
            HasObject = false;
            ItemMaterial = null;
        }
    }
}
