using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rigidbody2DComponet;
    private void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody2DComponet = GetComponent<Rigidbody2D>();
    }


    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Traps"))
        {
            animator.SetTrigger("death");
            rigidbody2DComponet.bodyType = RigidbodyType2D.Static;
        }
    }

    private void restartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
