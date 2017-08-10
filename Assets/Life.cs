using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class Life : MonoBehaviour {

    //variables vida / daño
    public int life = 100;
    public int danio = 10;
    //UI text
    public Text lifeText;
    //default izquierda
    Vector2 dir = Vector2.right;
    //metodo para restar vida
    void LessLife(int danio)
    {
        life -= danio;
    }
    //iniciar
    void Start()
    {   
        //asisgnar UI Text
        lifeText = GameObject.Find("Text").GetComponent<Text>();
        //repeticion de movimiento
        InvokeRepeating("Move", 0.3f, 0.3f);
    }
    //Actualizar direccion al presionar teclas 
    void Update()
    {   
        if (Input.GetKey(KeyCode.RightArrow))
            dir = Vector2.right;
        else if (Input.GetKey(KeyCode.DownArrow))
            dir = -Vector2.up;    //abajo
        else if (Input.GetKey(KeyCode.LeftArrow))
            dir = -Vector2.right; // izquierda
        else if (Input.GetKey(KeyCode.UpArrow))
            dir = Vector2.up;
    }
    //mover
    void Move()
    {
        Vector2 v = transform.position;
        transform.Translate(dir);
    }
    //deteccion de colisiones
    void OnTriggerEnter2D(Collider2D coll)
    {   
        //ejecuta LessLife y actualiza UI Text
        LessLife(danio);
        lifeText.text = "" + life;
    }
}
