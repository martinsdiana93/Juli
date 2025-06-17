using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;

public class DropPieces : MonoBehaviour, IDropHandler
{

    public GameObject FinalScene;
    public int numeroTotalDePecas = 3;

    private static int contadorPecasRestantes;

    void Start()
    {
        contadorPecasRestantes = numeroTotalDePecas;
        if (FinalScene != null)
            FinalScene.SetActive(false);
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null) return;
        var collisionElement = eventData.pointerDrag.GetComponent<Puzzle>();
        if (collisionElement == null) return;
        if (collisionElement.targetImage.name == this.gameObject.name)
        {
            var currentColor = this.GetComponent<Image>().color;
            currentColor.a = 1;
            GetComponent<Image>().color = currentColor;
            Destroy(collisionElement.gameObject, 0);
            //correctSound.Play();
            contadorPecasRestantes--;
            VerificarFimDoJogo();
        }
        else
        {
            collisionElement.ResetImage();
            //wrongSound.Play();

        }
    }

    private void VerificarFimDoJogo()
    {
        if (contadorPecasRestantes <= 0 && FinalScene != null)
        {
            FinalScene.SetActive(true);
        }
    }
}
