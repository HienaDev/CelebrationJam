using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovePlayer : MonoBehaviour
{

    private Rigidbody2D rb;
    [SerializeField] private float speed = 5f;
    private Vector2 velocity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        velocity = Vector2.zero;

        if (Input.GetKey(KeyCode.W)) velocity.y = 1;
        if (Input.GetKey(KeyCode.S)) velocity.y = -1;
        if (Input.GetKey(KeyCode.D)) velocity.x = 1;
        if (Input.GetKey(KeyCode.A)) velocity.x = -1;

        velocity.Normalize();

        rb.velocity = velocity * speed;

        FlipPlayer();
    }


    private void FlipPlayer()
    {
        //if (rb.velocity.x < 0 && transform.right.x > 0)
        //{ 
        //    transform.rotation = Quaternion.Euler(0f, 180f, 0f);

        //}
        //else if (rb.velocity.x > 0 && transform.right.x < 0)
        //{ 
        //    transform.rotation = Quaternion.identity;

        //}

        // https://answers.unity.com/questions/640162/detect-mouse-in-right-side-or-left-side-for-player.html

        var playerScreenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        if (Input.mousePosition.x < playerScreenPoint.x)
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        else
            transform.rotation = Quaternion.identity;


    }

}
