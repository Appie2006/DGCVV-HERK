using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Snelheid van de speler (aanpasbaar in de Unity Inspector)
    public float moveSpeed = 8f; 
    
    private Rigidbody2D rb;
    private float horizontalInput;

    void Start()
    {
        // Haal de Rigidbody2D component op die op de speler staat
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Vang de input op. GetAxisRaw geeft direct -1 (A/Links) of 1 (D/Rechts)
        horizontalInput = Input.GetAxisRaw("Horizontal");
    }

    void FixedUpdate()
    {
        // Beweeg de speler over de X-as. De Y-as laten we met rust, zodat de zwaartekracht zijn werk blijft doen!
        rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y);
    }
}