using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int id;
    public int prefabId;
    public float damege;
    public int count;
    public float speed;

    void Start(){
        Init();
    }

    void Update() {
        switch (id){
            case 0:
                transform.Rotate(Vector3.back * speed * Time.deltaTime);
                break;
            default:
                break;
        }
        
    }

    public void LevelUp(float damege, int count){
        this.damege = damege;
        this.count = count;

        if (id == 0){
            Batch();
        }
    }

    public void Init(){
        switch (id){
            case 0:
                speed = 150;
                Batch();
                break;
            default:
                break;
        }
    }

    void Batch(){
        for (int i = 0; i < count; i++){
            Transform bullet;
            if (i < transform.childCount){
                bullet = transform.GetChild(i);
            } else {
                bullet = GameManager.instance.pool.Get(prefabId).transform;
                bullet.parent = transform;
            }

            bullet.localPosition = Vector3.zero;
            bullet.localRotation = Quaternion.identity;

            Vector3 rotVec = Vector3.forward * 360 * i / count;
            bullet.Rotate(rotVec);
            bullet.Translate(bullet.up * 1.5f, Space.World);
            bullet.GetComponent<Bullet>().Init(damege, -1);
        }
    }
}