using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{

    public float speed;

    private void Update() 
    {
        Movement();
    }

    private void Movement() 
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(x, y, 0);
        transform.position += movement * speed * Time.fixedDeltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Pellet")
        {  
            GameManager.GetInstance().AddPoint();
            UndoCommand.pelletsEaten.Add(other.gameObject);
            other.gameObject.SetActive(false);    
        }    

        if (other.tag == "Ghost")
        {
            GameManager.GetInstance().TriggerLose();
        }
    }
}
