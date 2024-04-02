using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopGameOnUse : MonoBehaviour
{
    public List<GameObject> targetObjects; // เปลี่ยนจาก GameObject เป็น List<GameObject> เพื่อรับค่าหลายตัว

    private float originalTimeScale;

    void Start()
    {
        originalTimeScale = Time.timeScale; // เก็บค่าเวลาตั้งต้น
    }

    void Update()
    {
        bool anyActive = false; // สร้างตัวแปรเพื่อตรวจสอบว่ามีออบเจกต์ใดที่ active หรือไม่

        foreach (GameObject targetObject in targetObjects)
        {
            // ตรวจสอบว่า targetObject ไม่เป็น null และ active
            if (targetObject != null && targetObject.activeSelf)
            {
                anyActive = true; // ถ้ามีออบเจกต์ใด active ก็เปลี่ยนค่าเป็น true
                break; // ออกจาก loop เพื่อประหยัดเวลา
            }
        }

        // ตรวจสอบว่ามีออบเจกต์ใด active หรือไม่
        if (anyActive)
        {
            // หยุดเวลา
            Time.timeScale = 0f;
        }
        else
        {
            // คืนค่าเวลาเป็นค่าเริ่มต้น
            Time.timeScale = originalTimeScale;
        }
    }

    void OnDestroy()
    {
        // เมื่อวัตถุถูกทำลาย คืนค่าเวลาเป็นค่าเริ่มต้น
        Time.timeScale = originalTimeScale;
    }
}
