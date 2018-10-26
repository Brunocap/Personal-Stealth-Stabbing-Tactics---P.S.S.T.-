using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeAttack : KnifeHit
{

    Animator anim;

    CapsuleCollider cc;

  

    // Use this for initialization
    void Start()
    {


        anim = GetComponent<Animator>();

        cc = GetComponent<CapsuleCollider>();
        cc.enabled = false;

    }


    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
            anim.SetTrigger("Stabbing");

    }

    public void ActivateCollider(int active)
    {
        if (active == 0)
            cc.enabled = false;
        else
            cc.enabled = true;
    }




    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.GetComponent<IKnifeHittable>() != null)
        {
            cc.enabled = false;
            c.gameObject.SendMessage("OnGetHitByKnife", 5);

        }
    }


}