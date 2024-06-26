﻿#version 330 core

layout(location = 0) in vec3 aPosition;
layout(location = 4) in vec3 aColor;

out vec3 vColor;

void main(void)
{
    vColor = aColor;
    gl_Position = vec4(aPosition, 1.0);
}