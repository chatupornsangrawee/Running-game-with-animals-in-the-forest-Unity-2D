using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOB : MonoBehaviour
{
    public GameObject objectToSpawn; // วัตถุที่ต้องการสร้าง
    public GameObject objectToSpawn2; // วัตถุที่ต้องการสร้าง

    public float spawnDistance = 0.4f; // ระยะห่างที่ต้องการสร้างวัตถุใหม่

    public void DestroyAndSpawnNewObject()
    {
        // หาวัตถุที่ใกล้ที่สุดที่มี TAG เป็น "Animal"
        GameObject[] animals = GameObject.FindGameObjectsWithTag("Animal");
        GameObject closestAnimal = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject animal in animals)
        {
            float distance = Vector3.Distance(animal.transform.position, transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestAnimal = animal;
            }
        }

        // ถ้าพบวัตถุที่ใกล้ที่สุด
        if (closestAnimal != null)
        {
            // ทำลายวัตถุที่ใกล้ที่สุด
            Destroy(closestAnimal);

            // สร้างวัตถุใหม่ 2 ตัว โดยอยู่ห่างจากกันด้วยระยะห่างที่กำหนด
            Vector3 spawnPosition1 = closestAnimal.transform.position + new Vector3(spawnDistance, 0f, 0f) * 1; // เพิ่มการคูณด้วย 3 เพื่อขยับไปทางแกน +X 3 หน่วย
            Vector3 spawnPosition2 = closestAnimal.transform.position - new Vector3(spawnDistance, 0f, 0f) * 4; // เพิ่มการคูณด้วย 3 เพื่อขยับไปทางแกน +X 3 หน่วย

            Debug.Log("Spawning at position 1: " + spawnPosition1);
            Debug.Log("Spawning at position 2: " + spawnPosition2);

            Instantiate(objectToSpawn, spawnPosition1, Quaternion.identity);
            Instantiate(objectToSpawn2, spawnPosition2, Quaternion.identity);
        }
        else
        {
            Debug.Log("No 'Animal' objects found.");
        }
    }
}
