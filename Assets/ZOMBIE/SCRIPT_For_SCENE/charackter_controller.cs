using UnityEngine;

public class charackter_controller : MonoBehaviour
{
    public float speed = 3.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, speed, 0);
    }
}
