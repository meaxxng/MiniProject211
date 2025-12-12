using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_TeleportButton : MonoBehaviour
{
    public int checkpointIndex; // ปุ่มนี้ส่งหมายเลขเช็คพ้อยต์

    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            // เซฟหมายเลขเช็คพ้อยต์ที่ต้องไป
            PlayerPrefs.SetInt("teleport_to_checkpoint", checkpointIndex);
            PlayerPrefs.Save();

            // โหลดซีนเกมเพลย์
            SceneManager.LoadScene("new");
        });
    }
}
