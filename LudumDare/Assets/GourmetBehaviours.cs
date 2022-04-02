using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GourmetBehaviours : MonoBehaviour
{
    public static GourmetBehaviours instance;

    public float score;

    public TMPro.TMP_Text scoreText;

    void Awake()
    {
        if (instance != null)
            Debug.LogWarning("Multiple instance of same Singleton : GourmetBehaviours");
        else
            instance = this;
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
