using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed;
    BoxCollider2D box;
    float groundWidth;

    float pipeWidth;

    // Start is called before the first frame update
    void Start()
    {
        if(gameObject.CompareTag("Ground"))
        {
            box = GetComponent<BoxCollider2D>();
            groundWidth = box.size.x;
        }
        else if(gameObject.CompareTag("Column"))
        {
            pipeWidth = GameObject.FindGameObjectWithTag("Pipe").GetComponent<BoxCollider2D>().size.x;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.gameOver == false)
        {
            transform.position = new Vector2(
            transform.position.x - speed * Time.deltaTime,
            transform.position.y);
        }
        
        if(gameObject.CompareTag("Ground"))
        {
            if(transform.position.x <= -groundWidth)
            {
                transform.position = new Vector2(
                    transform.position.x + 2*groundWidth,
                    transform.position.y);
            }
        }
        else if (gameObject.CompareTag("Column"))
        {
            if(transform.position.x < GameManager.bottomLeft.x - pipeWidth)
            {
                Destroy(gameObject);
            }
        }

        
    }
}
