using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyObjectOnClick : MonoBehaviour
{
    // ตัวแปร GameObject ที่จะทำลาย
    public GameObject objectToDestroy;

    private void Start()
    {
        // ตรวจสอบว่า objectToDestroy ถูกกำหนดหรือยัง
        if (objectToDestroy == null)
        {
            Debug.LogError("โปรดกำหนดวัตถุที่ต้องการทำลายในตัวแปร objectToDestroy");
        }
    }

    public void OnDestroyButtonClick()
    {
        // ตรวจสอบว่า objectToDestroy ถูกกำหนดหรือยัง
        if (objectToDestroy != null)
        {
            // ทำลายวัตถุที่กำหนด
            Destroy(objectToDestroy);
        }
        else
        {
            Debug.LogError("ไม่พบวัตถุที่ต้องการทำลาย");
        }
    }












    
}