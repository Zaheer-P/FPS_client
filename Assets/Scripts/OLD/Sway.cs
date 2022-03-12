using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sway : MonoBehaviour
{
    public float smooth = 5f;
    float factorY;


    // Update is called once per frame
    void Update()
    {
        UpdateSway();
    }

    private void UpdateSway()
    {

        factorY += Input.GetAxis("Mouse Y") * smooth;
        Quaternion TargetRotation = Quaternion.Euler(-factorY, 0, 0);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, TargetRotation, Time.deltaTime * smooth);
    }
}
