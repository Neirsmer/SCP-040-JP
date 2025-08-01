using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public enum RotationAxes 
    { 
        MouseXAndY = 0,
        MouseX = 1, MouseY = 2
    }
   public RotationAxes axes = RotationAxes.MouseXAndY;
   public float sensitivetyHor = 9.0f;
   public float sensitivetyVert = 9.0f;
    public float minimumVert = -45.0f;
    public float maximumVert = 45.0f;
    private float _rotationX = 0;
    // Update is called once per frame

    void Start()
    {

        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null)
            body.freezeRotation = true;
    }





    void Update()
    {
        if (axes == RotationAxes.MouseX)
        {
            transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivetyHor, 0);
        }
        else if (axes == RotationAxes.MouseY) 
        { 
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivetyVert;
            _rotationX =Mathf.Clamp(_rotationX, minimumVert, maximumVert);
            float rotationY = transform.localEulerAngles.y;
            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
        else
        {
            _rotationX -= Input.GetAxis("Mouse Y") * sensitivetyVert;
            _rotationX = Mathf.Clamp(_rotationX, minimumVert, maximumVert);

            float delta = Input.GetAxis("Mouse X") * sensitivetyHor;
            float rotationY = transform.localEulerAngles.y + delta;
            transform.localEulerAngles = new Vector3(_rotationX, rotationY, 0);
        }
    }
}
