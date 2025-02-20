using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;  // ���� �÷��̾�
    public Vector2 minBounds; // ���� �ּ� X, Y �� (���� ���� �ϴ�)
    public Vector2 maxBounds; // ���� �ִ� X, Y �� (���� ������ ���)

    void LateUpdate()
    {
        if (player != null)
        {
            // ī�޶��� ���ο� ��ġ ���
            float clampedX = Mathf.Clamp(player.position.x, minBounds.x, maxBounds.x);
            float clampedY = Mathf.Clamp(player.position.y, minBounds.y, maxBounds.y);

            transform.position = new Vector3(clampedX, clampedY, transform.position.z);
        }
    }
}
