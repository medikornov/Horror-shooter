using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnim : MonoBehaviour
{
    private Animator anim;
    public Transform enemy;
    public Transform collisions;
    public EnemyController contr;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        contr = this.transform.parent.gameObject.transform.parent.GetComponent<EnemyController>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = collisions.transform.position;
        /*if (!EnemyController.hitted) anim.SetBool("run", true);
        if (EnemyController.hitted) anim.SetBool("run", true);

        if (!EnemyController.grounded) anim.SetBool("run", false);
        if (EnemyController.grounded) anim.SetBool("run", false);
        */
        enemy.transform.position = pos;
        //Debug.Log(contr.grounded);
        if (!contr.grounded)
        {
            enemy.transform.position = pos;
            anim.SetBool("run", false);
        }
        else if (contr.grounded  && !contr.hitted)
        {
            enemy.transform.position = pos;
            anim.SetBool("run", true);
        }
        else if (contr.hitted)
        {
            enemy.transform.position = pos;
            anim.SetBool("run", false);
        }

    }
    
}
