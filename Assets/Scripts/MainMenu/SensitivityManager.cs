using UnityEngine;
using UnityEngine.UI;

public class SensitivityManager : MonoBehaviour
{
    public Slider sensitivitySlider; // Reference to your sensitivity slider
    public PlayerMovement playerMovement; // Reference to your PlayerMovement script
    public Text sensitivityText;
    private int intValue;
    private void Start()
    {
        // Subscribe to the slider's OnValueChanged event
        sensitivitySlider.onValueChanged.AddListener(UpdateSensitivity);
    }
    
    private void UpdateSensitivity(float value)
    {
        // Update the player's sensitivity based on the slider value
        playerMovement.sensibility = value * 10f; // Assuming the slider value is in the range [0, 1]
        intValue = Mathf.FloorToInt(value*100f);
        sensitivityText.text = intValue.ToString() + "%";
    }
}