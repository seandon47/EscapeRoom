using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObj : MonoBehaviour {

    public GameObject baroquePrefab, contents;

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
            GameObject GO = Instantiate(baroquePrefab, transform.position, transform.rotation);
            GO.transform.localScale = transform.localScale;

            if(contents != null)
            {
                GameObject content = Instantiate(contents, transform.position, transform.rotation);
            }
                
        }
        Destroy(gameObject);

	}
}
