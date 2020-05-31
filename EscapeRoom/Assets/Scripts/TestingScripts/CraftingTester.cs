using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingTester : MonoBehaviour
{
    public GameObject Material1;
    public GameObject Material2;
    public CraftingStation CraftingTable;

    public GameObject Prefab1;
    public GameObject Prefab2;

    // Start is called before the first frame update
    void Start()
    {
        if (Material1 == null ||
            Material2 == null ||
            CraftingTable == null)
            throw new System.Exception();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {

        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {

        }
        
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            CraftingTable.TryCraft();
        }
    }
}
