using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeHit : MonoBehaviour
{

    public interface IKnifeHittable
    {

        void OnGetHitByKnife(float hitValue);
    }
}