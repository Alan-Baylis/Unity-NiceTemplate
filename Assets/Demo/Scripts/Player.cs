using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 0.1f;
    [SerializeField]
    private float _rotateSpeed = 1.5f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (Cursor.lockState != CursorLockMode.Locked && Input.GetMouseButtonDown(0))
            Cursor.lockState = CursorLockMode.Locked;

        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");

        if (Application.systemLanguage == SystemLanguage.French)
        {
            if (Input.GetKey(KeyCode.Q))
                h = -1;

            if (Input.GetKey(KeyCode.Z))
                v = 1;
        }

        transform.Translate(h * moveSpeed, 0, v * moveSpeed);

        transform.Rotate(0, Input.GetAxis("Mouse X") * _rotateSpeed, 0);
        Camera.main.transform.Rotate(-Input.GetAxis("Mouse Y") * _rotateSpeed, 0, 0);
    }
}
