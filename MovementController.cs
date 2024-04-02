using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public Transform movingObject; // วัตถุที่ต้องการให้เคลื่อนที่

    private Transform player; // ผู้เล่น
    private Vector3 previousPosition;
    private bool isFacingRight = true;


    private float moveSpeed = 5f; // ความเร็วในการเคลื่อนที่
    public float movementRange = 10f; // ระยะที่ต้องการให้เคลื่อนที่ซ้ายขวา
    public float playerDetectionRange = 3f; // ระยะที่ต้องการให้พบผู้เล่น

    private bool moveRight = true; // ตัวแปรเพื่อแสดงการเคลื่อนที่ไปทางขวาขณะนี้

    void Start()
    {
        // ค้นหาวัตถุที่มี tag เป็น "Player" และกำหนดให้ตัวแปร player เท่ากับผลลัพธ์
        player = GameObject.FindGameObjectWithTag("Player").transform;
        previousPosition = transform.position;

    }

    void Update()
    {
        // หาความระยะห่างระหว่างวัตถุและผู้เล่น
        float distanceToPlayer = Vector3.Distance(movingObject.position, player.position);

        // ถ้าระยะห่างมากกว่าระยะที่ต้องการให้หยุดเคลื่อนที่
        if (distanceToPlayer > playerDetectionRange)
        {

        }
        else
        {
            // ถ้าอยู่ใกล้พอแล้ว ให้เคลื่อนที่ไปหาผู้เล่น
            movingObject.position = Vector3.MoveTowards(movingObject.position, player.position, moveSpeed * Time.deltaTime);
        }
            // เคลื่อนที่ตามแนวแกน X

            // Flip ภาพเมื่อผู้เล่นกดปุ่ม D
        // Flip วัตถุเมื่อมีการเคลื่อนที่ไปทางทิศทางบวก X
        // ตรวจสอบการเคลื่อนที่ของวัตถุ
        Vector3 currentPosition = transform.position;
        if (currentPosition.x > previousPosition.x && !isFacingRight)
        {
            // Flip ให้เข้าไปทางขวา
            FlipObject(true);
        }
        else if (currentPosition.x < previousPosition.x && isFacingRight)
        {
            // Flip ให้เข้าไปทางซ้าย
            FlipObject(false);
        }
        previousPosition = currentPosition;
    }
    void FlipObject(bool faceRight)
    {
        // หมุนวัตถุ 180 องศาเพื่อทำ Flip
        transform.Rotate(0f, 180f, 0f);

        // อัพเดทสถานะที่วัตถุกำลังเผชิญหน้าไปทางขวาหรือซ้าย
        isFacingRight = faceRight;
    }
}
