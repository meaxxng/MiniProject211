using UnityEngine;

public class EscMenu : MonoBehaviour
{
    public GameObject menuPanel;
    private bool isOpen = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleMenu();
        }
    }

    void ToggleMenu()
    {
        isOpen = !isOpen;
        menuPanel.SetActive(isOpen);

        // หยุดเกมเมื่อเปิดเมนู (ถ้าไม่อยากหยุดเกมให้ลบได้)
        Time.timeScale = isOpen ? 0 : 1;

        // จัดการ Cursor
        if (isOpen)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }
}
