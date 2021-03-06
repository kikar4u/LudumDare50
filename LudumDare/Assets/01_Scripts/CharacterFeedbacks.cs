using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class CharacterFeedbacks : MonoBehaviour
{
    public GameObject m_burnFeedback;
    public float m_ScaleTime;
    public float m_UnScaleTime;

    [Header("Indicator")]
    public List<Color> colors;
    public SpriteRenderer burnIndicator;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
            PlayBurnFeedback();
    }

    public void PlayBurnFeedback()
    {
        m_burnFeedback.transform.DOScale(.5f, m_ScaleTime).SetEase(Ease.Linear);
    }

    internal void StopBurnAnim()
    {
        m_burnFeedback.transform.DOScale(0, m_UnScaleTime).SetEase(Ease.Linear);
    }

    public void ChangeIndicator(int burnLevel)
    {
        int burn = Mathf.Clamp(burnLevel - 1, 0, 10);
        burnIndicator.color = colors[burn];
    }
}
