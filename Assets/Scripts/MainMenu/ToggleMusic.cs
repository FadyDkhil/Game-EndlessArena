using UnityEngine;
using UnityEngine.UI;

public class ToggleMusic : MonoBehaviour
{
    public AudioSource musicAudioSource; // Reference to your music's AudioSource component.
    public Button toggleButton; // Reference to your UI toggle button.
    private bool isMusicPlaying = true;

    private void Start()
    {
        // Set the initial button text
        UpdateButtonText();

        // Attach a listener to the button's click event
        toggleButton.onClick.AddListener(ToggleMusicState);
    }

    private void ToggleMusicState()
    {
        // Toggle the music state (play/pause)
        isMusicPlaying = !isMusicPlaying;

        if (isMusicPlaying)
        {
            // Play the music
            musicAudioSource.Play();
        }
        else
        {
            // Pause the music
            musicAudioSource.Pause();
        }

        // Update the button text to reflect the current music state
        UpdateButtonText();
    }

    private void UpdateButtonText()
    {
        // Update the button's text based on the current music state
        toggleButton.GetComponentInChildren<Text>().text = isMusicPlaying ? "Pause Music" : "Play Music";
    }
}
