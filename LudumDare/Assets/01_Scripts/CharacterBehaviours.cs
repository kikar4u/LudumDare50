using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaviours : MonoBehaviour
{
    [Header("Timer")]
    [Min(0.2f)]
    public float m_dontMoveTime;
    private Timer t_BurnCookTimer;

    [Space]
    public CharacterController controller;
    public CharacterFeedbacks feedback;

    private void Start()
    {
        t_BurnCookTimer = new Timer(m_dontMoveTime, GetBurn);
    }


    // Update is called once per frame
    void Update()
    {
        if (controller.velocity != Vector3.zero)
        {
            t_BurnCookTimer.Pause();
            t_BurnCookTimer.Reset();
            feedback.StopBurnAnim();
            return;
        }
            

        if (t_BurnCookTimer.IsStarted())
            return;

        t_BurnCookTimer.ResetPlay();
    }


    private void GetBurn()
    {
        print("j'ai chaud");
        feedback.PlayBurnFeedback();
    }
}
