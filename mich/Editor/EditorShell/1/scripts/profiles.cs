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

if (!isObject(GuiWindowProfile)) new GuiControlProfile (GuiWindowProfile : GuiDefaultProfile)
{
    opaque = true;
    border = 0;
    fillColor = "232 240 248 255";
    fillColorHL = "251 170 0 255";
    fillColorNA = "255 255 255 52";
    fontColor = "27 59 95 255";
    fontColorHL = "232 240 248 255";
    text = "untitled";
    bitmap = "^EditorShell/gui/images/window";
    textOffset = "5 5";
    hasBitmapArray = true;
    justify = "center";
    
    fontType = "Arial Bold";
    fontSize = 16;
};


//-----------------------------------------------------------------------------

if (!isObject(GuiButtonProfile)) new GuiControlProfile (GuiButtonProfile)
{
    opaque = true;
    border = -1;
    fontColor = "white";
    fontColorHL = "229 229 229 255";
    fixedExtent = true;
    justify = "center";
    canKeyFocus = false;
    fontType = $platformFontType;
    bitmap = "^EditorShell/gui/images/smallButtonContainer";
};

// ----------------------------------------------------------------------------

if (!isObject(GuiMLTextProfile)) new GuiControlProfile (GuiMLTextProfile)
{
    border=false;

    // font
    fontType = "Open Sans";
    fontSize = 19;

    fontColor = "27 59 95 255";
    fontColorHL = "232 240 248 255";
    fontColorNA = "0 0 0 52";
    fontColorSEL= "10 10 10 255";

    modal = true;
    justify = "left";
    returnTab = false;
    numbersOnly = false;
    cursorColor = "0 0 0 255";

    fontColorLink = "255 96 96 255";
    fontColorLinkHL = "0 0 255 255";
    autoSizeWidth = true;
    autoSizeHeight = true;  
};

// ----------------------------------------------------------------------------

if (!isObject(GuiMLWhiteTextProfile)) new GuiControlProfile (GuiMLWhiteTextProfile : GuiMLTextProfile)
{
    fontColor = "229 229 229 255";
    fontType = "Arial";
    fontSize = 16;
    border = false;
};

// ----------------------------------------------------------------------------

if (!isObject(GuiObjectEditBoxProfile)) new GuiControlProfile (GuiObjectEditBoxProfile)
{
    fontSize = 16;
    opaque = false;
    fillColor = "232 240 248 255";
    fillColorHL = "251 170 0 255";
    fillColorNA = "127 127 127 52";
    border = -2;
    borderColor = "40 40 40 10";
    bitmap = "^EditorShell/gui/images/textEdit_transparent";
    textOffset = "4 2";
    fontColor = "27 59 95 255";
    fontColorHL = "232 240 248 255";
    fontColorNA = "0 0 0 52";
    fontColorSEL= "10 10 10 255";
    autoSizeWidth = false;
    autoSizeHeight = false;
    tab = false;
    canKeyFocus = false;
    returnTab = false;
    Modal=true;
    fontType = "Open Sans";
    fontSize = 16;
    justify = "left";
};

// ----------------------------------------------------------------------------

if (!isObject(GuiSeparatorProfile)) new GuiControlProfile (GuiSeparatorProfile : GuiDefaultProfile)
{
    opaque = false;
    border = false;
    borderMargin = -2;
};

// ----------------------------------------------------------------------------

if (!isObject(GuiLargeButtonContainer)) new GuiControlProfile (GuiLargeButtonContainer : GuiButtonProfile)
{
    opaque = false;
    border = -2;
    bitmap = "^EditorShell/gui/images/largeButtonContainer";
};

// ----------------------------------------------------------------------------

// ----------------------------------------------------------------------------
if (!isObject(GuiTransparentProfile)) new GuiControlProfile (GuiTransparentProfile : GuiDefaultProfile)
{
    opaque = false;
    border = false;
};

// ----------------------------------------------------------------------------

if(!isObject(GuiSolidProfile)) new GuiControlProfile (GuiSolidProfile)
{
   opaque = true;
   border = true;
};

// ----------------------------------------------------------------------------

if (!isObject(GuiToolTipProfile)) new GuiControlProfile (GuiToolTipProfile : GuiDefaultProfile)
{
    fillColor = "246 220 165 255";
    
    fontType = $platformFontType;
    fontSize = $platformFontSize;
};

