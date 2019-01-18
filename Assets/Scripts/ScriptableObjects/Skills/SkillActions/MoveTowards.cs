using System.Collections;
using UnityEngine;

[CreateAssetMenu]
public class MoveTowards : SkillAction
{

    public TargetPositionType Target;
    public bool CheckCollision;
    public bool IsDamage;

    [ConditionalField("Target", TargetPositionType.Coordinate)]
    public Vector2 Coordinate;
    public bool FixedRange;
    public float Range;

    public override IEnumerator Action(MonoBehaviour skill, SkillCastSnapshot skillCastSnapshot)
    {
        Vector3 location = Vector3.zero;
        Vector3 offset = Vector3.zero;
        
        switch (Target)
        {
            case TargetPositionType.Player:
                location = skillCastSnapshot.Player.transform.position;
                break;
            case TargetPositionType.Auto:
                //setup auto
                break;
            case TargetPositionType.Direction:
                offset = skillCastSnapshot.MousePosition - skillCastSnapshot.Player.transform.position;
                location = skillCastSnapshot.Player.transform.position + Vector3.ClampMagnitude(offset, Range);
                break;
            case TargetPositionType.Mouse:
                offset = skillCastSnapshot.MousePosition - skillCastSnapshot.Player.transform.position;
                if (Range * Range < offset.sqrMagnitude)
                    location = skillCastSnapshot.Player.transform.position + Vector3.ClampMagnitude(offset, Range);
                else
                    location = skillCastSnapshot.MousePosition;
                break;
            case TargetPositionType.Unit:
                //setup unit
                break;
            case TargetPositionType.Coordinate:
                location = new Vector3(Coordinate.x, Coordinate.y);
                break;
            default:
                Debug.Log("Check MoveTowards' Target Type");
                break;
        }



        yield return null;

    }

    private void Move()
    {

    }

    private void ForceMove()
    {

    }

}

