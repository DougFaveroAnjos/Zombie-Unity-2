using UnityEngine;
// ReSharper disable All
public class ControlaAudio : MonoBehaviour
{
    private AudioSource meuAudioSource;
    // Variável estatica faz com que ela fique valendo o mesmo valor independente do script que ela for usada
    public static AudioSource instancia;

    void Awake()
    {
        meuAudioSource = GetComponent<AudioSource>();
        instancia = meuAudioSource;
    }
}
