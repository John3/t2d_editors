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

function MessageBoxTests::create(%this)
{
    %this.buildMenu();
}

//-----------------------------------------------------------------------------

function MessageBoxTests::destroy(%this)
{
    
}

//-----------------------------------------------------------------------------

function MessageBoxTests::buildMenu(%this)
{
    %menu = new PopupMenu()
    {
        superClass = "MenuBuilder";

        barPosition = 4;
        barName     = "Message Boxes";      

        item[0] = "OK" TAB "" TAB "MessageBoxTests.showOK();";
        item[1] = "OK Cancel" TAB "" TAB "MessageBoxTests.showOKCancel();";
        item[2] = "Confirm Action" TAB "" TAB "MessageBoxTests.showConfirmAction();";        
        item[3] = "Confirm Delete" TAB "" TAB "MessageBoxTests.showConfirmDelete();";
        item[4] = "Confirm Overwrite" TAB "" TAB "MessageBoxTests.showConfirmOverwrite();";        
    };
    
    EditorShell.addMenu(%menu);
}

//-----------------------------------------------------------------------------

function MessageBoxTests::showOK(%this)
{
    //MessageBoxOK("Show OK", "This is an OK Box", "");        
    NoticeGui.display("This is a display");
}

//-----------------------------------------------------------------------------

function MessageBoxTests::showOKCancel(%this)
{
    MessageBoxOKCancel("Show OK Cancel", "Ok or Cancel?", "", "");
}

//-----------------------------------------------------------------------------

function MessageBoxTests::showConfirmAction(%this)
{
    ConfirmActionGui.display("Confirm action?", %this, "", "");
}

//-----------------------------------------------------------------------------

function MessageBoxTests::showConfirmDelete(%this)
{
    ConfirmDeleteGui.display("Confirm delete?", %this, "", "");
}

//-----------------------------------------------------------------------------

function MessageBoxTests::showConfirmOverwrite(%this)
{
    ConfirmOverwriteGui.display("Confirm overwrite?", %this, "", "");
}