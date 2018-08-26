using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebrisSpawn : MonoBehaviour {

    public GameObject debris;
    public int debrisCount;
    public float rate = 1.0f;
    public float velocityX, velocityY, velocityZ;
    private List<GameObject> debrisList; 

    // Use this for initialization
    void Start ()
    {
        velocityZ = 10;
        debrisCount = 10;
        debrisList = new List<GameObject>();
        StartCoroutine(Spawn());
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (debrisList.Count > debrisCount)
        {
            Destroy(debrisList[0]);
            debrisList.RemoveAt(0);
        }
	}
    IEnumerator Spawn()
    {
        while (true)
        {
            //debris.GetComponent<Rigidbody>().velocity = new Vector3(velocityX, velocityY, velocityZ);
            GameObject copy = Instantiate(debris, debris.transform.localPosition, gameObject.transform.localRotation);
            copy.GetComponent<Rigidbody>().velocity = new Vector3(velocityX, velocityY, velocityZ);
            copy.transform.position = new Vector3(Random.Range(-61, -31), Random.Range(-30, 7), debris.transform.position.z);
            debrisList.Add(copy);
            yield return new WaitForSeconds(rate);
        }
    }

}
