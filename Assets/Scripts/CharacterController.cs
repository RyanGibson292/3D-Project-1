using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour {
    private Rigidbody rigidBody;
    private Animator animator;

    void Start() {
        rigidBody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update() {
        OldMovement();
    }

    private void NewMovement() {
        float moveSpeed = 25f;
        float rotationSpeed = 25f;
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = (transform.forward * moveVertical) * (moveSpeed * 100f) * Time.fixedDeltaTime;
        rigidBody.AddForce(movement * -1f);
        transform.Rotate((transform.up * moveHorizontal) * rotationSpeed * Time.fixedDeltaTime);
    }

    private void OldMovement() {
        float moveHorizontal = moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rigidBody.AddForce(new Vector3(-moveVertical, 0.0f, moveHorizontal) * 10);
        if (moveHorizontal != 0 || moveVertical != 0) {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.005F);
        } 

        if(Input.GetKey("space")) {
            rigidBody.AddForce(new Vector3(0, 10f, 0));
        }

        if(Input.GetKey("e")) {
            animator.SetBool("ePressed", true);
        } else {
            animator.SetBool("ePressed", false);
        }
    }
}
