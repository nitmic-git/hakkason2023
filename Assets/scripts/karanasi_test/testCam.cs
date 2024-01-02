using UnityEngine;

public class testCam : MonoBehaviour
{
    public Transform target; // �J�������Ǐ]����Ώۂ�Transform
    public float smoothSpeed = 0.125f; // �J�����̈ړ��̃X���[�W���O
    [SerializeField] float xOffset;
    [SerializeField] float yOffset;

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = new Vector3(target.position.x-xOffset, target.position.y-yOffset, transform.position.z);
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = smoothedPosition;
        }
    }
}
