using UnityEngine;

[RequireComponent (typeof(TrailRenderer))]
public class TrailRendererEndWidth : MonoBehaviour
{

    [SerializeField] private float endWidth = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<TrailRenderer>().endWidth = endWidth;
    }
  
    
}
