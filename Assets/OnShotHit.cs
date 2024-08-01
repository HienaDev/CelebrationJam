using System.Collections;
using UnityEngine;

public class OnShotHit : MonoBehaviour
{

    [SerializeField] private GameObject bloodParticle;
    private Vector2 velocity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        velocity = gameObject.GetComponent<Rigidbody2D>().velocity;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        Shootable shootableObject = collision.gameObject.GetComponent<Shootable>();

        if (shootableObject != null)
        {
            collision.gameObject.GetComponent<Shootable>().GetShot(collision.contacts[0].point, velocity);

            Destroy(gameObject);
        }
        else
        {
            StartCoroutine(DestroyAfterXSeconds(2));
        }
        
    }

    private IEnumerator DestroyAfterXSeconds(int seconds)
    {
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

        yield return new WaitForSeconds(seconds);

        float transparency = 1.0f;


        float currentTime = 1;
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        while (currentTime < 2)
        {
            transparency = currentTime / 2;
            currentTime -= Time.deltaTime;

            spriteRenderer.color = new Color    (spriteRenderer.color.r,
                                                spriteRenderer.color.g,
                                                spriteRenderer.color.b,
                                                transparency);
            Debug.Log("changingColor");
            yield return null;
        }
    }
}
