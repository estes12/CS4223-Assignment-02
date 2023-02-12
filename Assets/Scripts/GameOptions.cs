using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOptions : MonoBehaviour
{
    public Slider speedSlider;
    public static float sliderInput = 1.0f;

    public TMP_Dropdown colorDropdown;
    public GameObject playerColor;
    public static int color = 0;

    public TMP_Dropdown playerDropdown;
    public GameObject playerSphere;
    public static float size;
    public static int playerSize = 0;
    public void SetSpeed()
    {
        sliderInput = speedSlider.value;
    }

    public void ChooseColor() // use in the change event for the dropdown
    {
        switch (colorDropdown.value)
        {
            case 1:
                playerColor.GetComponent<Renderer>().material.color = Color.magenta;
                color = colorDropdown.value;
                break;
            case 2:                
                playerColor.GetComponent<Renderer>().material.color = Color.green;
                color = colorDropdown.value;
                break;
            case 3:                
                playerColor.GetComponent<Renderer>().material.color = Color.black;
                color = colorDropdown.value;
                break;
            default:                
                playerColor.GetComponent<Renderer>().material.color = Color.cyan;
                color = colorDropdown.value;
                break;
        }
    }
    public void ChangeSize()
    {
        switch (playerDropdown.value)
        {
            case 1:
                size = 3.0f;
                playerSize = playerDropdown.value;
                break;
            default:
                size = 1.0f;
                playerSize = playerDropdown.value;
                break;
        }
        
        // scale by the magnification
        playerSphere.transform.localScale = new Vector3(size, size, size);
        // adjust vertical position so ball does not end up in or above the plane
        playerSphere.transform.localPosition = new Vector3(playerSphere.transform.localPosition.x, 0.5f * size, playerSphere.transform.localPosition.z);
    }

    public void Start()
    {
        colorDropdown.value = color;
        ChooseColor();
        playerDropdown.value = playerSize;
        ChangeSize();
        speedSlider.value = sliderInput;
       
    }
}
