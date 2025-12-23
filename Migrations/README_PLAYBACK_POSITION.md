# Playback Position Migration

## Issue
The `PlaybackPositions` table does not exist in the database, causing the error:
```
Npgsql.PostgresException: '42P01: relation "PlaybackPositions" does not exist
```

## Solution

### Option 1: Run EF Migration (Recommended when server is stopped)
```bash
cd Learnit.Server
dotnet ef database update
```

### Option 2: Run SQL Script Manually (When server is running)
1. Connect to your PostgreSQL database
2. Run the SQL script: `Migrations/AddPlaybackPositions.sql`

The script will:
- Create the `PlaybackPositions` table
- Add foreign key constraints to `Courses` and `CourseModules`
- Create indexes for efficient queries

## What This Enables

1. **Persistent Playback Position**: YouTube video playback position is saved to the database, persisting across:
   - Browser sessions
   - Logout/login
   - Device changes (if using the same account)

2. **Resume Functionality**: When a user returns to a course:
   - The system loads the last saved playback position from the database
   - Falls back to localStorage if database position is not found
   - Automatically seeks to the saved position when the video player is ready

3. **Module-Specific Tracking**: For courses with multiple modules (chapters), each module's playback position is tracked separately

## How It Works

1. **Saving Position**:
   - Triggered on: play, pause, seek, and every 5 seconds during playback
   - Saved to both localStorage (instant) and database (debounced)

2. **Loading Position**:
   - On video player ready, checks database first
   - Falls back to localStorage if database has no position
   - Seeks to saved position with retry logic for reliability

3. **Integration with Course Scheduler**:
   - Playback position is part of the overall course progress tracking
   - Module completion is updated when video reaches 90% completion
   - Progress updates trigger schedule adjustments automatically

