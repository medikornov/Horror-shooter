using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public GameObject Player;
    public GameObject House;
    public GameObject Enemy;
    public float MoveSpeed = 4;
    public bool grounded;
    public bool hitted;
    public Rigidbody myRgd;
    float pathLength;
    float LengthToHouse;
    float LengthToPlayer;
    float temp;
    public float laikas = 5;
    float time = 0;
    float time1 = 0;

    void Start()
    {
        grounded = false;
        hitted = false;
        temp = MoveSpeed;
        Player = GameObject.Find("Player");
        House = GameObject.Find("Houseris");
        Vector3 rotation = new Vector3(Player.transform.position.x, transform.position.y, Player.transform.position.z);
        transform.LookAt(rotation);
    }

    void Update()
    {
        shortestPath();
        if (grounded)
        {  
            if (pathLength == LengthToHouse)
            {
                 Vector3 rotation = new Vector3(House.transform.position.x, transform.position.y, House.transform.position.z);
                 transform.LookAt(rotation);
            }
            else
            {
                Vector3 rotation = new Vector3(Player.transform.position.x, transform.position.y, Player.transform.position.z);
                transform.LookAt(rotation);
            } 
            Vector3 Movement = new Vector3(0, myRgd.velocity.y, MoveSpeed);
            Movement = transform.TransformDirection(Movement);
            myRgd.velocity = Movement;
        }
        
        

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Coll")
        {
            movement.health -= 10;
        }
        if (other.gameObject.name == "Houseris")
        {
            movement.house--;
        }
    }

    void OnTriggerStay(Collider other)
    {

        if (other.gameObject.name == "Terrain") grounded = true;
        if (other.gameObject.tag == "Target2")
        {
            hitted = true;
            MoveSpeed = 0;
        }
        if (other.gameObject.name == "Coll")
        {
            time += Time.deltaTime;
            if (time > 1)
            {
                time = 0;
                movement.health -= 10;
            }
        }
        if (other.gameObject.name == "Houseris")
        {
            time1 += Time.deltaTime;
            if (time1 > 1)
            {
                time1 = 0;
                movement.house--;
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Terrain") grounded = false;
        if (other.gameObject.tag == "Target2")
        {
            hitted = false;
            MoveSpeed = temp;
        }
        

    }
    /*void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Terrain")
        {
            grounded = true;
        }
    }*/
    void shortestPath()
    {
        //LengthToHouse = (House.transform.position - this.transform.position).magnitude;

        float distanceToClosest = Mathf.Infinity;
        Houser house = null;
        Houser[] allHousePivots = GameObject.FindObjectsOfType<Houser>();

        foreach (Houser currentPivot in allHousePivots)
        {
            float distance = (currentPivot.transform.position - this.transform.position).magnitude;
            if (distance < distanceToClosest)
            {
                distanceToClosest = distance;
                house = currentPivot;
            }
        }
        Debug.DrawLine(this.transform.position, house.transform.position);
        LengthToHouse = distanceToClosest;
        LengthToPlayer = (Player.transform.position - this.transform.position).magnitude;
        if (LengthToHouse <= LengthToPlayer) pathLength = LengthToHouse;
        else pathLength = LengthToPlayer;
    }
    
}
