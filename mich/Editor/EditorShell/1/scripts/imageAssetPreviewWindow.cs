//-----------------------------------------------------------------------------
// Copyright (c) 2013 Developer
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to
// deal in the Software without restriction, including without limitation the
// rights to use, copy, modify, merge, publish, distribute, sublicense, and/or
// sell copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS
// IN THE SOFTWARE.
//-----------------------------------------------------------------------------

/// @class ImageAssetPreviewWindow
/// This class is a SceneWindow that displays a single image asset. It will
/// automatically manage displaying each of the frames in a different sprite
/// at the correct aspect ratio. After creating a SceneWindow and assigning
/// it this class, call ImageAssetPreviewWindow::display, passing it the image
/// map you would like to display. To update the display in the case of a
/// property change on the image asset, call ImageAssetPreviewWindow::update.
/// 
/// Sprites in the window have mouse events enabled, as does the window itself.
/// The sprites can be assigned a class by setting the 'spriteClass' field on
/// the window. The sprites also have a reference to the window that created
/// them so positional data can be properly extracted. This is on the 'window'
/// field. This should allow any sort of custom funniness that needs to go
/// on within the window.
/// 
/// @field scene The scene that renders the preview.
/// @field staticSpriteGroup A SimGroup that stores the t2dStaticSprites that
/// display the frames of the image.
/// @field spacing The amount of space between each frame of the image asset.
/// @field baseDimension The length of the shorter side of the camera.
/// @field imageAsset The image asset being displayed display.

/// void(ImageAssetPreviewWindow this)
/// Initializes various properties necessary for the window.
/// @param this The ImageAssetPreviewWindow.
function ImageAssetPreviewWindow::onAdd(%this)
{
    Assert(%this.getClassName() $= "SceneWindow", "ImageAssetPreviewWindow::onAdd - This is not a SceneWindow!");

    %this.scene = new Scene();
    %this.staticSpriteGroup = new SimGroup();
    %this.spacing = 2;
    %this.baseDimension = 100;
    %this.imageAsset = "";
    %this.UseObjectInputEvents = true;
    %this.UseWindowInputEvents = true;
    %this.spriteClass = "";

    %this.setScene(%this.scene);
}

/// void(ImageAssetPreviewWindow this)
/// Cleans up data allocated for this window.
/// @param this The ImageAssetPreviewWindow.
function ImageAssetPreviewWindow::onRemove(%this)
{
    if (isObject(%this.imageAsset))
        AssetDatabase.releaseAsset(%this.imageAsset);

    if (isObject(%this.scene))
        %this.scene.delete();

    if (isObject(%this.staticSpriteGroup))
        %this.staticSpriteGroup.delete();
}

/// void(ImageAssetPreviewWindow this)
/// Called when the window is first shown to make sure things are properly
/// sized.
/// @param this The ImageAssetPreviewWindow.
function ImageAssetPreviewWindow::onWake(%this)
{
    // rdbnote: this doesn't actually do anything because we don't have an image
    %this.updateSize();
}

/// void(ImageAssetPreviewWindow this, RectF newDimensions)
/// Resizes the scenes camera to maintain the correct aspect ratio.
/// @param this The ImageAssetPreviewWindow.
/// @param newDimensions The new position and size of the window.
function ImageAssetPreviewWindow::onExtentChange(%this, %newDimensions)
{
    %this.updateSize();
}

/// void(ImageAssetPreviewWindow this, ImageAsset imageAsset)
/// Displays the specified image asset in this window.
/// @param this The ImageAssetPreviewWindow.
/// @param imageAsset The image asset to display.
function ImageAssetPreviewWindow::display(%this, %imageAsset)
{
    Assert(AssetDatabase.isDeclaredAsset(%imageAsset), "ImageAssetPreviewWindow::display - Object is not a valid image asset!");

    %this.assetId = %imageAsset;
    %this.imageAsset = AssetDatabase.acquireAsset(%imageAsset);
    %this.update();
}

