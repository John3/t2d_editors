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
/// This function displays a full-screen confirmation dialog with custom message and 
/// callback functionality.
/// </summary>
/// <param name="message">The message to display to the user.</param>
/// <param name="object">The object that contains a method to be called.</param>
/// <param name="handler">The method on %object to call to handle the OK button click.</param>
/// <param name="data">Additional information that needs to be passed on to %handler.  Takes up to 8 space-separated items.</param>
function ConfirmOverwriteGui::display(%this, %message, %caller, %callback, %data)
{
    %this.object = %caller;
    %this.handler = %callback;
    %this.data = %data;
    ConfirmOverwriteMsgCtrl.setText(%message);
    Canvas.pushDialog(%this);
}

function OverwriteOKBtn::onClick(%this)
{
    %object = ConfirmOverwriteGui.object;
    
    if (%object.isMethod(ConfirmOverwriteGui.handler))
    {
        %argCount = getWordCount(ConfirmOverwriteGui.data);
        
        for (%i = 0; %i < %argCount; %i++)
        {
            %argList[%i] = getWord(ConfirmOverwriteGui.data, %i);
        }

        switch(%argCount)
        {
            case 0:
                %object.call(ConfirmOverwriteGui.handler);
            case 1:
                %object.call(ConfirmOverwriteGui.handler, %argList[0]);
            case 2:
                %object.call(ConfirmOverwriteGui.handler, %argList[0], %argList[1]);
            case 3:
                %object.call(ConfirmOverwriteGui.handler, %argList[0], %argList[1], %argList[2]);
            case 4:
                %object.call(ConfirmOverwriteGui.handler, %argList[0], %argList[1], %argList[2], %argList[3]);
            case 5:
                %object.call(ConfirmOverwriteGui.handler, %argList[0], %argList[1], %argList[2], %argList[3], %argList[4]);
            case 6:
                %object.call(ConfirmOverwriteGui.handler, %argList[0], %argList[1], %argList[2], %argList[3], %argList[4], %argList[5]);
            case 7:
                %object.call(ConfirmOverwriteGui.handler, %argList[0], %argList[1], %argList[2], %argList[3], %argList[4], %argList[5], %argList[6]);
            case 8:
                %object.call(ConfirmOverwriteGui.handler, %argList[0], %argList[1], %argList[2], %argList[3], %argList[4], %argList[5], %argList[6], %argList[7]);
        }
    }
    
    ConfirmOverwriteGui.object = "";
    ConfirmOverwriteGui.handler = "";
    ConfirmOverwriteGui.data = "";
    Canvas.popDialog(ConfirmOverwriteGui);
}

function OverwriteCancelBtn::onClick(%this)
{
    Canvas.popDialog(ConfirmOverwriteGui);
}