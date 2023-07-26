using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawMovement : MonoBehaviour
{
    [SerializeField] private float roateSpeed = 2f;
    void Update()
    {
        transform.Rotate(0, 0, roateSpeed * Time.deltaTime * 360);
    }
}
