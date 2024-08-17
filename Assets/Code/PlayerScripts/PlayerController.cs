using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMouvements : MonoBehaviour
{
    public float speed;
    private Vector2 move;

    public float xMin, xMax, zMin, zMax; // Define min and max values for x and z

    public void OnMove(InputAction.CallbackContext context) {
        move = context.ReadValue<Vector2>();
    }

    void Start()
    {
        // Initialization if needed
    }

    void Update()
    {
        movePlayer();   
    }

    public void movePlayer() {
        Vector3 mouvement = new Vector3(move.x, 0f, move.y);
        if (mouvement != Vector3.zero) {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(mouvement), 0.15f);
            Vector3 newPosition = transform.position + mouvement * speed * Time.deltaTime;

            // Clamp the new position
            newPosition.x = Mathf.Clamp(newPosition.x, xMin, xMax);
            newPosition.z = Mathf.Clamp(newPosition.z, zMin, zMax);

            transform.position = newPosition;
        }
    }
}
