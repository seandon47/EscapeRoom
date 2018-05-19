using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed;
    public GameObject Director;
    public GameObject Follower;
    public float FollowerX;
    public float FollowerY;
    public float FollowerZ;

    private Rigidbody rb;

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            GameController.Instance.ToggleNewConsole();
        }

    }

    void FixedUpdate()
    {
        if (transform.position.y <= -3.8)
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
