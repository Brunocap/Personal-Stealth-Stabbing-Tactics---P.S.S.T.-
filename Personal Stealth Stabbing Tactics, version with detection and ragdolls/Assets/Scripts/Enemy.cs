using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : KnifeHit
{
    GameObject Ragdolltest1;
    public Rigidbody rb;
    public float mass;
    CapsuleCollider cc;
    NavMeshAgent NMA;
    public Transform theRagdoll;
    public Transform thePlayer;

    void SetKinematic(bool newValue)
    {
        Rigidbody[] bodies = GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rb in bodies)
        {
            rb.isKinematic = newValue;
        }
    }
    void Start()
    {
        SetKinematic(true);
        rb = GetComponent<Rigidbody>();
        rb.mass = mass;
        rb.mass = 1;
        cc = GetComponent<CapsuleCollider>();
        NMA = GetComponent<NavMeshAgent>();
        cc.enabled = true;


    }
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Knife")
        {
            Debug.Log("Enemy got hit by Knife!");
            Destroy(cc);
            SetKinematic(false);
            GetComponent<Animator>().enabled = false;
            Destroy(NMA);
            rb.mass = -1;
            Destroy(cc);
        }

    }

    void update()
    {
    }
}
