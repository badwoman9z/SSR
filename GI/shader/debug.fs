#version 330 core
uniform sampler2D DepthBuffer;


in vec2 TexCoord;
flat in vec2 TexSize;

layout(location = 0) out vec4 FragmentColor;

float LinearizeDepth(vec2 uv)
{
  float n = 1.0;		// camera z near
  float f = 1000.0;		// camera z far
  float z = textureLod(DepthBuffer, uv, 5).x;
  return (2.0 * n) / (f + n - z * (f - n));
}

void main(void)
{
	float depth = LinearizeDepth( TexCoord );
	//depth = textureLod(DepthBuffer, TexCoord, 2).x;
	FragmentColor = vec4(1.0,1.0,1.0,1.0)*depth;
}
