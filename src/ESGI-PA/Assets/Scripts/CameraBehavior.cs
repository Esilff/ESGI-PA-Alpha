using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    private static Transform target;
    public static bool inCar;
    [SerializeField] private Transform camera;

    [SerializeField] private Vector3 defaultOffset;
    [SerializeField] private Vector3 hoodOffset = new Vector3(0, 0.5f, 0.5f); // Pour la caméra capot (FPS)
    [SerializeField] private Vector3 rearOffset = new Vector3(0, 0.5f, -8f); // Pour la caméra arrière

    private Vector3 offset, position;

    [SerializeField] private float cameraSpeed, lerpSpeed;
    [SerializeField] [Range(0f, 1f)] float near;

    private enum CameraMode { Default, Hood, Rear }
    private CameraMode cameraMode = CameraMode.Default;

    void Start()
    {
        camera.position = target.position + offset;
        camera.LookAt(target);
        camera.rotation = Quaternion.Slerp(camera.rotation, target.rotation, cameraSpeed);

        // Initialize camera offsets
        defaultOffset = offset;
    }

    private void Update()
    {
        if (inCar) MoveCamera();

        if (Input.GetKeyDown(KeyCode.X))
        {
            switch (cameraMode)
            {
                case CameraMode.Default:
                    cameraMode = CameraMode.Hood;
                    offset = hoodOffset;
                    break;
                case CameraMode.Hood:
                    cameraMode = CameraMode.Rear;
                    offset = rearOffset;
                    break;
                case CameraMode.Rear:
                    cameraMode = CameraMode.Default;
                    offset = defaultOffset;
                    break;
            }
        }
    }

    private void FixedUpdate()
    {
        if (!inCar) MoveCamera();
    }

    private void MoveCamera()
    {
        position = Vector3.Lerp(position, target.position + (target.forward * offset.z) + Vector3.up * offset.y, lerpSpeed * Time.deltaTime);
        camera.rotation = Quaternion.Lerp(camera.rotation, Quaternion.LookRotation(target.position - camera.position), lerpSpeed * Time.deltaTime);

        if (Physics.Raycast(target.position, position - target.position,
                out RaycastHit hit, Vector3.Distance(position, target.position)))
            camera.position = Vector3.Lerp(hit.point, target.position, near);
        else
            camera.position = position;
    }

    public static void setTarget(Transform obj)
    {
        target = obj;
    }
}
