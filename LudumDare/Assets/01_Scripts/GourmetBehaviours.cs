using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GourmetBehaviours : MonoBehaviour
{
    public static GourmetBehaviours instance;

    [Header("Param")]
    public float m_StarvingPoint;
    public float m_ReduceStarvingPoint;

    public float score;

    public TMPro.TMP_Text scoreText;

    [Header("Timer")]
    [Min(0.2f)]
    public float m_StravingTime;
    private Timer t_StravingTimer;

    void Awake()
    {
        if (instance != null)
            Debug.LogWarning("Multiple instance of same Singleton : GourmetBehaviours");
        else
            instance = this;
    }

    private void Start()
    {
        t_StravingTimer = new Timer(m_StravingTime, Starving);

        t_StravingTimer.ResetPlay();
    }

    private void Starving()
    {
        m_StarvingPoint -= m_ReduceStarvingPoint;

        if (m_StarvingPoint <= 0)
            print("Game Over");

        t_StravingTimer.ResetPlay();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Food_Behaviours food;

        if (!collision.gameObject.TryGetComponent<Food_Behaviours>(out food))
            return;

        score += food.param.GetPoint(food.m_Level);

        UpdateScoreText();
    }

    private void UpdateScoreText()
    {
        scoreText.text = score.ToString();
    }
}
