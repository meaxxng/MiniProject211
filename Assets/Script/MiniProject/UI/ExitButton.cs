using UnityEngine;

public class ExitButton : MonoBehaviour
{
    // ฟังก์ชันให้ปุ่มเรียก
    public void ExitGame()
    {
#if UNITY_EDITOR
        // ถ้าเล่นใน Editor → หยุด Play Mode
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // ถ้าเป็น Build จริง → ปิดโปรแกรม
        Application.Quit();
#endif
    }
}
