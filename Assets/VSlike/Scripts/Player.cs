using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    public float speed;
    Animator anim;

    Rigidbody2D rb;
    SpriteRenderer sr;
    void Awake() {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void FixedUpdate() {
        Vector2 nextVec = inputVec.normalized * speed * Time.deltaTime;
        rb.MovePosition(rb.position + nextVec);
    }

    void OnMove(InputValue value) {
        inputVec = value.Get<Vector2>();
    }

    void LateUpdate() {
        anim.SetFloat("Speed", inputVec.magnitude);

        if (inputVec.x != 0) {
            sr.flipX = inputVec.x < 0;
        }
    }
}