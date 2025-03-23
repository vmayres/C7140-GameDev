using UnityEngine;

public class AirHockeyBot : MonoBehaviour
{
    public float MaxSpeed = 10.0f;
    public float Acceleration = 2.0f;
    public Transform Puck; // A "bola" do jogo
    public Transform Target; // O gol do player

    private Rigidbody2D rbPuck;

    void Start()
    {
        Debug.Log("Bot is ready to play!");
        rbPuck = Puck.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 puckPosition = Puck.position;
        Vector2 puckVelocity = rbPuck.linearVelocity;
        Vector2 puckPredictedPosition = puckPosition + puckVelocity * Time.deltaTime;

        // Se a bola estiver na metade superior do campo, o bot se movimenta
        if (puckPosition.y > 0)
        {
            Vector2 hitDirection = (Target.position - Puck.position).normalized;
            Vector2 interceptPosition = puckPredictedPosition + hitDirection * 0.5f;

            transform.position = Vector2.MoveTowards(transform.position, interceptPosition, MaxSpeed * Time.deltaTime);
        }
        else
        {
            // Se o bot estiver abaixo da zona de idle, ele sobe
            if (transform.position.y < 4)
            {
                Vector2 idlePosition = new Vector2(transform.position.x, 4);
                transform.position = Vector2.MoveTowards(transform.position, idlePosition, MaxSpeed * Time.deltaTime);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Puck"))
        {
            Debug.Log("Bot hit the puck!");

            Vector2 hitDirection = (Target.position - Puck.position).normalized;
            float hitForce = 10.0f;

            Vector2 adjustedVelocity = (Vector2)Vector3.Project((Vector3)rbPuck.linearVelocity, (Vector3)hitDirection) + hitDirection * hitForce;

            rbPuck.linearVelocity = adjustedVelocity;
        }
    }
}
