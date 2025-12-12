using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public Transform[] checkpoints;
    public Transform startPoint;      // จุดเริ่มต้นเกม (ตั้งใน Inspector)

    public int maxFallCount = 3;      // ตกได้ 3 ครั้ง
    private int fallCount = 0;

    private Player player;            // ใช้เพื่อหัก gem

    void Start()
    {
        player = GetComponent<Player>();

        // กำหนดตำแหน่งเริ่มต้น ถ้ายังไม่ได้ใส่ใน Inspector
        if (startPoint == null)
        {
            GameObject sp = new GameObject("StartPoint");
            sp.transform.position = transform.position;
            startPoint = sp.transform;
        }

        // ระบบเทเลพอร์ตตาม UI
        int selectedCP = PlayerPrefs.GetInt("teleport_to_checkpoint", -1);

        if (selectedCP >= 0 && selectedCP < checkpoints.Length)
        {
            transform.position = checkpoints[selectedCP].position;
        }
        else
        {
            int last = PlayerPrefs.GetInt("last_checkpoint", 0);
            transform.position = checkpoints[last].position;
        }
    }

    public void SaveLastCheckpoint(int id)
    {
        PlayerPrefs.SetInt("last_checkpoint", id);
        PlayerPrefs.Save();
    }

    public void RespawnLastCheckpoint()
    {
        int id = PlayerPrefs.GetInt("last_checkpoint", 0);
        transform.position = checkpoints[id].position;
    }

    public void RespawnStartPoint()
    {
        transform.position = startPoint.position;
        Debug.Log("กลับไปเกิดที่จุดเริ่มต้น");
    }

    void Update()
    {
        // ตรวจว่าตกแมพ
        if (transform.position.y < -10f)
        {
            HandleFall();
        }
    }
    public void TeleportTo(Vector3 pos)
    {
        transform.position = pos;
    }

    void HandleFall()
    {
        fallCount++;
        Debug.Log("ตกครั้งที่: " + fallCount);

        // ตกไม่ครบ 3 ครั้ง → กลับเช็คพ้อยล่าสุด
        if (fallCount < maxFallCount)
        {
            RespawnLastCheckpoint();
            return;
        }

        // ตกครบ 3 ครั้งแล้ว → ครั้งถัดไปคือครั้งที่ 4
        // เช็คว่าจะใช้ Gem ได้ไหม
        bool usedGem = false;

        if (player != null && player.wallet != null)
            usedGem = player.wallet.Use(CurrencyType.GEM, 5);

        if (usedGem)
        {
            // ใช้ gem ได้ → รีเซ็ต counter และกลับเช็คพ้อย
            Debug.Log("ใช้ Gem 5 อัน → ต่อชีวิตที่เช็คพ้อย!");
            fallCount = 0;
            RespawnLastCheckpoint();
        }
        else
        {
            // ใช้ gem ไม่ได้ → กลับไปจุดเริ่มต้น
            Debug.Log("Gem ไม่พอ → กลับไปจุดเริ่มต้น");
            fallCount = 0;
            RespawnStartPoint();
        }
    }

}
