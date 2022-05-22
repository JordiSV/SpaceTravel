using System.Collections;
using System.Collections.Generic;
using UnityEngine;


using UnityEngine.InputSystem;

public class ReadInputExample : MonoBehaviour
{

    public PlayerInput inputManager;

    InputAction leftJoystick;
    InputAction button;

    bool leftJoystickPerformed = false;
    bool rightButtonPerformed = false;


    void Start()
    {

        inputManager = FindObjectOfType<PlayerInput>();

        leftJoystick = inputManager.actions["LeftJoystick"];
        button = inputManager.actions["ButtonExample"];

        leftJoystick.performed += context => {
            leftJoystickPerformed = true;
        };

        leftJoystick.canceled += context => {
            PlayerController.instance.propulsion /= 2;
            leftJoystickPerformed = false;
        };

        button.performed += context => {
            Debug.Log("button up");
            rightButtonPerformed = true;
        };

        button.canceled += context => {
            Debug.Log("button up");
            rightButtonPerformed = false;
        };


    }


    void Update()
    {

        if (leftJoystick.triggered)
        {
            Debug.Log("left stick value just changed!");
        }

        if (leftJoystickPerformed)
        {
            Debug.DrawLine(Vector2.zero, leftJoystick.ReadValue<Vector2>());
            PlayerController.instance.propulsion = leftJoystick.ReadValue<Vector2>();
        }
        else
        {
            //PlayerController.instance.slowDown();
        }

        if (rightButtonPerformed)
            Time.timeScale = 2;
        else
            Time.timeScale = 1;
        
    }
}
