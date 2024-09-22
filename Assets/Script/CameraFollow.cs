using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 offset = new Vector3(-1f, 0f, -60f);
    private float smoothTime = 0.25f;
    private Vector3 velocity = Vector3.zero;

    [SerializeField] private Transform target;

    void Update()
    {
        if (target != null) // Kiểm tra nếu target không phải null
        {
            Vector3 targetPosition = target.position + offset; // Sửa lỗi: targetPosition được định nghĩa và tính toán đúng
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}
