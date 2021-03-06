//-----------------------------------------------------------------------------
// 3 Step Studio
// Copyright GarageGames, LLC 2012
//-----------------------------------------------------------------------------

function SpriteBase::setAsset(%this, %asset)
{
    %assetType = AssetDatabase.getAssetType(%asset);
    
    if (%assetType $= "ImageAsset")
    {
        %this.setImageMap(%asset);
    }
    else if (%assetType $= "AnimationAsset")
    {
        %this.animation = %asset;
        %this.playAnimation(%asset);
    }
    else
    {
        warn("Sprite::setAsset -- invalid asset: " @ %asset); 
        warn("Asset type is " @ %assetType @ ", must be either ImageAsset or AnimationAsset"); 
        return; 
    }
}

function SpriteBase::getAsset(%this)
{
    if (%this.animation !$= "")
        return strchr(%this.Animation, "{");
    else if (%this.getImageMap() !$= "")
        return strchr(%this.getImageMap(), "{");
    else
        warn("Sprite::getAsset -- No asset found on Sprite " @ %this);
}

function Sprite::setSizeFromAsset(%this, %asset, %metersPerPixel)
{
    %sizePixels = "";
    
    %assetType = AssetDatabase.getAssetType(%asset);
    
    if (%assetType $= "ImageAsset")
    {
        %imageMapAsset = AssetDatabase.acquireAsset(%asset);
        %sizePixels = %imageMapAsset.getFrameSize(0);
        AssetDatabase.releaseAsset(%imageMapAsset.getAssetId());
    }
    else if (%assetType $= "AnimationAsset")
    {
        %animationAsset = AssetDatabase.acquireAsset(%asset);
        %animationImageMapAsset = AssetDatabase.acquireAsset(strchr(%animationAsset.imagemap, "{"));
        %sizePixels = %animationImageMapAsset.getFrameSize(0);
        AssetDatabase.releaseAsset(%animationImageMapAsset.getAssetId());
        AssetDatabase.releaseAsset(%animationAsset.getAssetId());
    }
    else
    {
        warn("Sprite::setSizeFromAsset -- invalid asset: " @ %asset); 
        warn("Asset type is " @ %assetType @ ", must be either ImageAsset or AnimationAsset"); 
        return; 
    }   
    
    // Set the size of the sprite by converting the pixel size to world units
    %sizeWorld = Vector2Scale(%sizePixels, %metersPerPixel);
    %this.setSize(%sizeWorld);
}