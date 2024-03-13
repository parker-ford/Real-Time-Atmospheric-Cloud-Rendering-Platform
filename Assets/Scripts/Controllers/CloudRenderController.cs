using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudRenderController : MonoBehaviour
{
    public Shader shader;
    public Texture3D lowFrequencyCloudNosie;
    public Texture3D noise;
    public bool resetShader = false;
    public float densityAbsorption = 0.5f;
    public enum CloudCubeMode{
        DistanceBeers,
        NoiseBeers,
        LightBeers
    }
    public CloudCubeMode cloudCubeMode = CloudCubeMode.DistanceBeers;
    public float noiseTiling;
    public float lightIntensity;
    public float lightAbsorption;
    // Start is called before the first frame update
    void Start()
    {
        SetTextures();
    }

    // Update is called once per frame
    void Update()
    {
        if(resetShader){
            SetTextures();
            resetShader = false;
        }
        Shader.SetGlobalFloat("_DensityAbsorption", densityAbsorption);
        Shader.SetGlobalInt("_CloudCubeMode", (int)cloudCubeMode);
        Shader.SetGlobalFloat("_NoiseTiling", noiseTiling);
        Shader.SetGlobalFloat("_LightIntensity", lightIntensity);
        Shader.SetGlobalFloat("_LightAbsorption", lightAbsorption);
    }
    void SetTextures(){
        Shader.SetGlobalTexture("_LowFrequencyCloudNoise", lowFrequencyCloudNosie);
        Shader.SetGlobalTexture("_Noise", noise);
    }
}
