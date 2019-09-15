using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapFallthroughCatcher : MonoBehaviour
{
    public List<GameObject> theseAreImportantDontLetThemFall = new List<GameObject>();
    public List<Vector3> originalPositions = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < theseAreImportantDontLetThemFall.Count; i++)
        {
            originalPositions.Add(new Vector3(theseAreImportantDontLetThemFall[i].transform.localPosition.x, theseAreImportantDontLetThemFall[i].transform.localPosition.y,
                theseAreImportantDontLetThemFall[i].transform.localPosition.z));
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < theseAreImportantDontLetThemFall.Count; i++)
        {
            if (theseAreImportantDontLetThemFall[i].transform.localPosition.y < -100)
            {
                theseAreImportantDontLetThemFall[i].transform.localPosition = originalPositions[i];
                theseAreImportantDontLetThemFall[i].GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
            }
        }

    }
}
