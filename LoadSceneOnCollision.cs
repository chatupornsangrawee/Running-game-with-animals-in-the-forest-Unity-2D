using UnityEngine;
using System.Collections;

public class LoadSceneOnCollision : MonoBehaviour
{
    public string tagToCheck; // กำหนด Tag ที่คุณต้องการให้ตรวจสอบ
    public string sceneToLoad; // กำหนดชื่อฉากที่คุณต้องการโหลด

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(tagToCheck))
        {
            // ตรวจสอบว่ามีวัตถุที่มี Tag เป็น "ST" อยู่ 3 อันหรือไม่
            GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("ST");
            if (objectsWithTag.Length >= 3)
            {
                // โหลดฉากเมื่อผู้เล่นชนวัตถุที่มี Tag ที่กำหนด
                UnityEngine.SceneManagement.SceneManager.LoadScene(sceneToLoad);
            }
            else
            {
                Debug.Log("ต้องมีวัตถุที่มี Tag เป็น 'ST' อยู่ 3 อันในฉาก");
            }
        }
    }
}
