using UnityEngine;
using UnityEngine.EventSystems;

public class ShootingPlayer : MonoBehaviour
{

    [SerializeField] private GameObject firePoint;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float bulletSpeed;

    private Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = mousePos - (Vector2)firePoint.transform.position;

        GameObject bullTemp = Instantiate(bullet);

        bullTemp.transform.position = firePoint.transform.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bullTemp.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        bullTemp.GetComponent<Rigidbody2D>().velocity = direction.normalized * bulletSpeed;

        //bullTemp.GetComponent<Rigidbody2D>().velocity = Vector2.right * bulletSpeed;

        animator.SetTrigger("Shoot");
    }


}
