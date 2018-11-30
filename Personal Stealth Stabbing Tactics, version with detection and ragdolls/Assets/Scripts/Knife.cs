using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : KnifeHit
{

    GameObject ThirdPersonController;
    Animator anim;

    CapsuleCollider cc;

    bool hit = false;
    public int HitLimit	 = 1;
    public int Hitchecker = 0;


    // Use this for initialization
    void Start()
    {
        ThirdPersonController = transform.root.gameObject;
        
        anim = ThirdPersonController.GetComponent<Animator>();

        cc = GetComponent<CapsuleCollider>();
        cc.enabled = false;

    }


    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Attack");
            cc.enabled = true;
        }
    }


    void OnTriggerEnter(Collider other)
    {
        if(other.transform.tag=="Enemy")
        {
            Debug.Log("hit");
            cc.enabled = false;
        }

    }




}