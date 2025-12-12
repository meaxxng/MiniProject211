using TMPro;
using UnityEngine;
using UnityEngine.UI;

// ��˹������ sealed ���ͻ�ͧ�ѹ����׺�ʹ
public class GameManager : MonoBehaviour
{
    // 1. Private Static Field (The Singleton Instance)
    // �� backing field ���ͤǺ��������Ҷ֧

    // 2. Public Static Property (Global Access Point)
   
    [Header("Game State")]
    public int currentScore = 0;
    public bool isGamePaused = false;

    [Header("UI Game")]
    public GameObject pauseMenuUI;
    public TMP_Text scoreText;
    public Slider HPBar;

    // 3. Private Constructor Logic (�� Awake() ᷹ Constructor ����� Unity)
    private void Awake()
    {
        // ��Ǩ�ͺ����� Instance ���������������
       
    }

    // ------------------- Singleton Functionality -------------------

    public void UpdateHealthBar(int currentHealth, int maxHealth)
    {
       
    }
    public void AddScore(int amount)
    {
        
    }

    public void TogglePause()
    {
       
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }
}