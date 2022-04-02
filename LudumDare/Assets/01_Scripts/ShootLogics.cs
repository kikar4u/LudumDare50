using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ShootLogics : MonoBehaviour
{
    [Min(1f)]
    public float m_ShootForce = 10f;

    [Min(0.5f)]
    public float m_ShootRadius = 0.5f;
    public LayerMask m_FoodLayer;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            DetectFood();
        }
    }

    public void DetectFood()
    {
        Collider[] hit = Physics.OverlapSphere(transform.position, m_ShootRadius, m_FoodLayer);

        Food_Behaviours food;

        if (hit.Length <= 0)
            return;

        foreach (var collider in hit)
        {
            if (collider.gameObject.TryGetComponent<Food_Behaviours>(out food))
            {
                Shoot(food);
            }
        }
    }

    public void Shoot(Food_Behaviours food)
    {
        print(food.name + " name");
        //food.MoveToTheGourmet(GourmetBehaviours.instance.transform.position);
        food.Shoot(transform.forward,m_ShootForce);
    }

    #region Gizmo

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, m_ShootRadius);
    }

    #endregion
}
