using UnityEngine;

public abstract class Shootable : MonoBehaviour
{
    public abstract void GetShot(Vector2 collisionPos, Vector2 objectVelocity);
}
