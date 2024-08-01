using UnityEngine;

public class EnemyShot : Shootable
{

    [SerializeField] private GameObject bloodParticle;
    [SerializeField] private GameObject head;
    [SerializeField] private float headFlyingSpeed;

    public override void GetShot(Vector2 collisionPos, Vector2 collisionSpeed)
    {
        GameObject blood = Instantiate(bloodParticle);
        blood.transform.position = collisionPos;

        GameObject headTemp = Instantiate(head);
        headTemp.transform.position = gameObject.transform.position;

        float randomVelocity = Random.Range(-1f, 1f);

        Vector2 direction = (Vector2)transform.position - collisionPos;


        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //headTemp.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        Debug.Log(collisionSpeed);
        headTemp.GetComponent<Rigidbody2D>().velocity = collisionSpeed.normalized * headFlyingSpeed;

    }
}
