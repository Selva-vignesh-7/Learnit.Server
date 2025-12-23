-- Migration script to add PlaybackPositions table
-- Run this manually if EF migrations cannot be run while server is running

CREATE TABLE IF NOT EXISTS "PlaybackPositions" (
    "Id" SERIAL PRIMARY KEY,
    "UserId" INTEGER NOT NULL,
    "CourseId" INTEGER NOT NULL,
    "ModuleId" INTEGER NULL,
    "VideoId" TEXT NOT NULL DEFAULT '',
    "PlaylistId" TEXT NOT NULL DEFAULT '',
    "CurrentTimeSeconds" DOUBLE PRECISION NOT NULL DEFAULT 0,
    "DurationSeconds" DOUBLE PRECISION NOT NULL DEFAULT 0,
    "LastUpdatedAt" TIMESTAMP WITH TIME ZONE NOT NULL DEFAULT NOW(),
    CONSTRAINT "FK_PlaybackPositions_Courses_CourseId" 
        FOREIGN KEY ("CourseId") 
        REFERENCES "Courses"("Id") 
        ON DELETE CASCADE,
    CONSTRAINT "FK_PlaybackPositions_CourseModules_ModuleId" 
        FOREIGN KEY ("ModuleId") 
        REFERENCES "CourseModules"("Id") 
        ON DELETE SET NULL
);

CREATE INDEX IF NOT EXISTS "IX_PlaybackPositions_CourseId" 
    ON "PlaybackPositions"("CourseId");

CREATE INDEX IF NOT EXISTS "IX_PlaybackPositions_ModuleId" 
    ON "PlaybackPositions"("ModuleId");

CREATE INDEX IF NOT EXISTS "IX_PlaybackPositions_UserId_CourseId_VideoId" 
    ON "PlaybackPositions"("UserId", "CourseId", "VideoId");

