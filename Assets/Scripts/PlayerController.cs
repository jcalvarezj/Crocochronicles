using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float jumpThreshold = 1.1f;
    public float jumpForce = 6f;
    public LayerMask groundMask;
    Rigidbody2D playerRigidbody;

    // Awake is called before start to prepare the game object
    void Awake() {
        playerRigidbody = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) {
            Jump();
        }
    }

    // Jump makes the player object jump
    void Jump() {
        if (IsTouchingGround()) {
            playerRigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    // IsTouchingGround indicates whether the player object is touching the ground (near enough)
    bool IsTouchingGround() {
        return Physics2D.Raycast(this.transform.position, Vector2.down, jumpThreshold, groundMask);
    }
}
