using System;
using System.Collections;
using UnityEngine;

public class Camera_Scr : MonoBehaviour
{
    public GameObject Player;
    private Vector2 velocity;
    public float smoothTimeY;
    public float smoothTimeX;
    public bool bounds;
    public Vector3 minCameraPos;
    public Vector3 maxCameraPos;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {

        Player = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float posX = Mathf.SmoothDamp(transform.position.x, Player.transform.position.x, ref velocity.x, smoothTimeX);
        float posY = Mathf.SmoothDamp(transform.position.y, Player.transform.position.y, ref velocity.y, smoothTimeY);

        transform.position = new Vector3(posX, posY, transform.position.z);

        if (bounds)
        {

            transform.position = new Vector3(Mathf.Clamp(transform.position.x, minCameraPos.x, maxCameraPos.x),
                Mathf.Clamp(transform.position.y, minCameraPos.y, maxCameraPos.y),
                Mathf.Clamp(transform.position.z, minCameraPos.z, maxCameraPos.z));

        }
    }

    
}
