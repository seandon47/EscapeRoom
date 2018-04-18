using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorButton : MonoBehaviour {
    
    public GameObject door;
    MeshCollider thedoorCollider;
    BoxCollider theCollider;
    Animator anim;
    bool doorOpened = false;

    // Use this for initialization
    void Start ()
    {
        anim = door.GetComponent<Animator>();
        thedoorCollider = door.GetComponent<MeshCollider>();
        theCollider = this.GetComponent<BoxCollider>();
    }
	
	// Update is called once per frame
	void Update ()
    {

    }

    void OnCollisionEnter(Collision col)
    {
        StartCoroutine(DoAnimation());
    }

    IEnumerator DoAnimation()
    {
        theCollider.enabled = false;
        if (!doorOpened)
        { 
            anim.Play("door_2_open");
            yield return new WaitForSeconds(.5f);
            anim.enabled = false;
            thedoorCollider.enabled = false;
            doorOpened = true;
        }
        else
        {
            anim.enabled = true;
            anim.Play("door_2_close");
            yield return new WaitForSeconds(.5f);
            thedoorCollider.enabled = true;
            doorOpened = false;
        }
        theCollider.enabled = true;
    }
}
