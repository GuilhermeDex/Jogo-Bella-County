using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{

    private Player player;
    private Animator anim;

    private Casting cast;

    void Start(){
        player = GetComponent<Player>();
        anim = GetComponent<Animator>();

        cast = FindObjectOfType<Casting>();
    }


    void Update(){
        OnMove();
        OnRun();
    }


    #region Movement
    void OnMove()
    {
        if (player.direction.sqrMagnitude > 0)
        {
            if (player.IsRolling)
            {
                anim.SetTrigger("isRoll");
            }
            else
            {
            anim.SetInteger("Transition", 1);
            }
            
        }

        else
        {
            anim.SetInteger("Transition", 0);
        }

        if (player.direction.x > 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
        }

        if (player.direction.x < 0)
        {
            transform.eulerAngles = new Vector2(0, 180);
        }

        if (player.IsCutting)
        {
            anim.SetInteger("Transition", 3);
        }

        if (player.IsDigging)
        {
            anim.SetInteger("Transition", 4);
        }
        if (player.IsWatering)
        {
            anim.SetInteger("Transition", 5);
        }
    }


    void OnRun()
    {
        if (player.IsRunning)
        {
            anim.SetInteger("Transition", 2);
        }
    }


    #endregion


    //é chamado quando o jogador pressiona o botao de acao na lagoa
    public void OnCastingStarted()
    {
        anim.SetTrigger("isCasting");
        player.isPaused = true;
    }

    //é chamado quando termina a pescaria
    public void OnCastingEnded()
    {
        cast.OnCasting();
        player.isPaused = false;
    }
}
