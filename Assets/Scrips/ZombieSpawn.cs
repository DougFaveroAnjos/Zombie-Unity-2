using UnityEngine;
// ReSharper disable All

public class ZombieSpawn : MonoBehaviour
{
    public GameObject Zumbi;
    float contadorTempo = 0;
    public int tempoDeSpawn = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        contadorTempo += Time.deltaTime;
        if (contadorTempo >= tempoDeSpawn)
        {
            Instantiate(Zumbi, transform.position, transform.rotation);
            contadorTempo = 0;
        }

    }
}
