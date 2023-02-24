using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition : MonoBehaviour
{
    void OnTriggerExit2D(Collider2D collision) {
        if (!collision.CompareTag("Area")) {
            return;
        }

        Vector3 pos = GameManager.instance.player.transform.position;
        Vector3 myPos = transform.position;
        float diffX = Mathf.Abs(pos.x - myPos.x);
        float diffY = Mathf.Abs(pos.y - myPos.y);

        Vector3 playerDir = GameManager.instance.player.inputVec;
        float dirX = playerDir.x < 0 ? -1 : 1;
        float dirY = playerDir.y < 0 ? -1 : 1;

        switch (transform.tag){
            case "Ground":
                if (diffX > diffY) {
                    transform.Translate(Vector3.right * dirX * 40);
                } else if (diffX < diffY) {
                    transform.Translate(Vector3.up * dirY * 40);
                }
                break;

            case "Enemy":
                break;
        }
    }
}
