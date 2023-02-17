using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Random = UnityEngine.Random;

public class TestManager : MonoBehaviour
{
    //���̃v���n�u
    public GameObject Cube;
    public GameObject Wall;
    //public GameObject Camera;
    private GameObject CopyCube;

    //�s��
    [Header("Set row number of Sphere")]
    [Range(1, 10)]
    public int row = 1;
    //��
    [Header("Set colum number of Sphere")]
    [Range(1, 10)]
    public int colum = 1;
    //����(��)�̃T�C�Y��ݒ�
    [Header("Set size of Large Sphere")]
    [Range(1, 10)]
    public float l_size = 3;
    //����(��)�̃T�C�Y��ݒ�
    [Header("Set size of Nomall Sphere")]
    [Range(1, 10)]
    public float n_size = 2;
    //����(��)�̃T�C�Y��ݒ�
    [Header("Set size of Small Sphere")]
    [Range(1, 10)]
    public float s_size = 1;
    //���̊Ԃ̋�����ݒ�
    [Header("Set length between spheres")]
    [Range(1, 10)]
    public float sphere_len = 1;
    //���̊Ԃ̉��s����ݒ�
    [Header("Set Depth spheres")]
    [Range(1, 10)]
    public float sphere_dep = 1;
    //���̌Q�ƃJ�����̋�����ݒ�
    [Header("Set length between cam and obj")]
    [Range(1, 10)]
    public float cam_len = 1;
    //��Փx(���̊Ԃ̂΂���x����)��ݒ�
    [Header("Set Challenge Level")]
    [Range(-30, 1000)]
    public int level = 0;
    //���X�g�̍쐬
    List<int> numbers = new List<int>();
    List<int> lev_set = new List<int>();
    int[] lev_num = new int[3];
    // Start is called before the first frame update
    void Start()
    {
        //���̂̐������X�g�ɒl�����Ɋi�[
        int start = 0;
        //���̑S�̂̐����Z�o
        int num = row * colum;
        float num_float = (float)num;
        for (int i = start; i <= num-1; i++)
        {
            numbers.Add(i);
        }

        //���̊Ԃ̋�����ݒ�
        float ball_size = (float)l_size;
        float bet_len = ball_size  + sphere_len;

        //�e��Փx�ݒ�������_���Ɋ��蓖��
        for (int i = start + 1; i <= 3; i++)
        {
            lev_set.Add(i);
        }
        for (int i = start; i < 3; i++)
        {
            int index = Random.Range(0, lev_set.Count);
            int RNG = lev_set[index];
            lev_set.RemoveAt(index);
            lev_num[i] = RNG;
        }

        while (numbers.Count > 0)
        {
            //���X�g�̒�����l�𔲂��o���A���̒l�����X�g����폜
            int index = Random.Range(0, numbers.Count);
            int RNG = numbers[index];
            numbers.RemoveAt(index);


            //�z��ɔԍ����Ɋi�[����悤�ȃC���[�W
            int sum = 0;
            int x=0;
            int y=0;
            for (x = 1; x < row + 1; x++)
            {

                for (y = 1; y < colum + 1; y++)
                {
                    sum++;
                    if (RNG == sum)
                    {
                        break;
                    }
                }
                if (RNG == sum)
                {
                    break;
                }
            }
            if (x > row)
            {
                x = row;
                y = colum;
            }

            //���s���������_���ɐ���
            float rng_len = Random.Range(1, 4);
            float z = rng_len * sphere_dep;

            //�傫���������_���Ɋ��蓖��
            int rng = 0;
            int lev_size = 0;
            rng = Random.Range(0, 101 + level);
            if(rng  < 0)
            {
                while (rng < 0)
                {
                    rng = Random.Range(0, 101 + level);
                }
            }

            Debug.Log(rng);
            if (rng < 34)
            {
                lev_size = 1;
            }
            else if(33 < rng & rng <67)
            {
                lev_size = 2;
            }
            else if (66 < rng)
            {
                lev_size = 3;
            }
            //���̂̃T�C�Y�����蓖��
            Debug.Log(lev_size);
            if (lev_num[0] == lev_size)
            {
                //���̂��C���X�^���X������(��������)
                CreateCube(x, y, z, bet_len, l_size);

            }
            else if (lev_num[1] == lev_size)
            {
                //���̂��C���X�^���X������(��������)
                CreateCube(x, y, z, bet_len, n_size);
            }
            else if (lev_num[2] == lev_size)
            {
                //���̂��C���X�^���X������(��������)
                CreateCube(x, y, z, bet_len, s_size);
            }

        }

        //���̌Q�̒��S���W���l�����J�����𒆐S�Ɉړ�������
        float Cam_x = (row + 1) * bet_len / 2;
        float Cam_y = (colum + 1) * bet_len / 2;

        //�J�����̈ʒu��ύX
        Vector3 tmp = GameObject.Find("OVRCameraRig").transform.position;
        GameObject.Find("OVRCameraRig").transform.position = new Vector3(Cam_x,Cam_y, tmp.z - cam_len * 10);
        //Instantiate(Camera, new Vector3(Cam_x, Cam_y, -cam_len * 10), Quaternion.identity);
        //�ǂ̐���
        float Wall_z = 4 * sphere_dep * bet_len;
        Instantiate(Wall, new Vector3(Cam_x, Cam_y, Wall_z), Quaternion.Euler(-90, 0, 0));

        //�傫���ƍ��W�����Ƃɋ��̂𐶐�����
        void CreateCube(int x,int y,float z,float len,float scale)
        {
            CopyCube = Instantiate(Cube,new Vector3(x * len, y * len, z * len), Quaternion.identity);
            CopyCube.transform.localScale = new Vector3(scale, scale, scale);
        }

        /*
        //���̂̑傫�����ϓ��ɂȂ�
        int[] ChangeLevel1(int SUM)
        {
            int[] array = new int[3];
            array[0] = SUM / 3;
            array[1] = array[0] / 2;
            array[2] = SUM - array[0] - array[1];

            return array;
        }
        
        //����̑傫���݂̂�5���A���̂ق��̓����_��
        int[] ChangeLevel2(float SUM,int sum)
        {
            int[] array = new int[3];
            float r1 = Random.Range(0, 1);
            float r2 = Random.Range(0, 1);
            float r3 = Random.Range(0, 1);
            float max_value =SUM * r1 * r2 / 2;
            float ran_value = (SUM - max_value) * r3;
            int fir_value = (int)Math.Floor(max_value);
            int sec_value = (int)Math.Floor(ran_value);
            int thi_value = sum - fir_value - sec_value;

            array[0] = fir_value;
            array[1] = sec_value;
            array[2] = thi_value;

            return array;
        }

        //����̑傫�������ɒ[�ɏ��Ȃ��Ȃ�
        int[] ChangeLevel3(float SUM, int sum)
        {
            int[] array = new int[3];
            float r1 = Random.Range(0, 1);
            float r2 = Random.Range(0, 1);
            float max_value = SUM * r1 * r1;
            float ran_value = (SUM - max_value) * r2;
            int fir_value = (int)Math.Floor(max_value);
            int sec_value = (int)Math.Floor(ran_value);
            int thi_value = sum - fir_value - sec_value;

            array[0] = fir_value;
            array[1] = sec_value;
            array[2] = thi_value;

            return array;
        }
        */

        //https://ics.media/entry/11292/

    }




}
