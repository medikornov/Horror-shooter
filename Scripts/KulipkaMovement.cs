using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KulipkaMovement : MonoBehaviour
{
    public int speed;
    public GameObject kulipka;
    public GameObject cube;
    Vector3 prevPos;
    //TEMPORARY
    public Vector3 size;
    public Vector3 center;
    //

    // Start is called before the first frame update
    void Start()
    {
        prevPos = transform.position;
        //
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), size.y, Random.Range(-size.z / 2, size.z / 2));
        //
    }

    // Update is called once per frame
    void Update()
    {
        prevPos = transform.position;
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        RaycastHit[] hits = Physics.RaycastAll(new Ray(prevPos, (transform.position - prevPos).normalized), (transform.position - prevPos).magnitude);
        for(int i = 0; i < hits.Length; i++)
        {
            if (hits[i].collider.gameObject.name == "Cube(Clone)")
            {
                Destroy(GameObject.FindWithTag("Target"));
                CubeAppearing();
                Destroy(kulipka);
            }
            else Destroy(kulipka);
        }
    }
    //
    void CubeAppearing()
    {
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), size.y, Random.Range(-size.z / 2, size.z / 2));
        Instantiate(cube, pos, Quaternion.identity);
    }
    //
    
}
