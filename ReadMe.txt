GUI Bar Gauge - by Looney Lizard
================================

Description
-----------

This is a component that can represent a bar gauge, eg. a health bar,
ammo bar, progress bar, etc, on the GUI.

It can handle simple bars with a single texture and also more complicated
bars with different textures for the "gauge" and "value", even where the
texture sizes differ.

It has many configuration properties to allow almost any desired layout.

Important Notes
---------------

1) Import textures with Texture Type = "GUI", otherwise the sizes will not
   match and it will be difficult to impossible to place the component
   accurately.

Usage
-----

1) Add the GUIBarGauge prefab to a scene. Although it can be added as a
   child of another object, this has no effect on the component as it is
   drawn on the GUI.

2) At the very least specify the Value Texture property: you will immediately
   see the texture in the Game preview screen in the lower-left corner.

3) Manipulating the Percentage property value will slide the texture up and down,
   with a value of 100 displaying the entire texture and a value of 0 displaying
   none of the texture.

That's it! You now have a bar gauge that represents whatever value you specify
in the Percentage property.

In the next section we'll cover all the properties of GUIBarGauge and see what
they do.

Properties
----------

Transform.Position:
	The X and Y values are used to specify the location of the bar gauge in GUI
	coordinates, ie. the lower-left corner of the screen is (0, 0) and the upper
	right corner is (1, 1), so to specify the middle of the screen you would use
	(0.5, 0.5). The Z value has no effect. Use Transform.Position in conjunction
	with the Anchor property to place the component.

Transform.Rotation:
	This has no effect.

Transform.Scale:
	The X and Y values are used to scale the textures down (values between 0 and 1)
	or up (values above 1). The Z value has no effect.

Camera:
	Here you can specify a camera to use for the GUI. If not specified, the
	camera tagged as "MainCamera" (Camera.main) will be used.
	
Anchor:
	Use this to specify which point on the texture should be anchored to the
	transform position. Use this in conjunction with the Transform.Position
	X and Y values to place the component.

Gauge Texture:
	Use this to specify a static texture for the "gauge" part of the bar gauge,
	eg. it could be a container of some sort while the Value Texture looks like
	a liquid that goes up or down inside it (see Examples). This is not required
	to function.

Value Texture:
	Use this to specify the "moving" texture for the "value" part of the bar gauge.

Value Texture Pixel Inset:
	This can be used to compensate for when the Gauge Texture and Value Texture are
	not the same size. The Value Texture will be offset by the specified number of
	pixels. The direction in which the Value Texture is offset depends on the
	selected Anchor, eg. if Anchor = UpperRight and Value Texture Pixel Inset =
	(10, 20), the Value Texture's upper-right corner will be drawn 10 pixels left
	and 20 pixels down from the position represented by Transform.Position.
	As it becomes a bit confusing as to the direction of the offset/inset etc,
	the best idea is to simply place the component so that the Gauge Texture is
	in the right place and then play with the Pixel Inset until the Value Texture
	is in the right place.
	To avoid all this I suggest making the Gauge Texture and Value Texture the same
	size. This will ensure that everything lines up perfectly with Inset set to (0, 0).

On Top:
	Use this to specify which of the two textures, Gauge Texture or Value Texture,
	should be drawn on top of the other, ie. which texture should be in the
	foreground.

Direction:
	Use this to specify in which direction the bar gauge value must increase, eg.
	if BottomToTop is specified then the gauge's 0 point will be at the bottom and
	the 100 point will be at the top. With this you can handle both vertical and
	horizontal bar gauges in either direction (up, down, left or right).

Mode:
	Use this to specify how the Value Texture will be manipulated by changes in the
	Percentage property value. If Slide is selected, the 100% point remains visible
	while the rest of the texture "slides" out of view. If Clip is selected, the 0%
	point remains visible while the rest of the texture is "clipped" off.
	See Examples.

Percentage:
	The percentage value that will be represented on the bar gauge. This value is
	clamped to be greater than or equal to 0 and less than or equal to 100.


In the example scene included I have tried to showcase various combinations of
property values and many different layouts, but there are many more possibilities
than shown here. Please try different settings to achieve exactly what you
require.

Version History
---------------

1.0 - Published!

Future Enhancements
-------------------

- Rotation: Use Transform.Rotation to rotate the bar gauge to allow more than just
            vertical and horizontal bars.

- Value Texture Padding: Add the ability to "pad" the Value Texture so that a
                         Percentage of 0 will not hide the entire texture, leaving
                         a specified number of pixels. This will allow for things
                         like sliders where the "knob" remains visible even at 0%.

I would love to hear any ideas. Please leave comments on the Asset Store page.
