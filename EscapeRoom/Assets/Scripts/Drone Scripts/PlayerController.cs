using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public GameObject Director;
    public GameObject Follower;
    public MiniMapClass Minimap;
    public Camera DroneCamera;
    public float FollowerX;
    public float FollowerY;
    public float FollowerZ;

    public List<MountPoint> MountPointList;
    ItemBehaviour PrimaryItemBehavior;

    public GameObject CrossHair, DroneEscapeMenu;
    int DecelerationMultiplier = 3000;
    int maxVelocity = 4;
    bool CanInteract = true;

    Rigidbody rb;
    bool InteractiveMode;
    GameObject InteractingObject;

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody>();

        foreach (MountPoint mountPoint in MountPointList)
        {
            mountPoint.OnItemMounted.AddListener(OnEquipped);
            mountPoint.OnItemUnmounted.AddListener(OnUnequipped);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!CanInteract)
            return;

        #region Mouse Input

        #region Mouse Input THIS Frame
        // Left mouse button went down this frame
        if (Input.GetMouseButtonDown(0))
        {
            // Interact with object
            if (InteractingObject == null)
                return;

            DroneInteractable DI = InteractingObject.GetComponent<DroneInteractable>();
            if (DI != null)
            {
                DI.Activated();
            }
        }

        // Right mouse button went down this frame
        if (Input.GetMouseButtonDown(1))
        {
            // Enable interactive mode
            InteractiveMode = true;
            if (CrossHair != null)
            {
                CrossHair.SetActive(true);
            }
        }

        // Middle mouse button went down this frame
        if (Input.GetMouseButtonDown(2))
        {

        }

        // Left mouse button went up this frame
        if (Input.GetMouseButtonUp(0))
        {

        }

        // Left mouse button went up this frame
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(!DroneEscapeMenu.activeInHierarchy)
            {
                DroneEscapeMenu.SetActive(true);
            }
            else
                DroneEscapeMenu.SetActive(false);

        }

        // Right mouse button went up this frame
        if (Input.GetMouseButtonUp(1))
        {
            // Disable interactive mode
            InteractiveMode = false;
            if (CrossHair != null)
            {
                CrossHair.SetActive(false);

                // If player has selected an object, deselect it now
                if (InteractingObject != null)
                {
                    DroneInteractable DI = InteractingObject.GetComponent<DroneInteractable>();
                    if (DI != null)
                    {
                        DI.Select(false);
                    }
                }
            }
        }

        // Middle mouse button went up this frame
        if (Input.GetMouseButtonUp(2))
        {

        }
        #endregion

        #region Mouse Input EVERY Frame
        // Left mouse button is being held down
        if (Input.GetMouseButton(0))
        {
            if (!CanInteract)
                return;
        }

        //Right mouse button is being held down
        if (Input.GetMouseButton(1))
        {
            RaycastHit hit;
            Ray ray = DroneCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 5.0f))
            {
                DroneInteractable DI = null;
                if ( InteractingObject != null &&
                    !InteractingObject.transform.name.Equals(hit.transform.name))
                {
                    DI = InteractingObject.GetComponent<DroneInteractable>();
                    if (DI != null)
                    {
                        DI.Select(false);
                    }
                    //Debug.Log("Drone Selected: " + hit.transform.name);
                }

                InteractingObject = hit.transform.gameObject;
                DI = InteractingObject.GetComponent<DroneInteractable>();
                if (DI != null)
                {
                    DI.Select(true);
                }
            }
        }

        // Middle mouse button is being held down
        if (Input.GetMouseButton(2))
        {

        }
        #endregion

        #endregion

        #region Keyboard Input
        if (Input.GetKeyDown(KeyCode.M))
        {
            Minimap.ToggleState();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            PrimaryItemBehavior?.Input();
        }
        #endregion

    }

    void FixedUpdate()
    {
        if (!CanInteract)
            return;

        Ray ray = new Ray(transform.position, Vector3.down);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 0.26f))
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

            movement = Director.transform.rotation * movement;

            rb.velocity = movement * speed;
        }

        float xOffset = transform.position.x + FollowerX;
        float yOffset = transform.position.y + FollowerY;
        float zOffset = transform.position.z + FollowerZ;
        //Follower.transform.localPosition = new Vector3(xOffset, yOffset, zOffset);
        Director.transform.position = new Vector3(transform.position.x, transform.position.y + 0.250f, transform.position.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PlayerRobot")
        {
            Physics.IgnoreCollision(GetComponent<Collider>(), collision.gameObject.GetComponent<Collider>());
        }
    }

    public void OnEquipped(Mountable equipedItem)
    {
        PrimaryItemBehavior = equipedItem.GetBehavior();
    }

    public void OnUnequipped(Mountable unequipedItem)
    {

    }

    public void SetCanInteract(bool canInteract)
    {
        CanInteract = canInteract;
    }
}
