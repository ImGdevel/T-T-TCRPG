using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursor : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        this.transform.position = Utills.MousePointer;
    }
}
