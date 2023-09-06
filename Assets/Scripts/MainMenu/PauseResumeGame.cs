using UnityEngine;
using UnityEngine.UI;

public class PauseResumeGame : MonoBehaviour
{
    public Button pauseButton; // Reference to the pause button.
    public Button resumeButton; // Reference to the resume button.

    private void Start()
    {
        // Attach listeners to the button click events
        pauseButton.onClick.AddListener(PauseGame);
        resumeButton.onClick.AddListener(ResumeGame);
    }

    private void PauseGame()
    {
        // Pause the game by setting the time scale to 0
        Time.timeScale = 0;
    }

    private void ResumeGame()
    {
        // Resume the game by setting the time scale back to 1
        Time.timeScale = 1;
    }
}
