using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class Player : MonoBehaviour
{
    // Update is called once per frame
    [SerializeField]
    private float moveSpeed;

    [SerializeField]
    private GameObject weapon;

    [SerializeField]
    private Transform shootTransform;

    [SerializeField]
    private float shootInterval = 0.5f;
    private float lastShotTime = 0f;

    void Update()
    {
        // float horizontalInput = UnityEngine.Input.GetAxisRaw("Horizontal");
        // float verticalInput = UnityEngine.Input.GetAxisRaw("Vertical");
        // Vector3 moveTo = new Vector3(horizontalInput, 0f, 0f);
        // transform.position += moveTo * moveSpeed * Time.deltaTime;

        // Vector3 moveTo = new Vector3(moveSpeed * Time.deltaTime, 0, 0);

        // if(UnityEngine.Input.GetKey(KeyCode.LeftArrow)){
        //     transform.position -= moveTo;
        // } else if(UnityEngine.Input.GetKey(KeyCode.RightArrow)){
        //     transform.position += moveTo;
        // }

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(UnityEngine.Input.mousePosition);
        float toX = Mathf.Clamp(mousePos.x, -2.35f, 2.35f);
        transform.position = new Vector3(toX, transform.position.y, transform.position.z);

        Shoot();

    }

    void Shoot(){
        if(Time.time - lastShotTime > shootInterval){
            Instantiate(weapon, shootTransform.position, Quaternion.identity);
            lastShotTime = Time.time;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Enemy"){
            Debug.Log("Game Over");
            Destroy(gameObject);
        }
    }
}
