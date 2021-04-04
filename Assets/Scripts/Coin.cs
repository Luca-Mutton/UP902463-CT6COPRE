using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] float turnSpeed = 90f;

    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.GetComponent<Obstacle>() != null)
        {
            Destroy(gameObject);
                return;
        }

        // check that the object collided with the player
        if (other.gameObject.name != "Player")
        {
            return;
        }

        //add to player's score
        GameManager.inst.IncrementScore(); //add one to player's score

        //destroy this object
        Destroy(gameObject); //destroy coin
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, turnSpeed * Time.deltaTime);
    }
}
