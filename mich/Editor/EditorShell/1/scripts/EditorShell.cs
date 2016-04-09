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

function EditorShell::initializeEventManager(%this)
{
    if (!isObject(%this.EditorEventManager))
    {
        %this.EditorEventManager = new EventManager()
        { 
            queue = "EditorEventManager"; 
        };
        
        %this.EditorEventManager.registerEvent("_StartUpComplete");
        %this.EditorEventManager.registerEvent("_PluginsLoaded");
        %this.EditorEventManager.registerEvent("_FileMenuChanged");
        %this.EditorEventManager.registerEvent("_CoreShutdown");
        
        %this.EditorEventManager.subscribe(%this, "_StartUpComplete", "onStartUpComplete");
        %this.EditorEventManager.subscribe(%this, "_PluginsLoaded", "onPluginsLoaded");
        %this.EditorEventManager.subscribe(%this, "_FileMenuChanged", "onFileMenuChanged");
        %this.EditorEventManager.subscribe(%this, "_CoreShutdown", "onCoreShutdown");
    }    
}

//-----------------------------------------------------------------------------

function EditorShell::registerEvent(%this, %eventName, %listener, %callback)
{
    %this.EditorEventManager.registerEvent(%eventName);
    %this.EditorEventManager.subscribe(%listener, %eventName, %callback);
}

//-----------------------------------------------------------------------------

function EditorShell::triggerEvent(%this, %eventName, %data)
{
    %this.EditorEventManager.postEvent(%eventName, %data);
}

//-----------------------------------------------------------------------------

function EditorShell::onStartupComplete(%this)
{
    echo("%- Startup complete");
    PluginSystem.loadPlugins();
}

//-----------------------------------------------------------------------------

function EditorShell::onPluginsLoaded(%this)
{
    echo("%- All plugins loaded");
}

//-----------------------------------------------------------------------------

function EditorShell::onFileMenuChanged(%this)
{
    EditorShell.detachMenuGroup();
    EditorShell.sortMenu();
    EditorShell.attachMenuGroup();
}

//-----------------------------------------------------------------------------

function EditorShell::onCoreShutdown(%this)
{
    echo("%- Editor shutting down");
}

function EditorShell::initializeMenu(%this)
{
    $cmdCtrl = $platform $= "macos" ? "Cmd" : "Ctrl";
    
    if( $platform $= "macos" )
        %nonMacMenu = -1000;
      
    if (isObject(%this.menuGroup))
        %this.menuGroup.delete();
        
    %this.menuGroup = new SimGroup();
}

//-----------------------------------------------------------------------------

function EditorShell::destroyMenu(%this)
{
    if (isObject(%this.menuGroup))
        %this.menuGroup.delete();
}

//-----------------------------------------------------------------------------

function EditorShell::addMenu(%this, %menu)
{
    if (isObject(%this.menuGroup))
    {
        %this.menuGroup.add(%menu);
        EditorShell.triggerEvent("_FileMenuChanged", "");
    }
}

//-----------------------------------------------------------------------------

function EditorShell::sortMenu(%this)
{
    
}

//-----------------------------------------------------------------------------

function EditorShell::attachMenuGroup(%this)
{
    if (!isObject(%this.menuGroup)) 
        return;

    for(%i = 0; %i < %this.menuGroup.getCount(); %i++)
        %this.menuGroup.getObject(%i).attachToMenuBar();
}

//-----------------------------------------------------------------------------

function EditorShell::detachMenuGroup(%this)
{
    if (!isObject(%this.menuGroup)) 
        return;
    
    for(%i = 0; %i < %this.menuGroup.getCount(); %i++)
        %this.menuGroup.getObject(%i).removeFromMenuBar();
}