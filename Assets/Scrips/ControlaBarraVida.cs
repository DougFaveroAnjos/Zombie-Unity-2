using UnityEngine;
using UnityEngine.UI;
// ReSharper disable All

public class ControlaBarraVida : MonoBehaviour
{
    public Slider barraVida;
    public ControlaJogador ScriptPlayer;
    
    void Start()
    {
        ScriptPlayer = GameObject.FindWithTag("Player").GetComponent<ControlaJogador>();
        barraVida.maxValue = ScriptPlayer.vida;
        barraVida.value = ScriptPlayer.vida;
    }

    public void AtualizaBarraVida()
    {
        barraVida.value = ScriptPlayer.vida;
    }
}
