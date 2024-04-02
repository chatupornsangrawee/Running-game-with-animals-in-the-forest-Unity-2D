using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour
{
    public GameObject[] stars; // เก็บวัตถุทั้ง 3 ที่จะเปิดใช้งาน
    private int collectedStars = 0; // จำนวน Star ที่เก็บได้

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Star"))
        {
            collectedStars++; // เพิ่มจำนวน Star ที่เก็บได้
            if (collectedStars <= stars.Length)
            {
                stars[collectedStars - 1].SetActive(true); // เปิดใช้งานวัตถุที่ถูกเก็บ Star
            }
            Destroy(other.gameObject); // ทำลายวัตถุที่ถูกเก็บไป
        }
    }
}