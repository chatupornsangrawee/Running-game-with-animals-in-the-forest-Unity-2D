using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeBar : MonoBehaviour
{
    public Transform fillBar;
    public static float currentHealth; // ทำให้เป็น static

    public float maxHealth = 1f; // เพิ่มตัวแปรสำหรับเก็บค่าเลือดสูงสุด
    public float decreaseRate; 
    public static TimeBar instance;
    public string sceneToLoad; 

    void Start()
    {
        currentHealth = maxHealth; // กำหนดค่าเริ่มต้นของเลือดเป็นค่าสูงสุด
        decreaseRate = 0.02f; 
        InvokeRepeating("DecreaseHealth", 5f, 5f); 
    }

    private void Awake()
    {
        MakeInstance();
    }

    void MakeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void DecreaseHealth()
    {
        currentHealth -= decreaseRate; 

        if (currentHealth <= 0)
        {
            SceneManager.LoadScene(sceneToLoad);
        }

        UpdateHealthBar(); // เรียกใช้งานฟังก์ชันอัปเดตแถบเลือด
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("HP"))
        {
            currentHealth = Mathf.Min(currentHealth + 0.2f, maxHealth); // เพิ่มเลือดโดยไม่เกินค่าสูงสุด
            Destroy(other.gameObject);
            UpdateHealthBar(); // เรียกใช้งานฟังก์ชันอัปเดตแถบเลือด
        }
    }

    public void ReduceHealthInstantly()
    {
        float healthToDecrease = 0.2f;
        currentHealth = Mathf.Max(currentHealth - healthToDecrease, 0f); // ลดเลือดโดยไม่ต่ำกว่า 0
        UpdateHealthBar(); // เรียกใช้งานฟังก์ชันอัปเดตแถบเลือด
    }

    void UpdateHealthBar()
    {
        fillBar.GetComponent<Image>().fillAmount = currentHealth / maxHealth; // ปรับค่า fill amount ของแถบเลือดตามเลือดปัจจุบัน
    }

    public void OnButtonClicked()
    {
        // ทำการลดเลือดทันทีเมื่อคลิกปุ่ม
        ReduceHealthInstantly();
    }
}
