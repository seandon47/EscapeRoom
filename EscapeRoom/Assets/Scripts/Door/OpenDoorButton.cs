using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorButton : MonoBehaviour {
    
    public GameObject door;
    MeshCollider thedoorCollider;
    BoxCollider theCollider;
    Animator anim;
    Door myDoor;
    bool doorOpened = false;
    public AudioClip doorCloseSound, doorOpenSound;
    AudioSource audio;

    // Use this for initialization
    void Start ()
    {
        anim = door.GetComponent<Animator>();
        thedoorCollider = door.GetComponent<MeshCollider>();
        theCollider = this.GetComponent<BoxCollider>();
        myDoor = door.GetComponent<Door>();
        audio = door.GetComponent<AudioSource>();

        if (myDoor.isOpenAtStart)
        {
            StartCoroutine(DoAnimation());
        }
    }
	
	// Update is called once per frame
	void Update ()
    {

    }

    public void ToggleDoor()
    {
        StartCoroutine(DoAnimation());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (myDoor.IsLocked)
            return;

        StartCoroutine(DoAnimation());
    }

    void OnCollisionEnter(Collision col)
    {
        if (myDoor.IsLocked)
            return;

        StartCoroutine(DoAnimation());
    }

    IEnumerator DoAnimation()
    {
        theCollider.enabled = false;
        if (!doorOpened)
        {
            audio.PlayOneShot(doorOpenSound);
            anim.Play("door_2_open");
            yield return new WaitForSeconds(.5f);
            anim.enabled = false;
            thedoorCollider.enabled = false;
            doorOpened = true;
        }
        else
        {
            audio.PlayOneShot(doorCloseSound);
            anim.enabled = true;
            anim.Play("door_2_close");
            yield return new WaitForSeconds(.5f);
            thedoorCollider.enabled = true;
            doorOpened = false;
        }
        theCollider.enabled = true;
    }
}
