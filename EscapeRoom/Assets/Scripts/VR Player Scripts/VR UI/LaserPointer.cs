using UnityEngine;
using Valve.VR.Extras;
using Valve.VR;

public class LaserPointer : MonoBehaviour
{    
    public SteamVR_Action_Boolean interactWithUI = SteamVR_Input.GetBooleanAction("InteractUI");

    public bool Active = true;
    public Color LaserColor;
    public float LaserThickness = 0.002f;
    public event PointerEventHandler PointerIn;
    public event PointerEventHandler PointerOut;
    public event PointerEventHandler PointerClickDown;
    public event PointerEventHandler PointerClickUp;

    private GameObject pointer;
    private GameObject holder;
    private SteamVR_Behaviour_Pose pose;
    private Transform previousContact = null;
    private bool addRigidBody = false;

    private void Start()
    {
        if (pose == null)
            pose = this.GetComponent<SteamVR_Behaviour_Pose>();
        if (pose == null)
            Debug.LogError("No SteamVR_Behaviour_Pose component found on this object", this);

        if (interactWithUI == null)
            Debug.LogError("No ui interaction action has been set on this component.", this);


        holder = new GameObject();
        holder.transform.parent = this.transform;
        holder.transform.localPosition = Vector3.zero;
        holder.transform.localRotation = Quaternion.identity;

        pointer = GameObject.CreatePrimitive(PrimitiveType.Cube);
        pointer.transform.parent = holder.transform;
        pointer.transform.localScale = new Vector3(LaserThickness, LaserThickness, 100f);
        pointer.transform.localPosition = new Vector3(0f, 0f, 50f);
        pointer.transform.localRotation = Quaternion.identity;
        BoxCollider collider = pointer.GetComponent<BoxCollider>();
        if (addRigidBody)
        {
            if (collider)
            {
                collider.isTrigger = true;
            }
            Rigidbody rigidBody = pointer.AddComponent<Rigidbody>();
            rigidBody.isKinematic = true;
        }
        else
        {
            if (collider)
            {
                Object.Destroy(collider);
            }
        }

        Material newMaterial = new Material(Shader.Find("Unlit/Color"));
        newMaterial.SetColor("_Color", LaserColor);
        pointer.GetComponent<MeshRenderer>().material = newMaterial;
    }

    public virtual void OnPointerIn(PointerEventArgs e)
    {
        if (PointerIn != null)
            PointerIn(this, e);
    }

    public virtual void OnPointerClickDown(PointerEventArgs e)
    {
        if (PointerClickDown != null)
            PointerClickDown(this, e);
    }

    public virtual void OnPointerClickUp(PointerEventArgs e)
    {
        if (PointerClickUp != null)
            PointerClickUp(this, e);
    }

    public virtual void OnPointerOut(PointerEventArgs e)
    {
        if (PointerOut != null)
            PointerOut(this, e);
    }


    private void Update()
    {
        pointer.SetActive(Active);
        
        if (!Active)
        {
            return;
        }

        float dist = 100f;

        Ray raycast = new Ray(transform.position, transform.forward);
        RaycastHit hit;
        bool bHit = Physics.Raycast(raycast, out hit);

        if (previousContact && previousContact != hit.transform)
        {
            PointerEventArgs args = new PointerEventArgs();
            args.fromInputSource = pose.inputSource;
            args.distance = 0f;
            args.flags = 0;
            args.target = previousContact;
            OnPointerOut(args);
            previousContact = null;
        }
        if (bHit && previousContact != hit.transform)
        {
            PointerEventArgs argsIn = new PointerEventArgs();
            argsIn.fromInputSource = pose.inputSource;
            argsIn.distance = hit.distance;
            argsIn.flags = 0;
            argsIn.target = hit.transform;
            OnPointerIn(argsIn);
            previousContact = hit.transform;
        }
        if (!bHit)
        {
            previousContact = null;
        }
        if (bHit && hit.distance < 100f)
        {
            dist = hit.distance;
        }

        if (bHit && interactWithUI.GetStateDown(pose.inputSource))
        {
            PointerEventArgs argsClick = new PointerEventArgs();
            argsClick.fromInputSource = pose.inputSource;
            argsClick.distance = hit.distance;
            argsClick.flags = 0;
            argsClick.target = hit.transform;
            OnPointerClickDown(argsClick);
        }

        if (bHit && interactWithUI.GetStateUp(pose.inputSource))
        {
            PointerEventArgs argsClick = new PointerEventArgs();
            argsClick.fromInputSource = pose.inputSource;
            argsClick.distance = hit.distance;
            argsClick.flags = 0;
            argsClick.target = hit.transform;
            OnPointerClickUp(argsClick);
        }

        pointer.transform.localScale = new Vector3(LaserThickness, LaserThickness, dist);
        pointer.GetComponent<MeshRenderer>().material.color = LaserColor;
        pointer.transform.localPosition = new Vector3(0f, 0f, dist / 2f);
    }
}

public delegate void PointerEventHandler(object sender, PointerEventArgs e);