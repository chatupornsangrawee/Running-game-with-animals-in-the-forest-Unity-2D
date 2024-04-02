using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalCollisionHandler : MonoBehaviour

{
    // ประกาศตัวแปร GameObject ชื่อ panelToActivate
    public List<GameObject> panelsToActivate;

    // เมื่อมีการชนของวัตถุประสงค์
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ตรวจสอบว่าวัตถุประสงค์ที่ชนมี Tag เป็น "Animal" หรือไม่
        if (collision.gameObject.CompareTag("Animal"))
        {
            // ตรวจสอบว่ายังมี GameObject ที่ยังไม่ถูกเปิดใช้งานหรือไม่
            if (panelsToActivate.Count > 0)
            {
                // เลือกสุ่ม GameObject จาก List
                int randomIndex = Random.Range(0, panelsToActivate.Count);
                GameObject randomPanel = panelsToActivate[randomIndex];

                // เปิดใช้งาน GameObject ที่สุ่มได้
                randomPanel.SetActive(true);

                // ลบ GameObject ที่เลือกออกจาก List เพื่อไม่ให้สุ่มซ้ำ
                panelsToActivate.RemoveAt(randomIndex);
            }
        }
    }
}