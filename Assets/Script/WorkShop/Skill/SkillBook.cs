using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class SkillBook : MonoBehaviour
{
    public List<Skill> skillsSet = new List<Skill>();
    public GameObject[] skillEffects;
    List<Skill> DulationSkills = new List<Skill>();

    Player player;
    public void Start()
    {
        // ����ʡ�ŵ�ҧ� ����� List
        player = GetComponent<Player>();

        skillsSet.Add(new FireballSkill());
        skillsSet.Add(new HealSkill());
        skillsSet.Add(new BuffSkillMoveSpeed());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            UseSkill(0); // ��ʡ�ŷ�� 1 (Fireball)
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            UseSkill(1); // ��ʡ�ŷ�� 2 (Heal)
        }
        else if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            UseSkill(2); // ��ʡ�ŷ�� 3 (Buff Move Speed)
        }
        // �ѻവʡ�ŷ���ռŵ�����ͧ
        for (int i = DulationSkills.Count - 1; i >= 0; i--)
        {
            DulationSkills[i].UpdateSkill(player);
            if (DulationSkills[i].timer <= 0)
            {
                DulationSkills.RemoveAt(i);
            }
        }
    }

    public void UseSkill(int index)
    {
        if (index >= 0 && index < skillsSet.Count)
        {
            Skill skill = skillsSet[index];
        
            if (!skill.IsReady(Time.time))
            {
                Debug.Log($"Skill '{skill.skillName}' is on cooldown. Time remaining: {skill.lastUsedTime + skill.cooldownTime - Time.time:F2}s");
                return; // ����÷ӧҹ���ʡ�ŵԴ��Ŵ�ǹ�
            }
            GameObject g = Instantiate(skillEffects[index], transform.position, Quaternion.identity, transform);
            Destroy(g, 1);
            skill.Activate(player);
            skill.TimeStampSkill(Time.time); // �ѹ�֡���ҷ����ʡ��
            // ��Ǩ�ͺ�����ʡ�ŷ���ռŵ�����ͧ�������
            if (skill.timer > 0)
            {
                DulationSkills.Add(skill);
            }
        }
    }
    private void OnDrawGizmos()
    {
        // Set the gizmo color
        Gizmos.color = Color.yellow;
        // Draw a wire sphere at the player's position with the fireball's search radius
        Gizmos.DrawWireSphere(transform.position, 5);
        
    }
}
