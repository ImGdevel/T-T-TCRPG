using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonMove : MonoBehaviour
{
/*    [SerializeField] private float Speed;*/
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float inputX = 0;
        float inputY = 0;
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            inputY++;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            inputY--;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            inputX--;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            inputX++;
        }
        transform.Translate(new Vector2(inputX, inputY));
    }
}
