using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent (typeof (PlayerInteraction))]
[RequireComponent (typeof(PlayerPhysics))]
[RequireComponent(typeof(PlayerLook))]
public class InputManager : MonoBehaviour
{
    public Camera camera;
    private PlayerControls PlayerControls;
    private PlayerControls.PlayerActions playerActions;
    private PlayerPhysics playerPhysics;
    private PlayerLook playerLook;
    private PlayerInteraction playerInteraction;
    // Start is called before the first frame update
    private void Awake()
    {
        PlayerControls = new PlayerControls();
        playerActions = PlayerControls.Player;
        playerInteraction = GetComponent<PlayerInteraction>();
        playerLook = GetComponent<PlayerLook>();
        playerPhysics = GetComponent<PlayerPhysics>();
        
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerPhysics.ProcessMove(playerActions.Move.ReadValue<Vector2>());
        playerLook.ProcessLook(playerActions.Look.ReadValue<Vector2>());

    }
    
    private void Update()
    {
        playerLook.ProcessLook(playerActions.Look.ReadValue<Vector2>());
        InteractionRay();
        PutDownCheck();
    }
    private void PutDownCheck() 
    {
        if (playerInteraction.isHolded && playerActions.Throw.triggered) { playerInteraction.PutDown(); Debug.Log("Throw"); }
    }

    public float interactionDistance = 10f;


    
    void InteractionRay()
    {
        Ray ray = camera.ViewportPointToRay(Vector3.one / 2f);
        RaycastHit hit;

        

        if (Physics.Raycast(ray, out hit, interactionDistance))
        {
            //Debug.Log(hit.collider.name);
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            if (interactable != null && playerActions.Interact.triggered)
            {
                
                interactable.Interact();
                playerInteraction.Hold(hit.collider.gameObject.transform);
                    
                

            }

        }
    }

    private void OnEnable()
    {
        playerActions.Enable();
    }
    private void OnDisable()
    {
        playerActions.Disable();
    }
}
