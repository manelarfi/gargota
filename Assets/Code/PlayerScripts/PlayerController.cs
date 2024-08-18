using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMouvements : MonoBehaviour
{
    public Animator animator;
    public float speed;
    private Vector2 move;
    public void OnMove(InputAction.CallbackContext context) {
        move = context.ReadValue<Vector2>();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();   
    }

    public void movePlayer() {
        Vector3 mouvement = new Vector3(move.x, 0f, move.y);
        if (mouvement != Vector3.zero) {
            animator.SetBool("isWalking", true);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(mouvement), 0.15f);
            transform.Translate(mouvement * speed * Time.deltaTime, Space.World);
        } else {
            animator.SetBool("isWalking", false);
        }
    }
}
