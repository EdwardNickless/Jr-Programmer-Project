using UnityEngine;

public class ProductivityUnit : Unit
{
    public float ProductivityMultiplier = 2.0f;
    
    private ResourcePile m_currentPile = null;

    protected override void BuildingInRange()
    {
        if (m_currentPile == null)
        {
            ResourcePile pile = m_Target as ResourcePile;

            if (pile != null)
            {
                m_currentPile = pile;
                m_currentPile.ProductionSpeed *= ProductivityMultiplier;
            }
        }
    }

    private void ResetProductivity()
    {
        if (m_currentPile != null)
        {
            m_currentPile.ProductionSpeed /= ProductivityMultiplier;
            m_currentPile = null;
        }
    }

    public override void GoTo(Building target)
    {
        ResetProductivity();
        base.GoTo(target);
    }

    public override void GoTo(Vector3 positon)
    {
        ResetProductivity();
        base.GoTo(positon);
    }
}
