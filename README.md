# MkShortCut
The command line tool to make a shortcut.

# Usage
`MkShortCut <TargetPath> [<OutputPath> [<Arguments>]]`

| Options    | Description                                                                             |
| ---------- | --------------------------------------------------------------------------------------- |
| TargetPath | The shortcut's target path.                                                             |
| OutputPath | The pathname of the shortcut to create. If omitted, this will be the current directory. |
| Arguments  | The arguments.                                                                          |

# Usage Sample
`MkShortCut "%SystemRoot%/System32/NotePad.exe" "%AppData%/Microsoft/Windows/SendTo" "/W"`

# Requirement
- .NET framework 4.0 or later.
