Shader "Custom/XrayVFX"
{    
    SubShader
    {
        Tags { "Queue"="Transparent+1" }        // rendered after all transparent objects (queue = 3001)
        Pass { Blend Zero One }                 // makes the material transparent        
    }
}
