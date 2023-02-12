using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public static int count;
    private float movementX;
    private float movementY;
    
    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    public float speed;
    public GameObject player;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
        speed = GameOptions.sliderInput;
        switch (GameOptions.color)
        {
            case 1:
                player.GetComponent<Renderer>().material.color = Color.magenta;
                
                break;
            case 2:
                player.GetComponent<Renderer>().material.color = Color.green;
                
                break;
            case 3:
                player.GetComponent<Renderer>().material.color = Color.black;
                
                break;
            default:
                player.GetComponent<Renderer>().material.color = Color.cyan;
               
                break;
        }

        switch (GameOptions.playerSize)
        {
            case 1:
                GameOptions.size = 3.0f;
                break;
            default:
                GameOptions.size = 1.0f;
                break;
        }
        // scale by the magnification
        player.transform.localScale = new Vector3(GameOptions.size, GameOptions.size, GameOptions.size);
        // adjust vertical position so ball does not end up in or above the plane
        player.transform.localPosition = new Vector3(player.transform.localPosition.x, 0.5f * GameOptions.size, player.transform.localPosition.z);
    }
    
    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();

        if(count == 12)
        {
            winTextObject.SetActive(true);
            FindObjectOfType<GameManager>().Win();
        }
    }

 
    void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);

        if (rb.position.y < -1f) //to restart when falling off edge
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }    
}
