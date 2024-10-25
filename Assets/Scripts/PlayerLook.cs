using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public GameObject camera;
    private float rotationX = 0f;
    [SerializeField] private float sensitivity = 1f;
    // Start is called before the first frame update
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void ProcessLook(Vector2 input) 
    {
        float mouseX = input.x * Time.deltaTime * sensitivity;
        float mouseY = input.y * Time.deltaTime * sensitivity;

        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);
        

        camera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        


        transform.Rotate(Vector3.up * mouseX);
        
    }
}
