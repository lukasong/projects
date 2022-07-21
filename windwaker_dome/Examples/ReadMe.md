Windwaker Skybox =)
======================================================================
There are two ways that this can work. I included example scenes of both.

1) Setup One: The colored background on a shader and material applied to the skybox for baking lighting, and a sphere around the world with the actual bubbles on it.
2) Setup Two: Everything just on the skybox.

- If you want to use setup one, you make a material with Windwaker Dome/Lighting Skybox on the Skybox and a material with Windwaker Dome/Bubbles Sphere on a sphere around your world. There is a prefab for the sphere in the Examples folder.
- If you want to use setup two, you make a material with Windwaker Dome/Bubbles Skybox on the Skybox.

Why would I want to use <x> over <y>?
- You may not want the bubbles that are updated every millisecond to reflect on the lighting as it can be intensive, depending on your setup for lighting that is. The first method allows just for the blue-green banding colors in the background to contribute. You can't really bake an animated material.
- Scaling, precision, and materials may behave weirder on the Skybox simply due to how large it is and how Unity handles it.
- Just the Skybox is simpler.
- Just the Skybox is one less material (kind of? you'll still have a skybox material anyways) and one less sphere.

I suggest just testing both and seeing which fits you better! I included examples of both for a reason.

Settings on the Shaders
====================================================================== 
- Low Color is the color towards the middle of the skybox, while High Color is on the top and bottom. Color banding makes it repeat itself more ~ kinda like stripes ~ I noticed the original game had a bit more than a simple gradient and banded a bit.
- Bubble Color is the color of the bubble,
- Bubble Power is how bright the bubble is on the background
- Bubble Scale is the scale of the bubbles as a whole (how big they all are)
- Bubble Size is the size of individual bubbles, specifically, how thick the borders are and how empty the centers of the bubbles are, if that makes sense
- Bubbles Amount is how many bubbles drift around the sky, higher actually equals less here
- Bubble Distortion is a toggle that adds a bit more wave and distortion to the bubbles
- Distortion Size controls how many waves
- Distortion Power controls how big the waves are