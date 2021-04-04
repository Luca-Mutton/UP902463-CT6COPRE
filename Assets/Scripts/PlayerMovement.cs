using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class PlayerMovement : MonoBehaviour
{
    //checks to see if player is alive
    bool IsAlive = true;

    public float speed = 5;
    [SerializeField] Rigidbody rb;
    [SerializeField] float horizontalMultiplier = 2;
    [SerializeField] float jumpForce = 400f;
    [SerializeField] LayerMask groundMask;

    [SerializeField] private TextMeshProUGUI distanceText = null;
    [SerializeField] private float timeMod = 4.0f;
    [SerializeField] private float timeOffset = 2.0f;

    float horizontalInput;
    private void FixedUpdate()
    {
        if (!IsAlive) return;
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + forwardMove + horizontalMove);

        GameManager.Distance += Time.deltaTime * timeMod;
        distanceText.text = String.Format("{0:0m}", GameManager.Distance);
    }

    void Jump()
    {
        //check if grounded
        float height = GetComponent<Collider>().bounds.size.y;
        bool isGrounded = Physics.Raycast(transform.position, Vector3.down, (height / 2) + 0.1f, groundMask);

        rb.AddForce(Vector3.up * jumpForce);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        //Touch myTouch = Input.GetTouch(0);

        //if (Input.touchCount > 0)
        //{
        //    //Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        //    //Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        //    //rb.MovePosition(rb.position + forwardMove + horizontalMove);
        //}


        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        if (transform.position.y < -5)
        {
            Die();
            
        }

        
    }

    public void Die()
    {
        IsAlive = false;
        Invoke("Restart", 2);
        GameManager.Distance = 0;
        distanceText.text = String.Format("{0:0m}", GameManager.Distance);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
