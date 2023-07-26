using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    [SerializeField] private GameObject[] edges;
    private int currentEdgePoints = 0;
    [SerializeField] private float speed = 2f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // 切换移动方向
        if (Vector2.Distance(transform.position, edges[currentEdgePoints].transform.position) < .1f)
        {
            currentEdgePoints++;
            if (currentEdgePoints >= edges.Length)
            {
                currentEdgePoints = 0;
            }
        }
        // 向目标方向移动
        transform.position = Vector2.MoveTowards(transform.position, edges[currentEdgePoints].transform.position, Time.deltaTime * speed);
    }
}
