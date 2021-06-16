using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Method1_Polled : MonoBehaviour
{
    [SerializeField] float MovementSpeed = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 desiredMovement = Vector3.zero;

        // update for forwards/backwards
        if (Keyboard.current.wKey.isPressed)
            desiredMovement += transform.forward;
        else if (Keyboard.current.sKey.isPressed)
            desiredMovement -= transform.forward;

        // update for left/right
        if (Keyboard.current.dKey.isPressed)
            desiredMovement += transform.right;
        else if (Keyboard.current.aKey.isPressed)
            desiredMovement -= transform.right;

        transform.position += desiredMovement * MovementSpeed * Time.deltaTime;
    }
}
