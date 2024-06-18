using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Laps : MonoBehaviour
{
    // Start is called before the first frame update
    public int laps = 0;
    public int maxLaps = 3;
    public GameObject FinishLine;
    public GameObject Ground_Road;
    public TextMeshProUGUI Lap_Text;
    public PlayController playController;
    public AudioClip FinishSound;
    public List<GameObject> targetPrefabs;
    private AudioSource audioSource;
    private bool lap2TextVisible = false;
    private float lap2TextDuration = 2f;
    private float lap2TextTimer = 0f;

    private void Start()
    {
        if (FinishLine != null)
        {
            Debug.Log("FinishLine prefab is correctly connected.");
        }
        else
        {
            Debug.Log("FinishLine prefab is not connected.");
        }
        Lap_Text.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finishline"))
        {
            laps++;
            // Update de lap tekst gebaseerd op het huidige aantal rondes
            if (laps == 2)
            {
                Lap_Text.text = "Lap 2/" + maxLaps;
                lap2TextVisible = true;
                lap2TextTimer = lap2TextDuration;
            }
            else
            {
                Lap_Text.text = "Laps: " + laps + "/" + maxLaps;
            }

            if (laps == maxLaps)
            {
                playController.gameOver = true;
                GameOver();
            }
            audioSource.PlayOneShot(FinishSound);
            Lap_Text.gameObject.SetActive(true);
        }
    }

    private void GameOver()
    {
        // Code for game over logic goes here
        playController.gameOverText.gameObject.SetActive(true);
        playController.restartButton.gameObject.SetActive(true);
        playController.TimerText.gameObject.SetActive(false);
        playController.carMovement.canMove = false;
        playController.playerAudio.Stop();
        playController.playerAudio.clip = playController.GameoverSound;
        playController.playerAudio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (laps > 0)
        {
            FinishLine.SetActive(true);
        }

        if (lap2TextVisible)
        {
            lap2TextTimer -= Time.deltaTime;
            if (lap2TextTimer <= 0f)
            {
                Lap_Text.gameObject.SetActive(false);
                lap2TextVisible = false;
            }
        }
    }
}
