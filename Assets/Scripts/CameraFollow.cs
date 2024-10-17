using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float smoothTime = 0.3f;
    [SerializeField] private Transform target;
    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        if (target != null && (target.position.x < 34 || transform.position.x < 34) && (target.position.x > 0 || transform.position.x > 0 ))
        {
            Vector3 targetPosition = new Vector3(target.position.x, transform.position.y, transform.position.z);
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
        else if (transform.position.x < 0)
        {
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(0f,0f,-10f), ref velocity, smoothTime);
        }
        else if(transform.position.x > 34)
        {
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(34f,0f,-10f), ref velocity, smoothTime);
        }

    }
}
