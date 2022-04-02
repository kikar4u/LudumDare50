using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food_Behaviours : MonoBehaviour
{
    [Min (0.2f)]
    public float m_DetectionRadius = 1f;
    public LayerMask m_PlaqueLayer;


    [Header("Timer")]
    [Min(0.2f)]
    public float m_FastCookTime;
    private Timer t_FastCookTimer;
    [Min(0.2f)]
    public float m_MediumCookTime;
    private Timer t_MediumCookTimer;

    // Start is called before the first frame update
    void Start()
    {
        t_FastCookTimer = new Timer(m_FastCookTime, ChangeCookstyle);
        t_MediumCookTimer = new Timer(m_MediumCookTime, ChangeCookstyle);
    }

    // Update is called once per frame
    void Update()
    {
        DetectZone();
    }

    public void DetectZone()
    {
        Collider[] hit = Physics.OverlapSphere(transform.position, m_DetectionRadius, m_PlaqueLayer);

        if (hit.Length <= 0)
            return;

        foreach (var collider in hit)
        {
            if (collider.gameObject.CompareTag("Hot"))
            {
                if (t_FastCookTimer.IsStarted())
                    return;

                Cook();
                return;
            }
        }
    }

    public void Cook()
    {
        print("cook");
        t_FastCookTimer.ResetPlay();
    }

    public void ChangeCookstyle()
    {
        print("+1");
    }

    #region Gizmo

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, m_DetectionRadius);
    }

    #endregion
}
