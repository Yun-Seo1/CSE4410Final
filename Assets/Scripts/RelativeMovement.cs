﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 3rd-person movement that picks direction relative to target (usually the camera)
// commented lines demonstrate snap to direction and without ground raycast
//
// To setup animated character create an animation controller with states for idle, running, jumping
// transition between idle and running based on added Speed float, set those not atomic so that they can be overridden by...
// transition both idle and running to jump based on added Jumping boolean, transition back to idle

[RequireComponent(typeof(CharacterController))]
public class RelativeMovement : MonoBehaviour {
	[SerializeField] Transform target;
	
	public float moveSpeed = 6.0f;
	public float rotSpeed = 15.0f;
	public float jumpSpeed = 15.0f;
	public float gravity = -9.8f;
	public float terminalVelocity = -20.0f;
	public float minFall = -1.5f;

	public float PushForce = 3.5f;


	private float vertSpeed;
	private ControllerColliderHit contact;

	private CharacterController charController;
	private Animator animator;

	// Use this for initialization
	void Start() {
		vertSpeed = minFall;

		charController = GetComponent<CharacterController>();
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update() {

		// start with zero and add movement components progressively
		Vector3 movement = Vector3.zero;

		float horInput = Input.GetAxis("Horizontal");
		float vertInput = Input.GetAxis("Vertical");

        bool isMoving = horInput != 0 || vertInput != 0;
        if (isMoving)
        {
            // Walking logic
            if (!AudioManager.Instance.IsPlayingWalkSound())
            {
                AudioManager.Instance.PlayWalkSound("PlayerWalking");
            }
        }
        else
        {
            AudioManager.Instance.StopWalkSound();
        }
        if (horInput != 0 || vertInput != 0) {

			// x z movement transformed relative to target
			Vector3 right = target.right;
			Vector3 forward = Vector3.Cross(right, Vector3.up);
			movement = (right * horInput) + (forward * vertInput);
			movement *= moveSpeed;
			movement = Vector3.ClampMagnitude(movement, moveSpeed);

			// face movement direction
			//transform.rotation = Quaternion.LookRotation(movement); // to face immediately
			Quaternion direction = Quaternion.LookRotation(movement);
			transform.rotation = Quaternion.Lerp(transform.rotation,
			                                     direction, rotSpeed * Time.deltaTime);
		}
		animator.SetFloat("Speed", movement.sqrMagnitude);

		// raycast down to address steep slopes and dropoff edge
		bool hitGround = false;
		RaycastHit hit;
		if (vertSpeed < 0 && Physics.Raycast(transform.position, Vector3.down, out hit)) {
			float check = (charController.height + charController.radius) / 1.9f;
			hitGround = hit.distance <= check;	// to be sure check slightly beyond bottom of capsule
		}

		// y movement: possibly jump impulse up, always accel down
		// could _charController.isGrounded instead, but then cannot workaround dropoff edge
		if (hitGround) {
			if (Input.GetButtonDown("Jump")) {
                AudioManager.Instance.PlayJumpSound(transform.position);
                vertSpeed = jumpSpeed;
			} else {
				vertSpeed = minFall;
				animator.SetBool("Jumping", false);
			}
		} else {
			vertSpeed += gravity * 5 * Time.deltaTime;
			if (vertSpeed < terminalVelocity) {
				vertSpeed = terminalVelocity;
			}
			if (contact != null ) {	// not right at level start
				animator.SetBool("Jumping", true);
			}

			// workaround for standing on dropoff edge
			if (charController.isGrounded) {
				if (Vector3.Dot(movement, contact.normal) < 0) {
					movement = contact.normal * moveSpeed;
				} else {
					movement += contact.normal * moveSpeed;
				}
			}
		}
		movement.y = vertSpeed;

		movement *= Time.deltaTime;
		charController.Move(movement);
	}

	// store collision to use in Update
	void OnControllerColliderHit(ControllerColliderHit hit) {
		contact = hit;

		Rigidbody Body = hit.collider.attachedRigidbody;
		if (Body != null && !Body.isKinematic)
		{
			Body.velocity = hit.moveDirection * PushForce;
		}
	}
}
