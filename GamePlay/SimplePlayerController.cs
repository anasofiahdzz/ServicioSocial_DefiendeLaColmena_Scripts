using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class SimplePlayerController : MonoBehaviour{
//La clase requiere que el objeto que tenga este script tenga un componente
//de tipo CharacterController

    //Velocidad de movimiento
    public float speed = 5f;

    private CharacterController controller;

    void Start(){
        //Obtener la referencia al CharacterController
        controller = GetComponent<CharacterController>();
    }


    void Update(){
        //Obtener eje de movimiento, funciona con las flechas y WASD
        //para cambiarlo ir a Input en ProyectSettings
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        //Vector de movimiento
        Vector3 move = new Vector3(horizontal, vertical, 0f);
        if (move.magnitude > 1f){
            move.Normalize();
        }

        //Esto mueve al personaje
        controller.Move(move * speed * Time.deltaTime);
    }
}