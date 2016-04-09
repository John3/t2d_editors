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

/// <summary>
/// Sets up the AssetTextEdit object with the string it will display when empty
/// and sets initial values for some internal fields.
/// </summary>
/// <param name="emptyString">String that is displayed when the text edit field is empty.</param>
function AssetTextEdit::initialize(%this, %emptyString)
{
    %this.emptyString = %emptyString;
    %this.setText(%this.emptyString);
    %this.emptyFlag = true;
}

/// <summary>
/// Causes the AssetTextEdit to update its "empty" state based on its current value.
/// </summary>
function AssetTextEdit::update(%this)
{
    if (%this.getText() $= "" || %this.getText() $= %this.emptyString)
        %this.emptyFlag = true;
    else
        %this.emptyFlag = false;
}

/// <summary>
/// Returns whether the emptyFlag has been set for the AssetTextEdit object
/// </summary>
function AssetTextEdit::isEmpty(%this)
{
    return %this.emptyFlag;
}

/// <summary>
/// A default onKeyPressed() handler for AssetTextEdit fields.  This setup
/// makes calls to filterText() and updateGui() script methods to allow flexibility
/// in filtering input and to allow dependent controls to be notified of changes.
/// </summary>
function AssetTextEdit::onKeyPressed(%this)
{
    %this.cursorPos = %this.getCursorPos();
    %filtered = %this.filterText();
    %this.update();
    
    if (%filtered)
        %this.setCursorPos(%this.cursorPos - 1);
    else
        %this.setCursorPos(%this.cursorPos);
    
    %this.updateGui();
} 

/// <summary>
/// A default filterText() handler for AssetTextEdit fields.
/// </summary>
/// <return>Returns true if the input contained prohibited characters</return>
function AssetTextEdit::filterText(%this)
{
    %temp = %this.getText();
    %cleanName = stripChars(%temp, "-+*/%$&§=()[].?\"#,;:!~<>|°^{}'` ");
    %this.setText(%cleanName);
    return (%temp !$= %cleanName);
}

/// <summary>
/// A default updateGui() handler for AssetTextEdit fields.  Set the
/// dependentControl field on the text edit control to point to a single element
/// and provide that element with an update() method for this to function by 
/// default.
/// </summary>
function AssetTextEdit::updateGui(%this)
{
    if (%this.dependentControl !$= "")
        %this.dependentControl.update(); 
}

/// <summary>
/// A modified version of setText for AssetTextEdit objects that causes the empty state to be
/// updated whenever the text value is set.
/// </summary>
function AssetTextEdit::setText(%this, %text)
{
    %this.text = %text;  
    %this.update();
}

function AssetTextEdit::onLoseFirstResponder(%this)
{
    if (%this.getText() $= "")
    {
        %this.text = %this.emptyString; 
        %this.emptyFlag = true; 
    }
}

function AssetTextEdit::onMouseDown(%this, %modifier, %globalPoint, %mouseClickCount)
{
    if (%this.getText() $= %this.emptyString)
        %this.text = "";
        
    %this.update();
    %this.selectAllText();
}
