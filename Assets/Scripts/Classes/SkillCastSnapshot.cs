using UnityEngine;

public class SkillCastSnapshot
{

    private GameObject player;
    private Vector3 mousePosition;
    private SkillData skillData;

    public GameObject Player { get => player; }
    public Vector3 MousePosition { get => mousePosition; }
    public SkillData SkillData { get => skillData; }

    public SkillCastSnapshot(GameObject pla, SkillData data)
    {
        player = pla;
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;
        skillData = data;
    }


}
