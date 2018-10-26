using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : KnifeHit
{

    public void OnGetHitByKnife(float hitValue)
    {
        Debug.Log("Goblin got hit by Axe!");
    }
}
