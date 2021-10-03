using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    int count = 0;
    int Npista = 0;
    [SerializeField] public Puntitos ptos;
    [SerializeField] public Line_Controller line;
    public float speed= 1f;
    Transform[] a;
    public GameObject Lind_Renderer;
    public LineRenderer Lineaaa;
    IsometricCharacterRenderer isoRenderer;
    Rigidbody2D rg;
    private NavMeshPath path;
    public GameObject target;
    Vector3[] aux;
    int usos = 3;
    //Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
         isoRenderer = GetComponentInChildren<IsometricCharacterRenderer>();
        a = ptos.puntos;
        path = new NavMeshPath();
    }

    private void FixedUpdate()
    {
        /*
        Vector2 currentpos = rg.position;
        float horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");
        Vector2 inputvector = new Vector2(horizontal, Vertical);
        inputvector = Vector2.ClampMagnitude(inputvector, 1);
        Vector2 movement = inputvector * speed;
        Vector2 newPos = currentpos + movement * Time.fixedDeltaTime;
        isoRenderer.SetDirection(movement);
        rg.MovePosition(newPos);
        */
    }
    // Update is called once per frame
    void Update()
    {
        if (count >= this.a.Length)
        {
            count = this.a.Length;
        }
            if (Input.GetKey(KeyCode.E))
            {
                Vector3 targetpos = target.transform.position;
                NavMesh.CalculatePath(transform.position, targetpos, NavMesh.AllAreas, path);
                aux = new Vector3[path.corners.Length];
                Lineaaa.positionCount = path.corners.Length;
                for (int i = 0; i < path.corners.Length; i++)
                {
                    aux[i] = path.corners[i];
                    // Debug.DrawLine(path.corners[i], path.corners[i + 1], Color.red);
                }
                /*for (int i = 0; i < aux.Length; i++) 
                {
                    aux[i] = 0;
                }*/
                //For, instanciar sprites y luego que tengan un ontrigger2d tal q desaparezcan.
                Lineaaa.SetPositions(aux);
                Lind_Renderer.SetActive(true);

                //line.SetUpLine(lineaa);

            }
            if (Input.GetKeyUp(KeyCode.E))
            {
                Lind_Renderer.SetActive(false);
            }
    }
    
}
