using UnityEngine;

public class Flor : MonoBehaviour
{
    // Esta funcion se activa cuando la abeja toca a la flor
    private void OnTriggerEnter(Collider other)
    {
        // se revisa la abeja tiene la etiqueta "Player"
        if (other.CompareTag("Player"))
        {
            Debug.Log("¡La abeja recolectó la flor!");
            Destroy(gameObject); // Destruye este objeto (la flor)
        }
    }
}