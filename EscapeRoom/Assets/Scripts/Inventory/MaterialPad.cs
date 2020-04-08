using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class MaterialPad : MonoBehaviour
{
    public bool HasObject { get; set; }
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

        //collision.gameObject.transform.SetParent(transform);
        collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
        collision.gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
        collision.gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        collision.gameObject.AddComponent<SpinScript>();
        ItemMaterial = collision.gameObject;
        HasObject = true;
    }

    private void OnTransformChildrenChanged()
    {
        GameObject childObject = transform.GetChild(0).gameObject;

        if (childObject.GetComponent<Throwable>() == null)
        {
            Destroy(childObject.GetComponent<SpinScript>());
            HasObject = false;
            ItemMaterial = null;
        }
    }

    public GameObject GetObject()
    {
        return ItemMaterial;
    }

    public void UseUpMaterial()
    {
        Destroy(ItemMaterial);
        HasObject = false;
    }
}
