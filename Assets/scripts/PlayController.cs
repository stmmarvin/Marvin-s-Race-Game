using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayController : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI TimerText;
    public Button restartButton;
    public List<GameObject> targetPrefabs;
    public float timer;
    public float spawnRate = 1.5f;
    public bool isGameActive;
    public CarMovement carMovement;

    // Duration of the game in stopwatch
    private float currentTime;
    public bool gameOver;
    private Rigidbody playerRb;
    public float gravityModifier = 1.5f;
    public AudioSource playerAudio;
    public AudioClip PlayerCar;
    public AudioClip GameoverSound;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        playerAudio = GetComponent<AudioSource>();
    }

    public void StartGame()
    {
        carMovement.canMove = true;
        isGameActive = true;
        currentTime = 0;
        TimerText.gameObject.SetActive(true);
        currentTime = 0;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Deathbox"))
        {
            playerAudio.clip = GameoverSound; // Set the GameoverSound clip
            playerAudio.PlayOneShot(GameoverSound, 1.0f);
            gameOver = true;
            GameOver(); // Call the GameOver method
            Debug.Log("Game Over!");

        }
    }


    private void GameOver()
    {
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
        TimerText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(true);
        GameoverSound = GetComponent<AudioSource>().clip;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void Update()
    {
        if (isGameActive)
        {
            currentTime += Time.deltaTime;
            TimerText.text = "Time: " + currentTime.ToString("F2");
        }
    }
}
