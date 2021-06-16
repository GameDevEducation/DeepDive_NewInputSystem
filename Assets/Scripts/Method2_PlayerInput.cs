using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Method2_PlayerInput : MonoBehaviour
{
    [SerializeField] float MovementSpeed = 2f;
    [SerializeField] InputAction JumpAction; // input actions can be used for standalone reading of input
    
    Vector2 CachedMove = Vector2.zero;

    // Used for SendMessage mode
    void OnMove(InputValue value)
    {
        CachedMove = value.Get<Vector2>();

        //Debug.Log("Move " + value.Get<Vector2>());
    }

    // Used for SendMessage mode
    void OnFire(InputValue value)
    {
        //Debug.Log("Fire + " + value.isPressed);
    }

    public void OnMove_EventMode(InputAction.CallbackContext context)
    {
        CachedMove = context.ReadValue<Vector2>();

        Gamepad.current.SetMotorSpeeds(Mathf.Abs(CachedMove.x), Mathf.Abs(CachedMove.y));
    }

    public void OnFire_EventMode(InputAction.CallbackContext context)
    {
        Debug.Log("Fire: " + context.ReadValueAsButton());
    }

    public void OnDeviceLost_EventMode(PlayerInput associatedInput)
    {
        Debug.Log("Lost");
    }

    public void OnDeviceRegained_EventMode(PlayerInput associatedInput)
    {
        Debug.Log("Gained");
    }

    public void OnControlsChanged_EventMode(PlayerInput associatedInput)
    {
        Debug.Log(associatedInput.currentControlScheme);
    }

    void OnJumpActionPerformed(InputAction.CallbackContext context)
    {
        Debug.Log("Jump: " + context.ReadValueAsButton());
    }

    // Start is called before the first frame update
    void Start()
    {
        // bind the jump action to OnJumpActionPerformed
        JumpAction.performed += OnJumpActionPerformed;

        // enable the jump action
        JumpAction.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 desiredMovement = CachedMove.y * transform.forward + CachedMove.x * transform.right;

        transform.position += desiredMovement * MovementSpeed * Time.deltaTime;
    }
}
