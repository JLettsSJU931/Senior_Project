// James Letts Brennan Duff
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Casting: MonoBehaviour
{

    private Camera mainCam;
    private Vector3 mousePos;
    public GameObject bullet;
    public Transform bulletTransform;
    public bool firable;
    private float timer;
    public float fireTime

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();  
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 rotation = mousePos - transform.position;

        float rotZ = Mathf.Atan2(rotation.y, rotation.x)*Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0,0,rotZ);

        if (!firable)
        {
            timer += Time.deltaTime;
            if (timer > fireTime)
            {
                firable = true;
                timer = 0;
            }
        }
    }
}
