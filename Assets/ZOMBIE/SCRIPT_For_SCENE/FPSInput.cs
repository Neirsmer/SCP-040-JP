using System.Threading;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPSInput")]

public class FPSInput : MonoBehaviour
{
    private CharacterController _charController;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _charController = GetComponent<CharacterController>();
    }
    public float speed = 6.0f;
    public float gravity = -9.8f;
    // Update is called once per frame
    void Update()
    {
        
        float deltaX = Input.GetAxis ("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        //transform.Translate(deltaX *Time.deltaTime, 0, deltaZ*Time.deltaTime);

        Vector3 movement = new Vector3 (deltaX,0,deltaZ);
        movement =Vector3.ClampMagnitude(movement,speed);
        movement.y = gravity;
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        _charController.Move(movement);
    }
}
