using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{

    private int cherryCount = 0;
    [SerializeField] private Text cherryText;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Cherry"))
        {
            Destroy(other.gameObject);
            cherryCount++;
            cherryText.text = "Cherry count: " + cherryCount;
        }
    }
}