// ----------------------------------------------------------------------------

if (!isObject(GuiPopupMenuItemBorder)) new GuiControlProfile (GuiPopupMenuItemBorder : GuiDefaultProfile)
{
    bitmap = "^EditorShell/gui/images/scroll";
    hasBitmapArray = true;
};

// ----------------------------------------------------------------------------

if (!isObject(GuiPopUpMenuDefault)) new GuiControlProfile (GuiPopUpMenuDefault)
{
    tab = false;
    canKeyFocus = false;
    hasBitmapArray = false;
    mouseOverSelected = false;

    // fill color
    opaque = false;
    fillColor = "255 255 255 192";
    fillColorHL = "255 0 0 192";
    fillColorNA = "0 0 255 255";

    // border color
    border = 1;
    borderColor    = "100 100 100 255";
    borderColorHL = "0 128 0 255";
    borderColorNA = "0 226 226 52";

    // font
    fontType = $platformFontType;
    fontSize = $platformFontSize;

    fontColor = "27 59 95 255";
    fontColorHL = "232 240 248 255";
    fontColorNA = "0 0 0 255";
    fontColorSEL= "255 255 255 255";

    // bitmap information
    bitmap = "^EditorShell/gui/images/scroll";
    hasBitmapArray = true;
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

    profileForChildren = GuiPopupMenuItemBorder;
    // sounds
    soundButtonDown = "";
    soundButtonOver = "";
};

// ----------------------------------------------------------------------------

if (!isObject(GuiPopUpMenuProfile)) new GuiControlProfile (GuiPopUpMenuProfile : GuiPopUpMenuDefault)
{
    textOffset = "6 3";
    justify = "center";
    bitmap = "^EditorShell/gui/images/dropDown";
    hasBitmapArray = true;
    border = -3;
    profileForChildren = GuiPopUpMenuDefault;
    opaque = true;
};

//-----------------------------------------------------------------------------

if (!isObject(GuiTextProfile)) new GuiControlProfile (GuiTextProfile)
{
    border=false;

    // font
    fontType = $platformFontType;
    fontSize = $platformFontSize;

    fontColor = "white";

    modal = true;
    justify = "left";
    autoSizeWidth = false;
    autoSizeHeight = false;
    returnTab = false;
    numbersOnly = false;
    cursorColor = "0 0 0 255";
};

//-----------------------------------------------------------------------------

if (!isObject(GuiText16Profile)) new GuiControlProfile (GuiText16Profile : GuiTextProfile)
{
    fontSize = 16;
};

//-----------------------------------------------------------------------------

if (!isObject(GuiMLTextCenteredLgPreviewProfile)) new GuiControlProfile (GuiMLTextCenteredLgPreviewProfile : GuiTextProfile)
{
    border = false;
    justify = "center";
};

//-----------------------------------------------------------------------------

if (!isObject(GuiMLTextCenteredSmPreviewProfile)) new GuiControlProfile (GuiMLTextCenteredSmPreviewProfile : GuiTextProfile)
{
    border = false;
    justify = "center";
};

//-----------------------------------------------------------------------------

if (!isObject(GuiTextCenteredLgPreviewProfile)) new GuiControlProfile (GuiTextCenteredLgPreviewProfile : GuiTextProfile)
{
    justify = "center";
};

//-----------------------------------------------------------------------------

if (!isObject(GuiTextCenteredSmPreviewProfile)) new GuiControlProfile (GuiTextCenteredSmPreviewProfile : GuiTextProfile)
{
    justify = "center";
};

//-----------------------------------------------------------------------------

if (!isObject(GuiCheckBoxProfile)) new GuiControlProfile (GuiCheckBoxProfile)
{
    opaque = false;
    fontColor = "white";
    fillColor = "232 232 232 255";
    fontColorHL = "white";
    border = false;
    borderColor = "0 0 0 255";
    fontType = $platformFontType;
    fontSize = $platformFontSize;
    fixedExtent = true;
    justify = "left";
    bitmap = "^EditorShell/gui/images/checkBox";
    hasBitmapArray = true;
};

//-----------------------------------------------------------------------------

