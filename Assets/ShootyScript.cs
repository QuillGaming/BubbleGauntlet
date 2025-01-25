using UnityEngine;
using UnityEngine.InputSystem;
public class ShootyScript : MonoBehaviour
{

    InputAction moveAction;
    InputAction PewPewAction;
    Rigidbody rb;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        PewPewAction = InputSystem.actions.FindAction("PewPew");
    }

    void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveValue = moveAction.ReadValue<Vector2>();

        void OnMove2(InputValue value) {
            // moveInput = value.Get<Vector2>();
        }

        void onClick() {
            //projectile stuff here
        }

        if (PewPewAction.IsPressed()) {
            /*fire projectile (instantiate projectile and give movement
            vector based on mouse direction[position?])
            */
        }
    }
}
