#version 430

layout (location = 0) writeonly uniform image2D outTexture;

layout (local_size_x = 32, local_size_y = 32) in;

void main(void)
{
    vec2 size = vec2(imageSize(outTexture));
    vec2 pos = gl_GlobalInvocationID.xy;
    
    imageStore(
        outTexture,
        ivec2(pos),
        vec4(pos.x / size.x, pos.y / size.y, 0.0, 1.0)
        );
}