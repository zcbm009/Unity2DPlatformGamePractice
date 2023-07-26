using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFlower : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        // 如果检测到人物则让人物跟随移动
        if (other.gameObject.name=="Player")
        {
            other.gameObject.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        // 如果检测到人物则解除人物跟随
        if (other.gameObject.name=="Player")
        {
            other.gameObject.transform.SetParent(null);
        }
    }

    
}
