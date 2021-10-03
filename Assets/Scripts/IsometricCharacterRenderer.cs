using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsometricCharacterRenderer : MonoBehaviour
{
    public static readonly string[] staticDirections = { "Static N", "Static W", "Static S", "Static E"};
    public static readonly string[] runDirections = { "Run N",  "Run W", "Run S", "Run E" };
    Animator animator;
    int lastDireccion;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void SetDirection(Vector2 direction) {
        string[] directionarray = null;

       if (direction.magnitude < 0.1f)
       {
            directionarray = staticDirections;
        }
        else {
            directionarray = runDirections;
            lastDireccion = DirectionToIndex(direction, 4);    
        }

        animator.Play(directionarray[lastDireccion]);
    
    }
    public static int DirectionToIndex(Vector2 direction, int n) {
        //lo normalizamos
        Vector2 normDirection = direction.normalized;
        //calculamos cuantos grados tiene
        float step = 360f / n;
        //cuantos grados es la mitad
        float halfstep = step / 2;
        //retorna el angulo entre vector2 up y la direccion
        float angle = Vector2.SignedAngle(Vector2.up, normDirection);
        //si el angulo es negativo le agregamos 360
        if (angle < 0) {
            angle += 360;
        }
        float stepCount = angle / step;
        //retornar redondeado
        return Mathf.FloorToInt(stepCount);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
