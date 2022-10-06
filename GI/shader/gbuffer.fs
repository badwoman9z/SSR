#version 330 core
layout(location = 0) out vec3 gnormal;
layout(location =1) out vec4 gposition_depth;
layout(location =2) out vec3 gcolor;
uniform sampler2D texture_diffuse1;
uniform vec3 LightPos;
uniform mat4 model;
uniform mat4 view;
in vec3 worldPos;
in vec3 viwNormal;
in vec2 texCoord;
in float depth;
uniform float u_Near = 0.1;
uniform float u_Far = 1000.0f;
float LinearizeDepth(float vDepth)
{
    float z = vDepth * 2.0 - 1.0; 
    return (2.0 * u_Near * u_Far) / (u_Far + u_Near - z * (u_Far - u_Near));    
}
void main()
{   
    vec4 LightInViewPos = view*model*vec4(LightPos,1.0);
    vec3 wi = normalize(vec3(LightInViewPos.xyz)-worldPos);
    float costh = max(dot(wi,viwNormal),0.0);
    

   gnormal = normalize(viwNormal);
   gposition_depth.xyz = worldPos;
   gposition_depth.a = LinearizeDepth(gl_FragCoord.z); // Divide by FAR if you need to store depth in range 0.0 - 1.0 (if not using floating point colorbuffer)

    gcolor = texture(texture_diffuse1,texCoord).rgb*costh;

    
}


























