
using UnityEngine;

public class ParralaxScene : MonoBehaviour
{
    [SerializeField] private float parallaxMultiplier;

    private Transform cameraTrasform;
    private Vector3 previousCameraPosition;
    void Start()
    {
        cameraTrasform = Camera.main.transform;
        previousCameraPosition = cameraTrasform.position;
    }

    void LateUpdate()
    {
        float deltaX = (cameraTrasform.position.x - previousCameraPosition.x) * parallaxMultiplier;
        transform.Translate(new Vector3(deltaX, 0, 0));
        previousCameraPosition = cameraTrasform.position;
    }
}
