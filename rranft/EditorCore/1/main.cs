//-----------------------------------------------------------------------------
// Torque
// Copyright GarageGames, LLC 2011
//-----------------------------------------------------------------------------

function EditorCore::create(%scopeSet)
{
    // Seed the random number generator.
    setRandomSeed();
    
    // Set font cache directory
    $Gui::fontCacheDirectory = getPrefsPath("fonts");
    exec("./scripts/profiles.cs");
    
    // Initialize the primary systems used for rendering and playing audio
    exec("./scripts/audio.cs");
    exec("./scripts/canvas.cs");
    exec("./scripts/cursors.cs");
    
    //initializeCanvas("3 Step Studio");
    //initializeOpenAL();

    // Set up networking.
    echoSeparator();
    echo("Initializing network bindings:");  
    setNetPort(0);

    // Common Guis.
    //exec("./scripts/console.cs");
    //%scopeSet.add( TamlRead("./gui/consoleGui.gui.taml") );
    %scopeSet.add( TamlRead("./gui/optionsGui.gui.taml") );
    %scopeSet.add( TamlRead("./gui/FrameOverlayGui.gui.taml") );
    
    // Get the Editor Event Manager running
    exec("./scripts/EditorEventManager.cs");
    initializeEditorEventManager();
    
    // Random Scripts.
    exec("./scripts/metrics.cs");
    exec("./scripts/keybindings.cs");
    exec("./scripts/options.cs");

    // Console class extension scripts
    exec("./scripts/animationSets.cs");
    exec("./scripts/sprite_interface.cs");
    exec("./scripts/scene_interface.cs");    
    exec("./scripts/sceneWindow_interface.cs");
    exec("./scripts/simSet_interface.cs");
    
    // Behaviors
    exec("./scripts/helperfuncs.cs");
    
    // File IO and preferences
    exec("./scripts/fileLoader.cs");   
   
    loadDirectory( expandPath("./gui/panels") );
    
    // Load Form Managers
    exec("./scripts/guiClasses/guiFormLibraryManager.cs");
    exec("./scripts/guiClasses/guiFormContentManager.cs");
    exec("./scripts/guiClasses/guiFormReferenceManager.cs");
    exec("./scripts/guiClasses/guiFormLayoutManager.cs");
    exec("./scripts/guiClasses/guiFormMessageManager.cs");
    exec("./scripts/guiClasses/guiFormClass.cs");
    exec("./scripts/guiClasses/guiThumbnailPopup.cs");
    exec("./scripts/guiClasses/guiThumbnail.cs");
    
    // Load scripts related to resource management/execution
    exec("./scripts/editorMenus.cs");
    exec("./scripts/expandos.cs");
    
    setupBaseExpandos();
    
    // User Display
    exec("./scripts/contextPopup.cs");

    // Input
    exec("./scripts/input/inputEvents.cs");
    exec("./scripts/input/dragDropEvents.cs");
    exec("./scripts/input/applicationEvents.cs");
    exec("./scripts/xml.cs");
    exec("./scripts/platform/menuBuilder.cs");
    
    loadDirectory( expandPath("./scripts/platform") );

    // Setup the console keybinds
    GlobalActionMap.bind(keyboard, "ctrl tilde", toggleConsole);
    GlobalActionMap.bindcmd(keyboard, "alt k", "cls();",  "");
    
    // Set a default cursor.
    Canvas.setCursor(DefaultCursor);

    //activatePackage(KeybindPackage);
    //loadKeybindings();
    //deactivatePackage(KeybindPackage);

    $EditorCoreGroup = "EditorCoreCleanup";

    if( !isObject( $EditorCoreGroup ) )
        new SimGroup( $EditorCoreGroup );
        
    // Initialize.
    GuiFormManager::Init();
}

function EditorCore::destroy()
{
    EditorEventManager.postEvent("_CoreShutdown", "");
    
    // Kill the sound system
    shutdownOpenAL();
    
    // Destroy.
    GuiFormManager::Destroy();
    
    destroyEditorEventManager();
}

function ModuleManager::getDefinitionFromId(%this, %moduleID, %type)
{
    // Find all the modules that have "template" as a type
    if (%type !$= "")
        %templateModuleList = ModuleDatabase.findModuleTypes(%type, false);
    else
        %templateModuleList = ModuleDatabase.findModules(false);
    
    %moduleDefinition = "";
    
    // Go through the template module list and find the specific module
    for(%i = 0; %i < getWordCount(%templateModuleList); %i++)
    {
        // Get the module definition object
        %moduleDefinition = getWord(%templateModuleList, %i);
        
        // Check to see if it is what we are looking for
        // If so, break out of this loop and use it
        if (%moduleDefinition.ModuleId $= %moduleID)
            break;
    }
    
    return %moduleDefinition;
}