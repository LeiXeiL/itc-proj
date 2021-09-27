using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject Camera;
    [SerializeField] private float sens;

    private float hor, vert, MouseX, MouseY, angleX, speed;

    private void Start()
    {
        speed = 6;
    }

    void Update()
    {
        MouseX = Input.GetAxis("Mouse X") * sens;
        MouseY = Input.GetAxis("Mouse Y") * sens;

        angleX -= MouseY;
        angleX = Mathf.Clamp(angleX, -60, 60);
        Camera.transform.localRotation = Quaternion.Euler(angleX, 0, 0);
        transform.Rotate(new Vector3(0, MouseX, 0));

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = 12;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 6;
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            transform.localScale = new Vector3(.5f, .5f, .5f);
        }
        if (Input.GetKeyUp(KeyCode.LeftControl))
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    private void FixedUpdate()
    {
        hor = Input.GetAxis("Horizontal");
        vert = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward * speed * vert * Time.deltaTime);
        transform.Translate(Vector3.right * speed * hor * Time.deltaTime);
    }
}
