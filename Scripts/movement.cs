using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public float MovementSpeed;
    public Rigidbody myRgd;
    bool grounded = false;
    public GameObject cube;
    // Use this for initialization
    void Start()
    {
        Instantiate(cube, new Vector3(100, 60, 100), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        float inpX = Input.GetAxis("Horizontal") * MovementSpeed;
        float inpZ = Input.GetAxis("Vertical") * MovementSpeed;
        Vector3 Movement = new Vector3(inpX, myRgd.velocity.y, inpZ);
        Movement = transform.TransformDirection(Movement);
        myRgd.velocity = Movement;
       
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            MovementSpeed /= 3;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            MovementSpeed *= 3;
        }
        if (Input.GetKey(KeyCode.Space) && grounded == true)
        {
            myRgd.velocity = Vector3.up * MovementSpeed;
            grounded = false;
        }
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Terrain") grounded = true;
    }
}
