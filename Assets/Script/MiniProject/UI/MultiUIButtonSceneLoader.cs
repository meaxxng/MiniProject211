using UnityEngine;
using UnityEngine.SceneManagement;

public class MultiUIButtonSceneLoader : MonoBehaviour
{
    /// <summary>
    /// ฟังก์ชันนี้เรียกเมื่อกดปุ่ม
    /// ใส่ชื่อ Scene ที่ต้องการโหลดใน Inspector ของปุ่มแต่ละอัน
    /// </summary>
    /// <param name="sceneName">ชื่อ Scene ที่จะโหลด</param>
    public void LoadScene(string sceneName)
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
            Debug.Log($"เปลี่ยนไปยัง Scene: {sceneName}");
        }
        else
        {
            Debug.LogWarning("ยังไม่ได้ตั้งชื่อ Scene!");
        }
    }
}
