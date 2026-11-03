# Project editing rules

- Before every code or scene change, reread the current files from disk. Never assume earlier conversation snippets are current.
- Before editing, save a timestamped project backup under `ProjectBackups/`, including Assets (with .meta files), Packages, ProjectSettings, UserSettings, and root files. Record relative paths, sizes, modification timestamps, and SHA256 hashes. Exclude generated caches and earlier backups.
- Disk backups do not save unsaved Unity editor changes. Before changing a scene or asset that may be open and dirty, ensure the editor changes are saved; if unable to do this, ask the user to save before proceeding with dependent edits.
- Preserve user edits. Recheck target files immediately before applying changes; if they changed since backup, reread and back up the new state first.
- Make only the requested changes. Keep code simple; do not add unsolicited null checks, rotation resets, velocity resets, or other behavior.
- Do not modify Unity scene files merely to accompany a code edit unless the requested behavior requires it. Explain necessary scene edits before applying them.
