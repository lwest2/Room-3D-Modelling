using UnityEngine;
using System.Collections;

public class SoundDynamic : MonoBehaviour
{
    private int m_qSamples = 1024;        // array size - number of samples
    private float m_rmsValue;             // sound level - RMS (root mean squared)
    [SerializeField]
    private float m_scaleSample = 2.0f;   // set how much the scale will vary

    private AudioSource m_source;         //audio source

    private float[] m_samples;            //the array - samples we're getting

    private float m_scaleX = 0;           //original scale on y

    public static bool IsPlayerTriggered = false;
    

    // Use this for initialization
    void Start()
    {
        m_source = GetComponent<AudioSource>(); //refernce to audio source
        m_samples = new float[m_qSamples];      //initialise the array of samples
        m_scaleX = transform.localScale.x;      //get the original scale of the object

    }

    // Update is called once per frame
    void Update()
    {
        
            // if variable is true
            if (IsPlayerTriggered)
            {

            if(!m_source.isPlaying)
               
                    m_source.Play();
                    Debug.Log("Play");
                    AnalyzeSound(); //we analyse the sound

                    //we scale the object on y based on m_rmsValue
                    Vector3 scale = transform.localScale;
                    scale.x = m_scaleX + m_scaleSample * m_rmsValue;
                    transform.localScale = scale;
                


            }

            else 
            {
                // pause    
                m_source.Pause();

                Debug.Log("Pause");

                // set E bool to false
                IsPlayerTriggered = false;
            }
        }
        
    

 
    /// <summary>
    /// we analyze the sound and we assign a value to m_rmsValue
    /// </summary>
    private void AnalyzeSound()
    {
        m_source.GetOutputData(m_samples, 0); //we get some samples 

        float sum = 0;

        for (int i = 0; i < m_samples.Length; i++)
        {
            sum += m_samples[i] * m_samples[i]; //sum squared samples
        }

        //formula for sound level
        m_rmsValue = Mathf.Sqrt(sum / m_qSamples);
    }
}
