using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line_Controller : MonoBehaviour
{
    public LineRenderer linea;
    private Transform[] points;

    // Start is called before the first frame update
    private void Awake()
    {
        linea = this.GetComponent<LineRenderer>();
    }

    public void SetUpLine(Transform[] p) {
        Debug.Log(linea.bounds);
        linea.positionCount = p.Length;
        points = p;
    }
    
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < points.Length; i++) {
            linea.SetPosition(i, points[i].position);
        }
    }
}
