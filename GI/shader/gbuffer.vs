#version 330 core
layout (location = 0) in vec3 aPos;
layout (location = 1) in vec3 aNormal;
layout (location = 2) in vec2 textureCoords;
uniform mat4 model;
uniform mat4 view;
uniform mat4 projection;
out vec3 worldPos;
out vec3 viwNormal;
out vec2 texCoord;
out float depth;

void main()
{   

    viwNormal =transpose(inverse(mat3(view*model))) * aNormal;
    vec4 world = view*model*vec4( aPos, 1.0);
    worldPos = world.xyz;
    texCoord = textureCoords;
    gl_Position = projection*view*model*vec4( aPos, 1.0);
    

}