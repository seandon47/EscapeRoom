using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemBehaviour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public abstract void Input();
    public abstract void EquipToVrPlayer(Watch watch, int mountableId);
}