if(!isObject(GuiConsoleProfile)) new GuiControlProfile (GuiConsoleProfile)
{
    fontType = $platformFontType;
    fontSize = $platformFontSize * 1.1;
    fontColor = White;
    fontColorHL = LightSlateGray;
    fontColorNA = Red;
    fontColors[6] = "100 100 100";
    fontColors[7] = "100 100 0";
    fontColors[8] = "0 0 100";
    fontColors[9] = "0 100 0";
};

//-----------------------------------------------------------------------------

if (!isObject(GuiTextEditProfile)) new GuiControlProfile (GuiTextEditProfile)
{
    fontSize = $platformFontSize;
    opaque = false;
    fillColor = "232 240 248 255";
    fillColorHL = "251 170 0 255";
    fillColorNA = "127 127 127 52";
    border = -2;
    bitmap = "^EditorShell/gui/images/textEdit.png";
    borderColor = "40 40 40 10";
    fontColor = "27 59 95 255";
    fontColorHL = "232 240 248 255";
    fontColorNA = "0 0 0 52";
    fontColorSEL = "0 0 0 255";
    textOffset = "5 2";
    autoSizeWidth = false;
    autoSizeHeight = false;
    tab = false;
    canKeyFocus = true;
    returnTab = true;
};

//-----------------------------------------------------------------------------

if(!isObject(GuiNumberEditProfile)) new GuiControlProfile (GuiNumberEditProfile: GuiTextEditProfile)
{
   numbersOnly = true;
};

//-----------------------------------------------------------------------------

if(!isObject(GuiConsoleTextEditProfile)) new GuiControlProfile (GuiConsoleTextEditProfile : GuiTextEditProfile)
{
    fontType = $platformFontType;
    fontSize = $platformFontSize * 1.1;
};

//-----------------------------------------------------------------------------

if(!isObject(GuiScrollProfile)) new GuiControlProfile (GuiScrollProfile)
{
    opaque = true;
    fillColor = "255 255 255";
    border = 1;
    borderThickness = 2;
    bitmap = "^EditorShell/gui/images/scrollBar.png";
    hasBitmapArray = true;
};

//-----------------------------------------------------------------------------

if(!isObject(GuiTransparentScrollProfile)) new GuiControlProfile (GuiTransparentScrollProfile)
{
   opaque = false;
   fillColor = "255 255 255";
   border = false;
   borderThickness = 2;
   borderColor = "0 0 0";
   bitmap = "^EditorShell/gui/images/scrollBar.png";
   hasBitmapArray = true;
};

//-----------------------------------------------------------------------------

if(!isObject(ConsoleScrollProfile)) new GuiControlProfile( ConsoleScrollProfile : GuiScrollProfile )
{
    opaque = true;
    fillColor = "0 0 0 120";
    border = 3;
    borderThickness = 0;
    borderColor = "0 0 0";
};

//-----------------------------------------------------------------------------

if(!isObject(GuiToolboxProfile)) new GuiControlProfile( GuiToolboxProfile : GuiScrollProfile )
{
    opaque = true;
    fillColor = "255 255 255 220";
    border = 3;
    borderThickness = 0;
    borderColor = "0 0 0";
};

//-----------------------------------------------------------------------------

if(!isObject(SandboxWindowProfile)) new GuiControlProfile (SandboxWindowProfile : GuiDefaultProfile)
{
    // fill color
    opaque = false;
    fillColor = "0 0 0 92";

    // font
    fontType = $platformFontType;
    fontSize = $platformFontSize;
    fontColor = "255 255 255 255";
}; 

//-----------------------------------------------------------------------------

if (!isObject(BlueButtonProfile)) new GuiControlProfile (BlueButtonProfile : GuiButtonProfile)
{
    fontSize = $platformFontSize;
    fontColor = "255 255 255 255";
    fontColorHL = "255 255 255 255";
    bitmap = "^EditorShell/gui/images/blueButton.png";
};

//-----------------------------------------------------------------------------

if (!isObject(RedButtonProfile)) new GuiControlProfile (RedButtonProfile : GuiButtonProfile)
{
    fontSize = $platformFontSize;
    fontColor = "255 255 255 255";
    fontColorHL = "255 255 255 255";
    bitmap = "^EditorShell/gui/images/redButton.png";
};

//-----------------------------------------------------------------------------

