Quick guide to requirements:

Please ensure your ReSharper settings has the Master.DotSettings added to the "Settings Layers" for "This Computer"

Please ensure you have NCrunch 2.13.05 installed and that it is enabled for any solution you open

Please ensure you download StyleCop 4.7 - http://stylecop.codeplex.com/ (if it complains about your version of ReSharper, please ignore and continue)
In addition, please ensure StyleCop is updated with the Settings.StyleCop file located in the same directory as this document.  
The default directory for StyleCop is: C:\Program Files (x86)\StyleCop 4.7

Please ensure VS2013 > Tools > Options > Projects and Solutions has:

User Project Templates Location set to:
\\athena\Shared\IT\Development\TeamSettings\TeamTemplates\ProjectTemplates

User Item Templates Location set to:
\\athena\Shared\IT\Development\TeamSettings\TeamTemplates\ItemTemplates

ReSharper formatting must be applied to each file upon completion of any changes (shortcuts vary depending on your keyboard selection in ReSharper)
StyleCop must be run prior to each commit: Tools > Run StyleCop (CTRL + SHIFT + Y) - any violations must be resolved before committing.

Unit Test coverage must be 100% unless approved by the Head of Development

Depending on your point of view, we will be developing using BDD or, if you are old school, TDD (the original definition) - 
put simply, all code must be covered by an automated test and, where applicable, SpecFlow must be used to drive the UI
