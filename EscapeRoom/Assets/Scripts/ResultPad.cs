using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResultPad : MonoBehaviour
{
    GameObject ResultItem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetResultItem(GameObject gameObject)
    {
        ResultItem = gameObject;
        ResultItem.AddComponent<SpinScript>();
    }
}
