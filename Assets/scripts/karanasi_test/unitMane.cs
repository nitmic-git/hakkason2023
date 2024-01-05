using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    private float mp = 0;
    [SerializeField] float maxMp=20;
    private float hp;
    private float maxHp;
    [SerializeField] Image hpBar;
    [SerializeField] Image mpBar;
    [SerializeField] float addMpInterval;
 
    private void Start()
    {
        maxHp = GameMane.playerHp;
        unit.transform.position = stageMane.path[0];
        StartCoroutine(addMp());
    }

    private void Update()
    {
        hp = GameMane.playerHp;

        barMane(hpBar, maxHp, hp);
        barMane(mpBar, maxMp, mp);

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

            unit.transform.position += direction * speed*(3+(GameMane.playerSpeed-3)/8)/20*Time.deltaTime;
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
            animator.speed = (6+(GameMane.playerSpeed-6)/5)/10f;

            
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

    public void barMane(Image bar,float max,float current)
    {
        bar.fillAmount = current / max;
       
    }

    public IEnumerator addMp()
    {
        while(true)
        {
            yield return new WaitForSeconds(addMpInterval);
            if(mp<=maxHp-1)
            {
                mp++;
            }
            
            
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
