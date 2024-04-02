using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObjectSpawner : MonoBehaviour
{
    public GameObject[] objectsToSpawn; // วัตถุที่ต้องการสุ่ม
    public Vector2[] spawnPositions; // ตำแหน่งที่ต้องการสุ่ม

    void Start()
    {
        SpawnObjectsAtRandomPositions();
    }

    void SpawnObjectsAtRandomPositions()
    {
        // ตรวจสอบว่ามีตำแหน่งเท่ากับหรือมากกว่าจำนวนวัตถุ
        if (spawnPositions.Length < objectsToSpawn.Length)
        {
            Debug.LogError("ไม่สามารถสร้างวัตถุได้ เนื่องจากจำนวนตำแหน่งน้อยกว่าจำนวนวัตถุที่ต้องการสร้าง");
            return;
        }

        // สุ่มตำแหน่งที่ใช้สร้างวัตถุ
        Vector2[] shuffledPositions = ShuffleArray(spawnPositions);
        
        // สร้างวัตถุที่แต่ละตำแหน่ง
        for (int i = 0; i < objectsToSpawn.Length; i++)
        {
            GameObject objectToSpawn = objectsToSpawn[i];
            Vector2 spawnPosition = shuffledPositions[i];
            Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
        }
    }

    // ฟังก์ชันสำหรับสลับอาร์เรย์
    Vector2[] ShuffleArray(Vector2[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            Vector2 temp = array[i];
            int randomIndex = Random.Range(i, array.Length);
            array[i] = array[randomIndex];
            array[randomIndex] = temp;
        }
        return array;
    }
}
