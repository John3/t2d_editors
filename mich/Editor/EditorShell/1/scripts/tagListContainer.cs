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

function TagListContainer::onAdd(%this)
{
    // create our list of tags for the current object
    if (!isObject(%this.tagItemList))
        %this.tagItemList = new SimSet();

    %this.clearTagItemList();
    
}

//-----------------------------------------------------------------------------

function TagListContainer::clearTagItemList(%this)
{
    if ( !isObject(%this.tagItemList) )
        return;

    while (%this.tagItemList.getCount())
        %this.tagItemList.getObject(0).delete();
}

//-----------------------------------------------------------------------------

function TagListContainer::populateTagList(%this, %assetID)
{
    %this.clearTagItemList();
    
    // populate the tag list container with the current asset's tags
    %assetTags = AssetDatabase.getAssetTags();

    if (!isObject(%assetTags))
        return;
    
    %assetTagCount = %assetTags.getAssetTagCount(%assetID);
    %tagButton = %this.createTagButton(-1, "temp");
    %posX = %this.Position.x;
    %posY = %this.Position.y;
    %extentX = %this.Extent.x;
    %extentY = %assetTagCount * %tagButton.Extent.y;
    %this.resize(%posX, %posY, %extentX, %extentY);
    %tagButton.delete();
    if (%this.getCount() > 0)
    {
        %found = false;
        for (%j = 0; %j < %assetTagCount; %j++)
        {
            %taglistcount = %this.tagItemList.getCount();
            for (%l = 0; %l < %taglistcount; %l++)
            {
                if (%this.tagItemList.getObject(%l).tagText $= %assetTags.getAssetTag(%j))
                    %found = true;
            }
        }
        if (!%found)
        {
            %c = %this.tagItemList.getCount();
            for (%k = 0; %k < %c; %k++)
            {
                %button = %this.tagItemList.getObject(%k);
                %this.tagItemList.remove(%button);
                %button.delete();
            }
        }
        %obj = %this.getObject(0);
        while (isObject(%obj))
        {
            %this.remove(%obj);
            %obj = %this.getObject(0);
        }
    }
    for (%i = 0; %i < %assetTagCount; %i++)
    {
        %tag = %assetTags.getAssetTag(%assetID, %i);
        %this.addTagItem(%tag);
        %button = %this.tagItemList.getObject(%i);
        %button.Position = "2" SPC (%i * %button.Extent.y);
        %this.addGuiControl(%button);
    }
}

//-----------------------------------------------------------------------------

function TagListContainer::removeTagItem(%this, %tagName)
{
    if (%tagName $= "")
        return;

    %count = %this.tagItemList.getCount();
    for (%i = 0; %i < %count; %i++)
    {
        %obj = %this.tagItemList.getObject(%i);
        if (%obj.tagText $= %tagName)
        {
            %this.tagItemList.remove(%obj);
            break;
        }
    }
}

//-----------------------------------------------------------------------------

function TagListContainer::addTagItem(%this, %tagName)
{
    if (%tagName $= "")
        return;
    
    // create a gui element and add it to the container
    %buttonCount = %this.tagItemList.getCount();
    %tagButton = %this.createTagButton(%buttonCount, %tagName);
    %this.tagItemList.add(%tagButton);
}

//-----------------------------------------------------------------------------

function TagListContainer::getTagCount(%this)
{
    return %this.tagItemList.getCount();
}

//-----------------------------------------------------------------------------

function TagListContainer::getTagName(%this, %index)
{
    if (%index >= 0 && %index < %this.tagList.getCount())
        return %this.tagItemList.getObject(%index).tagText;
}

//-----------------------------------------------------------------------------

function TagListContainer::createTagButton(%this, %index, %tagName)
{
    if (%tagName $= "")
        return;

    %tool = %this.tool;
    %control = new GuiControl()
    {
        canSaveDynamicFields="0";
        isContainer="1";
        Profile="GuiTransparentProfile";
        HorizSizing="relative";
        VertSizing="relative";
        Position="0 0";
        Extent="180 29";
        MinExtent="8 2";
        canSave="1";
        Visible="1";
        hovertime="1000";
        index=%this.getCount();
        tool=%tool;
    };
    
    %removeBtn = new GuiImageButtonCtrl()
    {
        canSaveDynamicFields="0";
        class="DeleteTagButton";
        isContainer="0";
        Profile="GuiDefaultProfile";
        HorizSizing="right";
        VertSizing="bottom";
        Position="0 2";
        Extent="25 25";
        MinExtent="8 2";
        canSave="1";
        Visible="1";
        hovertime="1000";
        toolTipProfile="GuiToolTipProfile";
        toolTip="Remove this tag from the asset.";
        wrap="0";
        buttonType="PushButton";
        NormalImage="EditorShell:redClose";
        HoverImage="EditorShell:redCloseHover";
        DepressedImage="EditorShell:redCloseDown";
        InactiveImage="EditorShell:redCloseInactive";
    };
    %control.addGuiControl(%removeBtn);

    %label = new GuiTextCtrl(){
        canSaveDynamicFields="0";
        internalName = "TagContainerTextControl";
        isContainer="0";
        Profile="GuiDefaultProfile";
        HorizSizing="right";
        VertSizing="bottom";
        Position="31 2";
        Extent="140 25";
        MinExtent="8 2";
        canSave="1";
        Visible="1";
        Active="0";
        hovertime="1000";
        text=%tagName;
        maxLength="1024";
    };
    %control.addGuiControl(%label);
    %control.tagText = %tagName;

    return %control;
}

//-----------------------------------------------------------------------------

function DeleteTagButton::onClick(%this)
{
    %parent = %this.getParent();
    %parentTool = %parent.tool;
    %tag = %parent.findObjectByInternalName("TagContainerTextControl").text;
    %parentTool.removeTag(%tag);
}