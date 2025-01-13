using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Jobs;

public class Background : MonoBehaviour
{

    private float moveSpeed = 3f;

    // Update is called once per frame
    void Update()
    {
        transform.position += UnityEngine.Vector3.down * moveSpeed * Time.deltaTime;
        if(transform.position.y < -10){
            transform.position += new UnityEngine.Vector3(0, 20f, 0);
        }
    }
      
}
