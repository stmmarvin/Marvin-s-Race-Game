using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float speed = 20;

    public float turnSpeed = 45;
    public bool canMove = false;

    private AudioSource playerAudio;
    public AudioClip PlayerCar;

    private void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        playerAudio.clip = PlayerCar;
    }
    void Update()
    {
        if (canMove)
        { //Variables for handling input
            float horizontalInput = Input.GetAxis("Horizontal");
            float VerticalInput = Input.GetAxis("Vertical");

            //Move car forward with W and S
            transform.Translate(Vector3.forward * Time.deltaTime * speed * VerticalInput);

            //Rotate car with A and D
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * horizontalInput);

            if(horizontalInput != 0 || VerticalInput != 0)
            {
                if (!playerAudio.isPlaying)
                {
                    playerAudio.Play();
                }
            }
            else
            {
                playerAudio.Stop();
            }


        }
    }
}