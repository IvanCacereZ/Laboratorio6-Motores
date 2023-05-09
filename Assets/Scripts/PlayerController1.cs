using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class PlayerController1 : MonoBehaviour
{
    //Player ID
    private int playerID;

    [Header("Sub Behaviours")]
    public PlayerController playerMovementBehaviour;


    [Header("Input Settings")]
    public PlayerInput playerInput;
    public float movementSmoothingSpeed = 1f;
    private Vector3 rawInputMovement;
    private Vector2 smoothInputMovement;

    //Action Maps
    private string actionMapPlayerControls = "Player Controls";
    private string actionMapMenuControls = "Menu Controls";

    //Current Control Scheme
    private string currentControlScheme;
    void Update()
    {
        CalculateMovementInputSmoothing();
        UpdatePlayerMovement();
    }
    void CalculateMovementInputSmoothing()
    {

        smoothInputMovement = Vector3.Lerp(smoothInputMovement, rawInputMovement, Time.deltaTime * movementSmoothingSpeed);

    }
    void UpdatePlayerMovement()
    {
        playerMovementBehaviour.UpdateMovement(smoothInputMovement);
    }
    public void OnMovement(InputAction.CallbackContext value)
    {
        Vector2 inputMovement = value.ReadValue<Vector2>();
        rawInputMovement = new Vector2(inputMovement.x, inputMovement.y);
    }
}