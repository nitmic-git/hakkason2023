using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unitMane : MonoBehaviour
{
    [SerializeField] float speed;
    
    [SerializeField] GameObject unit;
    [SerializeField] GameObject ground;
    [SerializeField] stageMane stageMane;
    public Animator animator; // Inspector��Animator���A�T�C������
    public string targetAnimationName = "YourAnimationClipName";

    private int section=0;
    private Vector3 direction;
    private bool end = false;
    private int oldSection;

    private void Start()
    {
        unit.transform.position = stageMane.path[0];
    }

    private void Update()
    {

        //groundGene();
        if (stageMane.path[section].x<=unit.transform.position.x&&section< stageMane.path.Length-1)
        {
            section++;
            
        }

        if (stageMane.path[stageMane.path.Length - 1].x < unit.transform.position.x&&!end)
        {
            end = true;
            Debug.Log("�����I��");
        }

        if (!end)
        {
           
            direction = (stageMane.path[section] - stageMane.path[section - 1]).normalized;

            unit.transform.position += direction * speed*GameMane.playerSpeed/10*Time.deltaTime;
        }

        
        if(section!=oldSection)
        {
            

            Vector3 lookDirection = stageMane.path[section]- stageMane.path[section - 1];
           

            // �����x�N�g������p�x���v�Z
            float angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

            // Z�����g���ĉ�]��K�p
            unit.transform.rotation = Quaternion.Euler(0, 0, angle);
           
            oldSection = section;
        }

        if (animator != null)
        {
            // �A�j���[�V�����N���b�v�̑��x��ύX
            animator.speed = GameMane.playerSpeed/10f;

            
        }

        if(Input.GetKeyDown(KeyCode.A))
        {
            GameMane.playerSpeed++;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            GameMane.playerSpeed--;
        }

    }

    public void groundGene()
    {
        SpriteRenderer sp = ground.GetComponent<SpriteRenderer>();
        if(Input.GetMouseButton(0))
        {
            ground.transform.localScale = new Vector3(2, 1, 1);
        }
    }
}
