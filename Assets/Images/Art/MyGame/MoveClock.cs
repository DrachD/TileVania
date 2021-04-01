using UnityEngine;

public class MoveClock : MonoBehaviour
{
    [SerializeField] private Transform clock_tran;
    private void Awake()
    {
        clock_tran = GetComponent<Transform>();
    }
    private void Start()
    {
    }
    float curTime = 0f;
    int limitOnChange = 1;
    int value_z = -6;
    int reset_z = 0;
    private void FixedUpdate()
    {
        curTime += Time.deltaTime;

        if (curTime >= limitOnChange)
        {
            curTime = 0;
            reset_z += (-value_z);
            clock_tran.Rotate(0, 0, value_z);

            if (reset_z >= 360)
            {
                clock_tran.Rotate(0, 0, 360);
                reset_z = 0;
            }
        }
    }
}
