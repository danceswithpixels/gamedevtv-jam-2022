using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class DeathManager : MonoBehaviour
{
    PlayerMovement playerMovement;
    DeathCanvas deathCanvas;
    Ambulance ambulance;

    [SerializeField] TextMeshProUGUI finalScoreText;
    
    void Awake()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        deathCanvas = FindObjectOfType<DeathCanvas>();
        ambulance = FindObjectOfType<Ambulance>();
    }

    void Start() 
    {
        deathCanvas.gameObject.SetActive(false);
    }

    void Update()
    {
        if (playerMovement == null) {
            playerMovement = FindObjectOfType<PlayerMovement>();
        }
        deathCanvas.gameObject.SetActive(playerMovement.IsGamePaused());
        finalScoreText.text = "Game Over!\nYou saved: " + ambulance.patientsSaved + " Patients";
    }

    public void UnPauseAndLoadNextScene() {
        Debug.Log("Clicked");
        playerMovement.UnPauseGame();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
