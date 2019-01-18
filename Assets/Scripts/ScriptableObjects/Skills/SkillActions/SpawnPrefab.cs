using System.Collections;
using UnityEngine;

[CreateAssetMenu]
public class SpawnPrefab : SkillAction
{
    public GameObject prefab;
    public TargetPositionType Target;

    [ConditionalField("Target", TargetPositionType.Coordinate)]
    public Vector2 Coordinate;
    public float localXAxisOffset = 0f;
    public float localYAxisOffset = 0f;
    [Range(-180f, 180f)]
    public float angleOffset = 0f;

public override IEnumerator Action(MonoBehaviour skill, SkillCastSnapshot skillCastSnapshot)
    {
        Vector3 location = Vector3.zero;
        Vector3 offset = new Vector3(localXAxisOffset, localYAxisOffset, 0f);
        Quaternion rotation = Quaternion.identity;

        switch (Target)
        {
            case TargetPositionType.Player:
                location = skillCastSnapshot.Player.transform.position;
                rotation = skillCastSnapshot.Player.transform.rotation;
                break;
            case TargetPositionType.Auto:
                //setup auto
                break;
            case TargetPositionType.Direction:
                location = skillCastSnapshot.Player.transform.position;
                rotation = Quaternion.FromToRotation(skillCastSnapshot.Player.transform.position, skillCastSnapshot.MousePosition); 
                break;
            case TargetPositionType.Mouse:
                location = skillCastSnapshot.MousePosition;
                break;
            case TargetPositionType.Unit:
                //setup unit
                break;
            case TargetPositionType.Coordinate:
                location = new Vector3 (Coordinate.x, Coordinate.y);
                break;
            default:
                Debug.Log("Check SpawnPrefab's Target Type");
                break;
        }

        location += rotation * offset;
        rotation *= Quaternion.Euler(Vector3.forward * -angleOffset);

        Instantiate(prefab, location, rotation);

        yield return null;

    }
}
