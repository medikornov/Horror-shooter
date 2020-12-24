using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puska : MonoBehaviour
{
    public GameObject kulipka;
    public GameObject gun;
    public float shootingRate;
    private float rate;
    // Start is called before the first frame update
    void Start()
    {
        rate = shootingRate;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && shootingRate <= 0)
        {
            
            Instantiate(kulipka, gun.transform.position, gun.transform.rotation);
            shootingRate = rate;
        }
        shootingRate -= Time.deltaTime * 1;
    }
    
}
