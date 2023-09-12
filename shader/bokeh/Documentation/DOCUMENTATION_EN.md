Bokeh Studio is broken up into a lot of little tabs. I'll split the documentation up into parts matching these tabs, with a few things separate. 

Important Notes:
- There are a lot of example materials in "Examples" and example prefabs in "Prefabs", both in the Resources folder.
- You need a depth-light to use this in VRChat, or real-time lighting in the world. Otherwise, depth information is not fed to the shader (but you can use it in "Always" mode withut). This is included in the prefabs already and exists in the prefab folder on its own.
- I suggest using "High Quality" mode for production (in your photographs or whatnot) and leaving it on lower quality for testing. This is so you can have a faster workflow and use less resources in the process.
- Not suggested for use in real-time situations, more-so for photographs due to how resource intense it is (but it can be used in real-time if you want).

Separate Things:
- High Quality Mode: For actual use, disable when testing. Will take a few seconds to compile and will perform worse, but will look much, much better. Uses more samples to form the shapes in more complete detail, which is particularly noticable at larger bokeh sizes.
- Language: This changes the language of the UI and saves per-material.

Guide Map:
- Guide Map: This is the shape that is used for the bokeh size. Bright values on the image (red, green, blue, white) will result in the shape being drawn on each blur point and dark values on the image (black, grey) will result in that part of the image being excluded from the shape. You can, of course, combine in-between to make "softer" shapes with edges that fade out.
- Randomize Bokeh Shapes: Allows you to use spritesheets with different maps inside of it to have various bokeh shapes drawn across the screen.
- Randomize Style: You can either have the shapes change over time or change based on what point is being blurred into a bokeh. The former will have the bokehs always be uniform in shape and change over time, for example. You can combine them as well.
- Randomize Speed: How fast the shapes will change when time is considered as a factor.
- Randomize Variation: How much variation between regions on the screen are considered as a factor (ex. higher values will have more shapes in smaller areas).
- Random X Rows: How many rows of shapes are in the spritesheet (ex. for a 4x4 spritesheet, this would be 4).
- Random Y Rows: How many columns of shapes are in the spritesheet (ex. for a 4x4 spritesheet, this would be 4).

Focal Settings:
- Focal Mode: There are three modes: Manual, Automatic, and Always.
- Manual allows you to choose a specific depth value to compare to the current depth at each pixel.
- Automatic will use the coordinates provided (by default the center of the screen) to tap the depth of that pixel and then compare it to the current depth at every other pixel.
- Always will always blur every portion of the screen equally, like a traditional blur.

Camera Control:
- Shape Size: Controls how large of an area is considered when blurring each tap position (ex. a higher number will result in a greater distance between each shape sample step and each point on the shape).
- Bokeh Power: How much of a factor that depth plays in the size of each shape on each tapped position (ex. a higher number will result in a greater difference between the size of shapes at different depths).
- Aperature: How powerful each tap and its considered factors are when blurring (ex. a higher number will result in smaller shapes because the values are more "normalized". (sorry, this is confusing (i'll rewrite it one day))).

Additional Factors:
- There are two additional factors: "Close-Up Depth" and "Luma". Close-Up Depth helps stop strong blurring when something is very close to the camera, but out of focus. Luma creates stronger blurring on brighter areas of the screen, which can be used to create a "glow" effect.
- The influence values for each control how strongly this changes the size of the bokeh shapes.
- "End" for Close-Up Depth changes the distance that is considered "close" and "Minimum" for luma changes the minimum brightness that is considered "bright".

Animation Settings:
- These options allow you to either change all of the shapes on the screen at the same time or change each one differently based on the tap position.
- Animation Variation changes how much different regions of the screen are considered as a factor when changing the shapes (ex. higher values will have more variation in the animation between shapes).
- "Rotation Bokehs" spins the shapes around. "Scale Bokehs" shrinks and grows the shapes.
- "Local" means that each bokeh will be animated differently (ex. using the animation variation property above). "Universal" means that all bokehs will be animated the same way.

Clean Edges:
- Provides a smoother transition between blurring around the desired focal depth. When this on, you'll notice that not only will the subjects not be blurred, but so will the area around them as it smoothly fades to a blur around it. Helps prevent seeing the subject in the blurred samples themself.
- Blending Radius: How big of an area is considered for this transition from unblurred to blurred.
- CoC Radius: How big of an area is considered when tapping for the center of confusion.

Lighting Settings:
- Accentuate Bokehs: Brings out the vibrance of tapped areas.
- Expose Bokehs: Makes the bokehs brighter.
- Tonemap Bokehs: Applies a tonemapping filter (think cinematic color grading, or something to that effect) to the bokehs.
- Color Mode: Will apply a color filter to either the bokeh shapes or the screen based on the selected mode.
- HSV Controls: Will allow you to edit either the hue, saturation, or value of the bokeh shapes or the screen based on the selected "Tap Based" mode.

Technical Settings:
- Cull Distance: How far away from the center of the object will the bokeh stop being rendered.
- Dithering: Helps prevents from seeing the individual points on a shape by randomizing each point's position slightly.
- Max Diameter: The maximum size of a bokeh shape.
- Far Plane: The far plane of the camera. This is used to determine the distance of the bokeh shapes.
- VRC Camera Only: Only render in VRChat photographs and cameras. If "VRC Camera Preview" is selected, it will also render in the camera preview.