/// void(ImageAssetPreviewWindow this)
/// Clears the display.
/// @param this The ImageAssetPreviewWindow.
function ImageAssetPreviewWindow::clear(%this)
{
    %this.imageAsset = "";
    %this.update();
}

/// void(ImageAssetPreviewWindow this)
/// Updates the displayed image.
/// @param this The ImageAssetPreviewWindow.
/// @todo This currently does not handle "LINK" or "KEY" mode image assets.
/// @todo This doesn't take advantage of width or height when displaying
/// non-square image assets.
function ImageAssetPreviewWindow::update(%this)
{
    // Clear out the old stuff.
    %this.staticSpriteGroup.deleteContents();

    %imageAsset = %this.imageAsset;
    %scene = %this.scene;

    // Nothing doing if we don't have an image.
    if (!isObject(%imageAsset))
        return;

    // because we need to make sure the camera size is right
    %this.updateSize();

    %scene.setDebugOn(2, 3);
   
    %cameraSize = %this.getCurrentCameraSize();
    %maxWidth = getWord(%cameraSize, 0) - 1;
    %maxHeight = getWord(%cameraSize, 1) - 1;
   
    %baseX = 0;
    %baseY = 0;
    %frameCount = %imageAsset.getFrameCount();
  
    %sqrt = mSqrt(%frameCount);
    %div = mCeil(%sqrt);

    %rowSpace = (%maxWidth / %div) * 0.05;
    %colSpace = (%maxHeight / %div) * 0.05;
    
    if (%rowSpace < 1.5)
        %rowSpace = 1.5;
        
    if (%colSpace < 1.5)
        %colSpace = 1.5;
     
    %objWidth = (%maxWidth / %div) - (%rowSpace + %this.spacing);
    %objHeight = (%maxHeight / %div) - (%colSpace + %this.spacing);

    %baseX += %this.spacing;
    %baseY += %this.spacing;

    %posX = %baseX - (%maxWidth / 2) + (%objWidth / 2);
    %posY = %baseY - (%maxHeight / 2) + (%objHeight / 2);

    %rowCount = 0;
    %colCount = 0;
  
    for (%i = 0; %i < %frameCount; %i++)
    {
        %sprite = new sprite()
        {
            class = %this.spriteClass;
            superClass = ImageAssetPreviewSprite;
            scene = %scene;
            UseInputEvents = true;
            window = %this;
            tooltipprofile="GuiToolTipProfile";
            ToolTip="Each frame is displayed in order from left to right starting in the top left corner. You can drag and drop individual frames to the Animation Timeline.";
        };
     
        %sprite.setImageAsset(%this.assetId, %i);
        %sprite.setPosition(%posX, %posY);
        %sprite.setSize(%objWidth, %objHeight);
     
        %this.staticSpriteGroup.add(%sprite);
     
        if (%colCount >= %div - 1)
        {
            %rowCount++;
            %colCount = 0;
            %posX = %baseX - (%maxWidth / 2) + (%objWidth / 2);
            %posY = %baseY - (%maxHeight / 2) + (%objHeight / 2) + ((%objHeight + %rowSpace + %this.spacing) * %rowCount);
        }
        else
        {
            %colCount++;
            %posX = %baseX - (%maxWidth / 2) + (%objWidth / 2) + ((%objWidth + %colSpace + %this.spacing) * %colCount);
        }
    }
}

/// void()
/// Updates the camera size to display images at the correct aspect ratio.
function ImageAssetPreviewWindow::updateSize(%this)
{
    if (!isObject(%this.imageAsset))
        return;
   
    // Grab some size info.
    %windowSize = %this.getExtent();
    %imageSize = %this.imageAsset.getImageSize();

    %windowAR = getWord(%windowSize, 0) /  getWord(%windowSize, 1);
    %imageAR = getWord(%imageSize, 0) / getWord(%imageSize, 1);

    // Basically, instead of sizing the images correctly, we're sizing the
    // camera at the inverse of the image's aspect ratio, thereby achieving the
    // same affect.
    %newSize = resolveAspectRatio(%windowAR / %imageAR, %this.baseDimension);
    %this.setCurrentCameraPosition("0 0", %newSize);
}
