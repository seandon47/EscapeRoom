using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObj : MonoBehaviour {

    public GameObject baroquePrefab;

    void OnMouseDown()
    {
        BreakThatShit();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 2f)
        {
            BreakThatShit();
        }
    }
	
	// Update is called once per frame
	void BreakThatShit ()
    {
        if (baroquePrefab)
        {
            Instantiate(baroquePrefab, transform.position, transform.rotation);
        }
        Destroy(gameObject);

	}
}
