using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Valve.VR.InteractionSystem;

public class Watch : MonoBehaviour
{
    public List<MountPoint> MountPointList;
    public TextMeshPro DisplayName;
    public GameObject WatchBody;

    Dictionary<int, GameObject> MountedControls = new Dictionary<int, GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        foreach(MountPoint mountPoint in MountPointList)
        {
            mountPoint.OnItemMounted.AddListener(OnEquipped);
            mountPoint.OnItemUnmounted.AddListener(OnUnequipped);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnEquipped(Mountable equipedItem)
    {
        //Debug.Log($"{equipedItem.name} was equipped : {equipedItem.GetInstanceID()}");
        DisplayName.SetText(equipedItem.name);
        ItemBehaviour behavior = equipedItem.GetBehavior();
        behavior.EquipToVrPlayer(this);
    }

    public void OnUnequipped(Mountable unequippedItem)
    {
        int ID = unequippedItem.GetInstanceID();
        //Debug.Log($"{unequippedItem.name} was unequipped : {ID}");

        DisplayName.SetText("(EMPTY)");

        GameObject buttonToDestroy = MountedControls[ID];
        buttonToDestroy.transform.SetParent(null);
        Destroy(buttonToDestroy);

        MountedControls.Remove(ID);

        MountedControls.Clear();
    }

    public void AddButton(GameObject buttonObject)
    {
        buttonObject.transform.SetParent(WatchBody.transform, false);
        buttonObject.transform.localPosition = new Vector3(0.4f, .075f, 0.4f);

        MountedControls.Add(buttonObject.GetInstanceID(), buttonObject);
    }

    public void AddDisplay(GameObject displayObject)
    {

    }
}
