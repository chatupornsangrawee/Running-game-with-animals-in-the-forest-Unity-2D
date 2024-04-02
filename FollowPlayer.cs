using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float followSpeed = 5.0f;
    public float followDistance = 2.0f;

    private Transform player;
    private bool isFollowing = false;
    private bool hasCollided = false; // เพิ่มตัวแปรเพื่อเก็บสถานะว่าได้ถูกสร้างไปแล้วหรือไม่

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (isFollowing)
        {
            // คำนวณตำแหน่งเป้าหมาย
            Vector3 targetPosition = player.position + (-player.forward * followDistance);

            // เคลื่อนที่ไปยังตำแหน่งเป้าหมาย
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, followSpeed * Time.deltaTime);

            // หมุนหน้าไปทางผู้เล่น
            transform.LookAt(player);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Animal" && !hasCollided)
        {
            Debug.Log("Collision with animal detected.");
            hasCollided = true;

            // ตรวจสอบว่ายังไม่มีวัตถุที่ถูกสร้างไปแล้ว
            if(GameObject.FindGameObjectWithTag("NEW") == null)
            {
                // สร้างวัตถุใหม่
                GameObject newAnimal = Instantiate(collision.gameObject, transform.position, Quaternion.identity);

                if (newAnimal == null)
                {
                    Debug.LogError("Failed to instantiate new animal.");
                    return;
                }



                // เปลี่ยนแปลง Tag ของวัตถุใหม่
                newAnimal.tag = "NEW";

                Debug.Log("New animal instantiated.");

                // เรียกใช้งานคอมโพเนนต์ FollowPlayer จากวัตถุใหม่ที่สร้างขึ้นมา
                FollowPlayer followPlayer = newAnimal.AddComponent<FollowPlayer>();

                if (followPlayer == null)
                {
                    Debug.LogError("Failed to add FollowPlayer component to new animal.");
                    return;
                }

                followPlayer.isFollowing = true;
                Debug.Log("New animal is set to follow the player.");
            }
        }
    }
}
