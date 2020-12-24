using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowerAnimator : MonoBehaviour
{
    private Animator Lower;
    // Start is called before the first frame update
    void Start()
    {
        Lower = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.D)) && movement.grounded == true)
        {
            Lower.SetBool("forward", true);
        }
        else Lower.SetBool("forward", false);
        if (Input.GetKey(KeyCode.S) && movement.grounded == true)
        {
            Lower.SetBool("backwards", true);
        }
        else Lower.SetBool("backwards", false);
        if (Input.GetKey(KeyCode.Space) && movement.grounded == true)
        {
            Lower.Play("Idle");
            Lower.SetBool("jump", true);
        }
        else if (movement.grounded != true) Lower.SetBool("jump", true);
        else Lower.SetBool("jump", false); 
    }
}
