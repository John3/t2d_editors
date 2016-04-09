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

function TagDropdownList::refresh(%this, %useAnyTag, %excludes)
{
    %this.clear();
    %assetTagsManifest = AssetDatabase.getAssetTags();
    
    if (!isObject(%assetTagsManifest))
        return;
        
    %tagCount = %assetTagsManifest.getTagCount();

    for (%i = 0; %i < %tagCount; %i++)
    {
        %tag = %assetTagsManifest.getTag(%i);

        // No tags excluded by default
        %isExcluded = -1;

        // If %excluded actually contained tags, search it for the current tag
        if (%excludes !$= "")
            %isExcluded = strstr(%excludes, %tag);

        // If there was a valid tag and it was not in the %excludes list
        if (%tag !$= "" && %isExcluded == -1)
            %this.add(%tag, %i);
    }

    if (%useAnyTag)
    {
        %this.add("Any", %i++);
        %this.setSelected(%i);
    }
    else
    {
        %this.setFirstSelected();
    }
}