if (!isObject(GreenButtonProfile)) new GuiControlProfile (GreenButtonProfile : GuiButtonProfile)
{
    fontSize = $platformFontSize;
    fontColor = "255 255 255 255";
    fontColorHL = "255 255 255 255";
    bitmap = "^EditorShell/gui/images/greenButton.png";
};

//-----------------------------------------------------------------------------

if (!isObject(GuiRadioProfile)) new GuiControlProfile (GuiRadioProfile : GuiDefaultProfile)
{
    fillColor = "232 232 232 255";
    fixedExtent = true;
    bitmap = "^EditorShell/gui/images/radioButton.png";
    hasBitmapArray = true;
};

//-----------------------------------------------------------------------------

if (!isObject(GuiSliderProfile)) new GuiControlProfile (GuiSliderProfile)
{
    bitmap = "^EditorShell/gui/images/slider.png";
    fontType = $platformFontType;
    fontSize = $platformFontSize;
    fontColor = "white";
};

//-----------------------------------------------------------------------------

if (!isObject(GuiSliderNoTextProfile)) new GuiControlProfile (GuiSliderNoTextProfile)
{
    bitmap = "^EditorShell/gui/images/slider.png";
    fontColor = "white";
    fontSize = 1;
};

//-----------------------------------------------------------------------------

if (!isObject(GuiSpinnerProfile)) new GuiControlProfile (GuiSpinnerProfile)
{
    fontType = $platformFontType;
    fontSize = $platformFontSize;
    opaque = false;
    justify = "center";
    fillColor = "232 240 248 255";
    fillColorHL = "251 170 0 255";
    fillColorNA = "127 127 127 52";
    numbersOnly = true;
    border = -2;
    bitmap = "^EditorShell/gui/images/textEdit_noSides";
    borderColor = "40 40 40 10";
    fontColor = "27 59 95 255";
    fontColorHL = "232 240 248 255";
    fontColorNA = "0 0 0 52";
    fontColorSEL = "0 0 0 255";
    textOffset = "4 2";
    autoSizeWidth = false;
    autoSizeHeight = false;
    tab = false;
    canKeyFocus = true;
    returnTab = true;
};

//-----------------------------------------------------------------------------

if (!isObject(GuiLightScrollProfile)) new GuiControlProfile (GuiLightScrollProfile : GuiScrollProfile)
{
    opaque = false;
    fillColor = "212 216 220";
    border = 0;
    bitmap = "^EditorShell/gui/images/scrollBar";
    hasBitmapArray = true;
};

//-----------------------------------------------------------------------------

if (!isObject(GuiSunkenContainerProfile)) new GuiControlProfile (GuiSunkenContainerProfile)
{
    opaque = false;
    fillColor = "232 240 248 255";
    fillColorHL = "251 170 0 255";
    fillColorNA = "127 127 127 52";
    border = -2;
    bitmap = "^EditorShell/gui/images/sunkenContainer";
    borderColor = "40 40 40 10";
};

//-----------------------------------------------------------------------------

if (!isObject(PanelDarkProfile)) new GuiControlProfile (PanelDarkProfile) 
{
    opaque = false;
    bitmap = "^EditorShell/gui/images/sunkenContainer";
    border = -2;
};

//-----------------------------------------------------------------------------

if (!isObject(PanelTransparentProfile)) new GuiControlProfile(EditorPanelTransparent : PanelDarkProfile)
{
    bitmap = "^EditorShell/gui/images/panel_transparent";
};

//-----------------------------------------------------------------------------

if (!isObject(GuiTransparentProfileModeless)) new GuiControlProfile (GuiTransparentProfileModeless : GuiTransparentProfile) 
{
    modal = false;
};

//-----------------------------------------------------------------------------

if (!isObject(BlueTextProfile)) new GuiControlProfile (BlueTextProfile : GuiTextProfile)
{
    fontType = "Open Sans";
    fontSize = 14;
    fontColorNA = "27 95 59 255";
};

//-----------------------------------------------------------------------------

if (!isObject(GuiFileEditBoxProfile)) new GuiControlProfile (GuiFileEditBoxProfile)
{
    fontSize = 16;
    opaque = false;
    fillColor = "232 240 248 255";
    fillColorHL = "251 170 0 255";
    fillColorNA = "127 127 127 52";
    border = -2;
    bitmap = "^EditorShell/gui/images/textEdit_noRightEdge";
    borderColor = "40 40 40 10";
    fontColor = "27 59 95 255";
    fontColorHL = "232 240 248 255";
    fontColorNA = "0 0 0 52";
    fontColorSEL = "0 0 0 255";
    textOffset = "7 2";
    autoSizeWidth = false;
    autoSizeHeight = false;
    tab = false;
    canKeyFocus = true;
    returnTab = true;
};

