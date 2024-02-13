using UnityEngine;
// ReSharper disable All

public class ControlCamera : MonoBehaviour
{
    public GameObject Player;
    Vector3 distancia;

    void Start()
    {
        // Para a c�mera n�o ficar grudada no p� do person�gem, precisamos calcular a dist�ncia entre o personagem e a c�mera e usar essa dist�ncia
        // na hora de calcular a posi��o da c�mera
        // aqui � feito o calculo da distancia entre o personagem e a c�mera
        distancia = transform.position - Player.transform.position;
    }

    void Update()
    {
        // aqui � calculado a posi��o da c�mera + a dist�ncia dela com o personagem
        transform.position = Player.transform.position + distancia;
    }
}
