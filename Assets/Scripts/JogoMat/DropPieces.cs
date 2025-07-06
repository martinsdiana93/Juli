using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Collections.Generic;

public class DropPieces : MonoBehaviour, IDropHandler
{

    public GameObject FinalScene;
    public JogoMatController mat_controller;
    public int numeroTotalDePecas = 3;
    public Image image = null;

    public static int contadorPecasRestantes;

    void Start()
    {
        contadorPecasRestantes = numeroTotalDePecas;
        if (FinalScene != null)
            FinalScene.SetActive(false);
        image = GetComponent<Image>();
    }

    public void toggle_alpha(bool visible){
        if(image == null){return;}
        var currentColor = image.color;
        currentColor.a = visible ? 0 : 1;
        image.color = currentColor;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null) return;
        var collisionElement = eventData.pointerDrag.GetComponent<Puzzle>();
        if (collisionElement == null) return;
        if (collisionElement.targetImage.name == this.gameObject.name)
        {
            collisionElement.GetComponent<Puzzle>()._canvasGroup.blocksRaycasts = true;
            collisionElement.gameObject.SetActive(false);
            toggle_alpha(false);
            //Destroy(collisionElement.gameObject, 0);
            mat_controller.play_sound("correct");
            contadorPecasRestantes--;
            VerificarFimDoJogo();
        }
        else
        {
            collisionElement.ResetImage();
            mat_controller.play_sound("wrong");

        }
    }

    private void VerificarFimDoJogo()
    {
        if (contadorPecasRestantes <= 0 && FinalScene != null)
        {
            //FinalScene.SetActive(true);
            contadorPecasRestantes = numeroTotalDePecas;
            mat_controller.win_game();
        }
    }
}
