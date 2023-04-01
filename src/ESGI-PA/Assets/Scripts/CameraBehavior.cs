using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    private static Transform target;
    [SerializeField] private Transform camera;

    [SerializeField] private Vector3 offset, position;

    [SerializeField] private float cameraSpeed, lerpSpeed;
    // Start is called before the first frame update
    void Start()
    {
        camera.position = target.position + offset;
        camera.LookAt(target);
        camera.rotation = Quaternion.Slerp(camera.rotation, target.rotation, cameraSpeed);
    }

    /*private void FixedUpdate()
    {
        //if (Physics.Raycast(camera.position, -camera.up, 2f)) offset.y = 1;
    }*/

    private void Update()
    {
        position = Vector3.Lerp(position, target.position + (target.forward * offset.z) + Vector3.up * offset.y, lerpSpeed * Time.deltaTime);
        camera.rotation = Quaternion.Lerp(camera.rotation, Quaternion.LookRotation(target.position - camera.position), lerpSpeed * Time.deltaTime);
        
        if (Physics.Raycast(target.position, position - target.position,
                out RaycastHit hit, Vector3.Distance(position, target.position)))
            camera.position = Vector3.Lerp(hit.point, target.position, 0.2f);
        else
            camera.position = position;
    }

    public static void setTarget(Transform obj)
    {
        target = obj;
    }
    // transform.position = target.position;
    //     
    // Vector2 look = input.actions["Look"].ReadValue<Vector2>();
    //     
    // transform.Rotate(Vector3.up, look.x * sensi * Time.deltaTime);
    //
    // rotX -= look.y * sensi * Time.deltaTime;
    //
    // if (rotX > maxX) rotX = maxX;
    // else if (rotX < -maxX) rotX = -maxX;
    //     
    // rotatorX.localRotation = Quaternion.Euler(rotX, 0, 0);
}
