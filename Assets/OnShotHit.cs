using UnityEngine;

public class OnShotHit : MonoBehaviour
{

    [SerializeField] private GameObject bloodParticle;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject blood = Instantiate(bloodParticle);
        blood.transform.position = transform.position;

        Destroy(gameObject, 0.1f);
    }
}
