using UnityEngine;

public class UILookingAtCamera : MonoBehaviour
{
    [SerializeField] 
    private Camera gameCamera;
    private void LateUpdate()
    {
        transform.LookAt(transform.position + gameCamera.transform.rotation * Vector3.forward,gameCamera.transform.rotation * Vector3.up);
    }
}
