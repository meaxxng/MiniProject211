using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;          // Player ที่ตาม
    public float followSpeed = 10f;   // ความเร็วตาม
    public Vector3 offset = new Vector3(1f, 0f, 0f); // ระยะห่างจาก Player
    public float minDistance = 1f;    // ระยะห่างน้อยที่สุด
    public float maxDistance = 5f;    // ระยะห่างมากที่สุด (ถ้าไกลเกินนี้ จะ Teleport เข้ามาใกล้)

    void LateUpdate()
    {
        if (player == null) return;

        Vector3 targetPos = player.position + offset;
        Vector3 direction = targetPos - transform.position;
        float distance = direction.magnitude;

        // ถ้าไกลเกิน maxDistance → Teleport เข้ามาใกล้
        if (distance > maxDistance)
        {
            transform.position = targetPos - direction.normalized * minDistance;
            return;
        }

        // ถ้าไกลกว่าระยะห่างน้อยที่สุด → เคลื่อนที่เข้าหา Player
        if (distance > minDistance)
        {
            Vector3 move = direction.normalized * followSpeed * Time.deltaTime;
            // ไม่ให้ move เกินความห่างจริง
            if (move.magnitude > distance - minDistance)
                move = direction.normalized * (distance - minDistance);

            transform.position += move;
        }
    }
}
