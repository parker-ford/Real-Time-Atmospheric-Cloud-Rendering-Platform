using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudRendererController : MonoBehaviour
{
    public enum CloudCoverageMode{
        None = 0,
        Himilayas = 1,
        SwissAlps = 2,
        Threshold = 3,
    }
    public enum BaseCloudMode{
        SingleChannel = 0,
        AllChannel = 1,
        _2D = 2,
    }

        public enum NoiseTilingSettings{
        _128 = 128,
        _256 = 256,
        _512 = 512,
        _1024 = 1024,
        _2048 = 2048,
        _4096 = 4096,
        _8192 = 8192,
        _16384 = 16384
    };


    [Header("Texture Settings")]
    public Texture3D lowFrequencyCloudNoise;
    public Texture2D heightDensityGradient;
    public Texture2D baseCloud2D;
    public NoiseTilingSettings noiseTilingSettings = NoiseTilingSettings._4096;
    public bool resetShader = false;

    [Header("Cloud Density")]
    public BaseCloudMode baseCloudMode = BaseCloudMode.SingleChannel;
    public float densityAbsorption = 0.5f;
    public float cloudEdgeCutOff = 0.15f;
    public bool flipTransmittance = false;
    public bool cloudDensityAsTransparency = true;

    [Header("Cloud Coverage")]
    public CloudCoverageMode cloudCoverageMode = CloudCoverageMode.Himilayas;
    [Range(0.0f, 1.0f)]
    public float cloudCoverage = 1.0f;


    [Header("Atmosphere")]
    public float atmosphereLow = 1500.0f;
    public float atmosphereHigh = 5000.0f;

    [Header("Lighting")]
    public bool useLighting = false;
    public float lightIntensity = 1.0f;
    public float lightAbsorption = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        ResetShader();
    }

    void ResetShader(){
        Shader.SetGlobalTexture("_LowFrequencyCloudNoise", lowFrequencyCloudNoise);
        Shader.SetGlobalTexture("_HeightDensityGradient", heightDensityGradient);
        Shader.SetGlobalTexture("_BaseCloud2D", baseCloud2D);
    }

    // Update is called once per frame
    void Update()
    {
        if(resetShader){
            ResetShader();
            resetShader = false;
        }
        Shader.SetGlobalFloat("_DensityAbsorption", densityAbsorption);
        Shader.SetGlobalFloat("_NoiseTiling", (float)noiseTilingSettings);
        Shader.SetGlobalInt("_FlipTransmittance", flipTransmittance ? 1 : 0);
        Shader.SetGlobalInt("_CloudCoverageMode", (int)cloudCoverageMode);
        Shader.SetGlobalFloat("_CloudCoverage", cloudCoverage);
        Shader.SetGlobalFloat("_AtmosphereLow", atmosphereLow);
        Shader.SetGlobalFloat("_AtmosphereHigh", atmosphereHigh);
        Shader.SetGlobalInt("_BaseCloudMode", (int)baseCloudMode);
        Shader.SetGlobalInt("_UseLighting", useLighting ? 1 : 0);
        Shader.SetGlobalFloat("_LightIntensity", lightIntensity);
        Shader.SetGlobalFloat("_LightAbsorption", lightAbsorption);
        Shader.SetGlobalInt("_CloudDensityAsTransparency", cloudDensityAsTransparency ? 1 : 0);
        Shader.SetGlobalFloat("_CloudEdgeCutOff", cloudEdgeCutOff);
    }


}