using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int life;
    public float speed;
    public float jump;
    public bool isGrounded;


    // Start is called before the first frame update
    void Start()
    {
        life = 5;
        speed = 11.0f;
        jump = 800.0f;
        isGrounded = true;
        GetComponent<Rigidbody2D>().gravityScale = 3.2f;
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }

    public void MovePlayer()
    {
        float movimento = Input.GetAxis("Horizontal");
        GetComponent<Rigidbody2D>().velocity = new Vector2(movimento*speed, GetComponent<Rigidbody2D>().velocity.y);

        if (Input.GetKeyDown(KeyCode.Space)){
            if(isGrounded)
                GetComponent<Rigidbody2D>().AddForce(new Vector2(0, jump));
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor") isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor") isGrounded = false;
    }

}