//-----------------------------------------------------------------------------

if (!isObject(GUIImageEditorGridBoxProfile)) new GuiControlProfile (GUIImageEditorGridBoxProfile)
{
    border = 1;
    borderColor = "100 100 255 255";
    borderColorHL = "100 100 255 255";
    borderColorNA = "100 100 255 255";
    modal = false;
};

//-----------------------------------------------------------------------------

if (!isObject(GUIImageEditorGridLinesProfile)) new GuiControlProfile (GUIImageEditorGridLinesProfile)
{
    border = 7; // draw border on right&bottom only
    borderColor  = "100 100 255 255";
    borderColorHL = "100 100 255 255";
    borderColorNA = "100 100 255 255";
    modal = false;
};

//-----------------------------------------------------------------------------

if (!isObject(GUIImageEditorGridGreyBoxProfile)) new GuiControlProfile (GUIImageEditorGridGreyBoxProfile)
{
    border = 0;
    opaque = true;
    fillColor = "100 100 100 150";
    fillColorHL = "100 100 100 150";
    fillColorNA = "100 100 100 150";
    modal = false;
};

//-----------------------------------------------------------------------------

if(!isObject(GuiListBoxProfile)) new GuiControlProfile (GuiListBoxProfile)
{
    tab = true;
    canKeyFocus = true;
};

//-----------------------------------------------------------------------------

if (!isObject(PanelMediumProfile)) new GuiControlProfile (PanelMediumProfile) 
{
    opaque = false;
    bitmap = "^EditorShell/assets/images/panelMedium";
    border = -2;
};

//-----------------------------------------------------------------------------

if (!isObject(GuiDarkTextProfile)) new GuiControlProfile (GuiDarkTextProfile : GuiTextProfile)
{
    fontType = "Open Sans Bold";
    fontSize = 19;
    fontColorNA = "0 0 0 52";
    fontColor = "27 59 95 255";
    border=false;
};

//-----------------------------------------------------------------------------

if (!isObject(GuiScreenContainerProfile)) new GuiControlProfile (GuiScreenContainerProfile)
{
    opaque = false;
    fillColor = "232 240 248 255";
    fillColorHL = "251 170 0 255";
    fillColorNA = "127 127 127 52";
    border = -2;
    bitmap = "^EditorShell/assets/images/containerForScreens";
    borderColor = "40 40 40 10";
};

//-----------------------------------------------------------------------------

if (!isObject(GuiDragAndDropProfile)) new GuiControlProfile(GuiDragAndDropProfile)
{
};

//-----------------------------------------------------------------------------

if (!isObject(ALAssetNameFontProfile)) new GuiControlProfile(ALAssetNameFontProfile)
{
    Name = "ALAssetNameFontProfile";
    tab = "0";
    canKeyFocus = "0";
    mouseOverSelected = "0";
    Modal = "1";
    opaque = "0";
    fillColor = "58 58 58 255";
    fillColorHL = "244 244 244 255";
    fillColorNA = "244 244 244 255";
    border = "1";
    borderThickness = "1";
    borderColor = "100 100 100 255";
    borderColorHL = "128 128 128 255";
    borderColorNA = "58 58 58 255";
    bevelColorHL = "110 97 103 101";
    bevelColorLL = "114 0 108 111";
    fontType = "Arial Bold";
    fontSize = "16";
    fontCharset = "ANSI";
    fontColors = "255 255 255 255";
    fontColor = "255 255 255 255";
    fontColorHL = "32 100 100 255";
    fontColorNA = "0 0 0 255";
    fontColorSEL = "10 10 10 255";
    fontColorLink = "101 116 117 112";
    fontColorLinkHL = "66 97 115 101";
    justify = "center";
    textOffset = "0 0";
    autoSizeWidth = "0";
    autoSizeHeight = "0";
    returnTab = "0";
    numbersOnly = "0";
    cursorColor = "0 0 0 255";
    bitmap = "^EditorShell/gui/images/window";
};