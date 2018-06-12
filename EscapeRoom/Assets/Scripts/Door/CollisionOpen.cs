using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionOpen : MonoBehaviour {

    Animator anim;

    // Use this for initialization
    void Start ()
    {
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Sphere")
        {
            StartCoroutine(DoAnimation());
        }
    }

    IEnumerator DoAnimation()
    {
        anim.Play("door_2_open");
        yield return new WaitForSeconds(.5f);
        anim.enabled = false;
        MeshCollider theCollider = GetComponent<MeshCollider>();
        theCollider.enabled = false;
    }
}
