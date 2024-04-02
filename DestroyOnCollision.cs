using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnCollision : MonoBehaviour
{
    public string targetTag = "Animal"; // กำหนด tag ของวัตถุที่ต้องการทำลาย
    public float destroyDelay = 0.2f; // กำหนดเวลาที่ต้องการรอก่อนที่จะทำลาย

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(targetTag))
        {
            StartCoroutine(DestroyAfterDelay(collision.gameObject)); // เรียกใช้ Coroutine เพื่อรอเวลาก่อนที่จะทำลาย
        }
    }

    IEnumerator DestroyAfterDelay(GameObject objToDestroy)
    {
        yield return new WaitForSeconds(destroyDelay); // รอเวลาตามที่กำหนด
        Destroy(objToDestroy); // ทำลายวัตถุ
    }
}