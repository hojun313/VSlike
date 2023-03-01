using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damege;
    public int per;

    public void Init(float damege, int per)
    {
        this.damege = damege;
        this.per = per;
    }
}
