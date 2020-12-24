using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float camMoveSpeed = 120.0f;
    public GameObject camFollowObj;
    // Vector3 followPos;
    public float clampAngle = 80.0f;
    public float sensitivity = 150.0f;
    // public GameObject camObject;
    public GameObject player;
    // public float camDistanceXToPlayer;
    // public float camDistanceYToPlayer;
    // public float camDistanceZToPlayer;
    public float mouseX;
    public float mouseY;
    public float finalInputX;
    public float finalInputZ;
    // public float smoothX;
    // public float smoothY;
    private float rotY = 0.0f;
    private float rotX = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = Input.GetAxis("RightStickHorizontal");
        float inputZ = Input.GetAxis("RightStickVertical");
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        
        finalInputX = inputX + mouseX;
        finalInputZ = inputZ + mouseY;

        rotY += finalInputX * sensitivity * Time.deltaTime;
        rotX += finalInputZ * sensitivity * Time.deltaTime;

        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);

        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.rotation = localRotation;
        player.transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        
    }
    void LateUpdate()
    {
        CameraUpdater();
    }
    void CameraUpdater()
    {
        Transform target = camFollowObj.transform;
        float step = camMoveSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target.position, step);
    }
}
