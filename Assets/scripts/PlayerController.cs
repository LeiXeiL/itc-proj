using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject Camera;
    [SerializeField] private float speed, sens;

    private float hor, vert, MouseX, MouseY, angleX;

    void Update()
    {
        MouseX = Input.GetAxis("Mouse X") * sens;
        MouseY = Input.GetAxis("Mouse Y") * sens;

        angleX -= MouseY;
        angleX = Mathf.Clamp(angleX, -60, 60);
        Camera.transform.localRotation = Quaternion.Euler(angleX, 0, 0);
        transform.Rotate(new Vector3(0, MouseX, 0));
    }

    private void FixedUpdate()
    {
        hor = Input.GetAxis("Horizontal");
        vert = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * speed * vert);
        transform.Translate(Vector3.right * speed * hor);
    }
}
