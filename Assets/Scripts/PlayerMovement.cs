using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    int count = 0;
    int owo = 0;
    [SerializeField] public Puntitos ptos;
    [SerializeField] public Line_Controller line;
    public float speed= 1f;
    Transform[] a;
    public GameObject Lind_Renderer;
    IsometricCharacterRenderer isoRenderer;
    Rigidbody2D rg;
    //Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
         isoRenderer = GetComponentInChildren<IsometricCharacterRenderer>();
        a = ptos.puntos;
    }

    private void FixedUpdate()
    {
        Vector2 currentpos = rg.position;
        float horizontal = Input.GetAxis("Horizontal");
        float Vertical = Input.GetAxis("Vertical");
        Vector2 inputvector = new Vector2(horizontal, Vertical);
        inputvector = Vector2.ClampMagnitude(inputvector, 1);
        Vector2 movement = inputvector * speed;
        Vector2 newPos = currentpos + movement * Time.fixedDeltaTime;
        isoRenderer.SetDirection(movement);
        rg.MovePosition(newPos);
        
    }
    // Update is called once per frame
    void Update()
    {
        if (count >= this.a.Length)
        {
            count = this.a.Length;
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Transform puntoi = this.transform;
            Debug.Log(puntoi.position.x);
            Transform pista = this.a[count];
            Debug.Log(a[count].position.x);
            Transform[] lineaa = { puntoi, pista };
            line.SetUpLine(lineaa);
            Lind_Renderer.SetActive(true);
        }
        if (Input.GetKeyUp(KeyCode.E))
        {
            Lind_Renderer.SetActive(false);
            owo++;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
       
    }
}
