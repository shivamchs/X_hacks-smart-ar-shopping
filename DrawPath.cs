using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawPath : MonoBehaviour
{
    [SerializeField]
    private GameObject Sphere;
    [SerializeField]
    private GameObject OriginSphere;
    [SerializeField]
    private LineRenderer lineRenderer;

    

    // Start is called before the first frame update
    void Start()
    {
        shopping.FinalPoints.Insert(0, Vector3.zero);
        shopping.FinalPoints.Add(Vector3.zero);
        lineRenderer = GetComponent<LineRenderer>();
        foreach (Vector3 position in shopping.FinalPoints)
        {
            if(position == Vector3.zero)
                Instantiate(OriginSphere, position, Quaternion.identity);
            
            else
                Instantiate(Sphere, position, Quaternion.identity);
        }
        lineRenderer.positionCount = shopping.FinalPoints.Count;
        lineRenderer.SetPositions(shopping.FinalPoints.ToArray());
    }
}
