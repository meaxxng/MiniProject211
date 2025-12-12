using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public Transform target;           // ตัวละคร
    public Vector3 offset = new Vector3(0, 2, -5); // ระยะห่างกล้อง
    public float smoothSpeed = 0.125f;
    public float mouseSensitivity = 5f;

    private float yaw = 0f;   // หมุนแนวซ้ายขวา
    private float pitch = 20f; // หมุนแนวขึ้นลง

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // ซ่อนและล็อกเคอร์เซอร์
    }

    void LateUpdate()
    {
        if (target == null) return;

        // รับ Input เมาส์
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        yaw += mouseX;
        pitch -= mouseY;
        pitch = Mathf.Clamp(pitch, -30f, 60f); // ป้องกันหมุนเกิน

        // หมุนรอบตัวละคร
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);

        // ตำแหน่งกล้อง
        Vector3 desiredPosition = target.position + rotation * offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        transform.position = smoothedPosition;
        transform.LookAt(target.position + Vector3.up * 1.5f); // มองที่หัวตัวละคร
    }
}
