DROP TABLE IF EXISTS technique_drills;

CREATE TABLE technique_drills (
    drill_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    name NVARCHAR(100) NOT NULL,
    focus_area NVARCHAR(50),
    description NVARCHAR(MAX),
    execution_steps NVARCHAR(MAX),
    coaching_points NVARCHAR(MAX),
    progression NVARCHAR(MAX),
    is_verified BIT,
    created_at DATETIME2 DEFAULT GETDATE(), 
    created_by NVARCHAR(50)
);

INSERT INTO technique_drills (name, focus_area, description, execution_steps, coaching_points, progression, is_verified, created_at, created_by) VALUES
('Arms Only', 'Sequencing', 'Isolate arm movement to understand proper finish and recovery', '1. Start in finish position 2. Extend arms forward only 3. Pull back to finish 4. Repeat for set duration', 'Keep shoulders down, smooth arm extension, proper wrist position', 'Start with 10 strokes, build to 2-3 minutes', 1, GETDATE(), 'system'),
('Arms and Body', 'Sequencing', 'Add body swing to arm movement, maintain leg position', '1. Legs extended throughout 2. Arms extend, then body rocks forward 3. Body swings back, then arms pull 4. Focus on timing', 'Arms lead body on recovery, body leads arms on drive', 'Start with 10 strokes, build to 2-3 minutes', 1, GETDATE(), 'system'),
('Legs Only', 'Power Application', 'Isolate leg drive while maintaining upper body position', '1. Body forward, arms extended 2. Drive with legs only 3. Keep upper body angle constant 4. Strong connection through feet', 'Drive through heels, maintain posture, feel the power', 'Focus on power before adding body/arms', 1, GETDATE(), 'system'),
('Pause Drills', 'Positioning', 'Stop at specific positions to check and correct form', '1. Pause at catch for 3 seconds 2. Take normal stroke 3. Pause at finish for 3 seconds 4. Continue pattern', 'Use pause time to check position, breathing, balance', 'Add pauses at quarter, half, three-quarter positions', 1, GETDATE(), 'system'),
('Rate Build', 'Rate Control', 'Gradually increase stroke rate while maintaining technique', '1. Start at 16 SPM for 2 minutes 2. Increase by 2 SPM every minute 3. Build to 28-30 SPM 4. Focus on maintaining stroke length', 'Length before rate, smooth transitions, maintain power', 'Start with smaller rate increments, extend duration', 1, GETDATE(), 'system'),
('Feet Out Rowing', 'Connection', 'Row without foot straps to improve timing and connection', '1. Remove feet from straps 2. Row normal stroke 3. Focus on timing and balance 4. Feet should stay on footboard', 'Proves proper sequencing, improves connection, balance', 'Start with short pieces, build confidence gradually', 1, GETDATE(), 'system'),
('Power Tens', 'Power Application', 'Short bursts of maximum power while maintaining technique', '1. Take 10 strokes at maximum power 2. Focus on maintaining technique 3. Return to base pace 4. Repeat as prescribed', 'Power without sacrificing form, full stroke length, strong finish', 'Start with 5 strokes, build to 10, then 20', 1, GETDATE(), 'system');