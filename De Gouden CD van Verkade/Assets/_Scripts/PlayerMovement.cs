using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 8f; 
    
    // NIEUW: De kracht van de sprong (aanpasbaar in Unity Inspector)
    public float jumpForce = 12f; 
    
    private Rigidbody2D rb;
    private float horizontalInput;
    
    // NIEUW: Een ja/nee variabele om bij te houden of de speler op de grond staat
    private bool isGrounded; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");

        // NIEUW: Als de speler op Spatie drukt EN op de grond staat, dan springen!
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            // We behouden de horizontale snelheid (x), maar geven een verticale boost omhoog (jumpForce)
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            
            // Zodra we springen, staan we niet meer op de grond
            isGrounded = false; 
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y);
    }

    // NIEUW: Unity detecteert automatisch wanneer de speler ergens op landt
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // We controleren of het object waar we op landen "Ground" heet
        if (collision.gameObject.name == "Ground")
        {
            isGrounded = true;
        }
    }
}