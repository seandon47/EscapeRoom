using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public GameObject Director;
    public GameObject Follower;
    public Camera DroneCamera;
    public float FollowerX;
    public float FollowerY;
    public float FollowerZ;

    public GameObject CrossHair;

    Rigidbody rb;
    bool InteractiveMode;
    GameObject InteractingObject;

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        #region Mouse Input
        #region Mouse Input THIS Frame
        // Left mouse button went down this frame
        if (Input.GetMouseButtonDown(0))
        {
            // Select object for interactions
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

        // Right mouse button went up this frame
        if (Input.GetMouseButtonUp(1))
        {
            // Disable interactive mode
            InteractiveMode = false;
            if (CrossHair != null)
            {
                CrossHair.SetActive(false);
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

        }

        //Right mouse button is being held down
        if (Input.GetMouseButton(1))
        {
            RaycastHit hit;
            Ray ray = DroneCamera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 5.0f))
            {
                if( InteractingObject != null &&
                    !InteractingObject.transform.name.Equals(hit.transform.name))
                {
                    Debug.Log("Drone Selected: " + hit.transform.name);
                }
                InteractingObject = hit.transform.gameObject;
            }
        }

        // Middle mouse button is being held down
        if (Input.GetMouseButton(2))
        {

        }
        #endregion
        #endregion

        #region Keyboard Input
        if (Input.GetKeyDown(KeyCode.C))
        {
            GameController.Instance.ToggleNewConsole();
        }
        #endregion

    }

    void FixedUpdate()
    {
        //if (transform.position.y <= -3.8)
        //{
        //    float moveHorizontal = Input.GetAxis("Horizontal");
        //    float moveVertical = Input.GetAxis("Vertical");

        //    Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        //    movement = Director.transform.rotation * movement;

        //    rb.velocity = movement * speed;
        //}

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        movement = Director.transform.rotation * movement;

        rb.AddForce(movement * speed);

        if (moveHorizontal == 0 && moveVertical == 0)
        {
            var oppositeForce = -rb.velocity * 500;
            rb.AddForce(oppositeForce * Time.deltaTime);
            transform.rotation = Quaternion.identity;
        }

        float xOffset = transform.position.x + FollowerX;
        float yOffset = transform.position.y + FollowerY;
        float zOffset = transform.position.z + FollowerZ;
        Follower.transform.position = new Vector3(xOffset, yOffset, zOffset);
        Director.transform.position = new Vector3(transform.position.x, transform.position.y + 0.250f, transform.position.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PlayerRobot")
        {
            Physics.IgnoreCollision(GetComponent<Collider>(), collision.gameObject.GetComponent<Collider>());
        }
    }
}
