//-----------------------------------------------------------------------------
// Copyright (c) 2013 GarageGames, LLC
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

$platformFontType = ($platform $= "windows") ? "lucida console" : "monaco";
$platformFontSize = ($platform $= "ios") ? 18 : 12;

//---------------------------------------------------------------------------------------------

new GuiCursor(DefaultCursor)
{
    hotSpot = "4 4";
    renderOffset = "0 0";
    bitmapName = "^AppCore/gui/defaultCursor";
};

//---------------------------------------------------------------------------------------------
// GuiDefaultProfile is a special profile that all other profiles inherit defaults from. It
// must exist.
//---------------------------------------------------------------------------------------------
if (!isObject(GuiDefaultProfile)) new GuiControlProfile (GuiDefaultProfile)
{
    tab = false;
    canKeyFocus = false;
    hasBitmapArray = false;
    mouseOverSelected = false;

    // fill color
    opaque = false;
    fillColor = "232 240 248 255";
    fillColorHL = "251 170 0 255";
    fillColorNA = "244 244 244 52";

    // border color
    border = 1;
    borderColor    = "100 100 100 255";
    borderColorHL = "128 128 128 255";
    borderColorNA = "226 226 226 52";

    // font
    fontType = $platformFontType;
    fontSize = $platformFontSize;

    fontColor = "27 59 95 255";
    fontColorHL = "232 240 248 255";
    fontColorNA = "0 0 0 52";
    fontColorSEL= "10 10 10 255";

    // bitmap information
    bitmap = "^AppCore/gui/window";
    bitmapBase = "";
    textOffset = "0 0";

    // used by guiTextControl
    modal = true;
    justify = "left";
    autoSizeWidth = false;
    autoSizeHeight = false;
    returnTab = false;
    numbersOnly = false;
    cursorColor = "0 0 0 255";

    // sounds
    soundButtonDown = "";
    soundButtonOver = "";
};