using UnityEngine;
using UnityEngine.InputSystem;

public class MainCar : MonoBehaviour
{
    [SerializeField] Vector3 carOffset;
    public Vector3 CarOffset => carOffset;

    [SerializeField] float carSize, camSpeed;
    public float CarSize => carSize;
    [SerializeField] Vector3 camOffset;
    public Vector3 CamOffset => camOffset;

    [SerializeField] Vector3 W1, W2, W3, W4;
    [SerializeField] Rigidbody rb;
    [SerializeField] float accelerationForce, rotForce;

    public void CameraMovement(Camera cam)
    {
        cam.transform.position = Vector3.Lerp(cam.transform.position, transform.TransformPoint(camOffset), camSpeed * Time.deltaTime);
        cam.transform.LookAt(transform.position);
    }

    bool WheelCollide(Vector3 p1, Vector3 p2, Vector3 p3, Vector3 p4)
    {
        return true;
    }
    
    public void Move(PlayerInput input)
    {
        Vector2 move = input.actions["Move"].ReadValue<Vector2>();

        if (WheelCollide(transform.TransformPoint(W1), transform.TransformPoint(W2), transform.TransformPoint(W3),
                transform.TransformPoint(W4)))
        {
            rb.AddForce(move.y * Time.deltaTime * accelerationForce * transform.forward, ForceMode.Acceleration);
        }
        
        rb.MoveRotation(rb.rotation * Quaternion.Euler(0f, Time.deltaTime * rotForce * move.x, 0f));
    }
}