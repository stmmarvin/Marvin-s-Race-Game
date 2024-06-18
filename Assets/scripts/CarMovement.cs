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
    public AudioClip GameOver;

    private bool isGameOver = false;

    private void Start()
    {
        playerAudio = GetComponent<AudioSource>();
        playerAudio.clip = PlayerCar;
    }

    void Update()
    {
        if (isGameOver)
        {
            playerAudio.clip = GameOver;
            if (!playerAudio.isPlaying)
            {
                playerAudio.Play();
            }
            return;
        }

        if (canMove)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float VerticalInput = Input.GetAxis("Vertical");

            transform.Translate(Vector3.forward * Time.deltaTime * speed * VerticalInput);
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * horizontalInput);

            if (horizontalInput != 0 || VerticalInput != 0)
            {
                if (!playerAudio.isPlaying)
                {
                    playerAudio.clip = PlayerCar;
                    playerAudio.Play();
                }
            }
            else
            {
                playerAudio.Stop();
            }
        }

        if (transform.position.y < -10)
        {
            isGameOver = true;
        }
    }
}
