USE Rowing;
GO

INSERT INTO stroke_phases (name, key_focus) VALUES
('Catch', 'Blade entry into water with proper body position. Shins vertical, body compressed forward, arms extended.'),
('Drive', 'Power application through legs-body-arms sequence. Legs drive first (60% of power), then body swings back, finally arms pull. Keep blade fully submerged.'),
('Finish', 'Clean blade extraction from water. Handle drawn to lower ribs, body leaning slightly back, legs extended.'),
('Recovery', 'Return to catch position in reverse sequence: arms extend first, body rocks forward, then legs compress. Blade feathered and carried above water.');

INSERT INTO injury_prevention (body_area, injury_type, prevention_strategy, strengthening_exercises, critical_phase_id, is_verified, created_at, created_by) VALUES
('Back', 'Lumbar strain and pain', 'Keep chest open, avoid rounding back, proper hip hinge movement', 'Planks, deadlifts, back extensions, glute bridges', 2, 1, GETDATE(), 'system'),
('Knees', 'Patellofemoral pain, IT band friction', 'Knees stay in line with hips, vertical shins at catch, controlled compression', 'Single-leg squats, clamshells, wall sits', 1, 1, GETDATE(), 'system'),
('Wrists', 'Tenosynovitis, intersection syndrome', 'Flat wrists throughout stroke, fingers around handle, smooth blade work', 'Wrist curls, reverse wrist curls, finger extensions with rubber band', 4, 1, GETDATE(), 'system'),
('Shoulders', 'Impingement, rotator cuff strain', 'Shoulders down and back, avoid hunching, controlled arm movement', 'External rotations with resistance band, scapular wall slides, reverse flies', 3, 1, GETDATE(), 'system'),
('Ribs', 'Stress fractures', 'Smooth power application, avoid jerky movements, proper breathing', 'Bird dogs, dead bugs, pallof press', 2, 1, GETDATE(), 'system'),
('Hips', 'Femoroacetabular impingement (FAI)', 'Find individual optimal range, hip flexion at least 130 degrees', '90/90 hip stretches, cossack squats, hip flexor stretches', 1, 1, GETDATE(), 'system');

INSERT INTO technique_drills (name, focus_area, description, execution_steps, coaching_points, progression, is_verified, created_at, created_by) VALUES
('Arms Only', 'Sequencing', 'Isolate arm movement to understand proper finish and recovery', '1. Start in finish position 2. Extend arms forward only 3. Pull back to finish 4. Repeat for set duration', 'Keep shoulders down, smooth arm extension, proper wrist position', 'Start with 10 strokes, build to 2-3 minutes', 1, GETDATE(), 'system'),
('Arms and Body', 'Sequencing', 'Add body swing to arm movement, maintain leg position', '1. Legs extended throughout 2. Arms extend, then body rocks forward 3. Body swings back, then arms pull 4. Focus on timing', 'Arms lead body on recovery, body leads arms on drive', 'Start with 10 strokes, build to 2-3 minutes', 1, GETDATE(), 'system'),
('Legs Only', 'Power Application', 'Isolate leg drive while maintaining upper body position', '1. Body forward, arms extended 2. Drive with legs only 3. Keep upper body angle constant 4. Strong connection through feet', 'Drive through heels, maintain posture, feel the power', 'Focus on power before adding body/arms', 1, GETDATE(), 'system'),
('Pause Drills', 'Positioning', 'Stop at specific positions to check and correct form', '1. Pause at catch for 3 seconds 2. Take normal stroke 3. Pause at finish for 3 seconds 4. Continue pattern', 'Use pause time to check position, breathing, balance', 'Add pauses at quarter, half, three-quarter positions', 1, GETDATE(), 'system'),
('Rate Build', 'Rate Control', 'Gradually increase stroke rate while maintaining technique', '1. Start at 16 SPM for 2 minutes 2. Increase by 2 SPM every minute 3. Build to 28-30 SPM 4. Focus on maintaining stroke length', 'Length before rate, smooth transitions, maintain power', 'Start with smaller rate increments, extend duration', 1, GETDATE(), 'system'),
('Feet Out Rowing', 'Connection', 'Row without foot straps to improve timing and connection', '1. Remove feet from straps 2. Row normal stroke 3. Focus on timing and balance 4. Feet should stay on footboard', 'Proves proper sequencing, improves connection, balance', 'Start with short pieces, build confidence gradually', 1, GETDATE(), 'system'),
('Power Tens', 'Power Application', 'Short bursts of maximum power while maintaining technique', '1. Take 10 strokes at maximum power 2. Focus on maintaining technique 3. Return to base pace 4. Repeat as prescribed', 'Power without sacrificing form, full stroke length, strong finish', 'Start with 5 strokes, build to 10, then 20', 1, GETDATE(), 'system');

INSERT INTO common_errors (name, description, phase_id, cause, correction_strategy, related_injury_id, is_verified, created_at, created_by) VALUES
('Sky Catching', 'Blade enters water too high above surface, reducing effective stroke length', 1, 'Poor timing, reaching too far forward, weak core position', 'Focus on blade control, proper body compression, hands-first movement', 4, 1, GETDATE(), 'system'),
('Over-compression', 'Knees bend too much at catch, creating weak position for power application', 1, 'Flexibility limitations, trying to get too much length', 'Find optimal compression for individual flexibility, strengthen hip flexors', 2, 1, GETDATE(), 'system'),
('Bum Shoving', 'Seat moves faster than shoulders during drive, breaking proper leg-body-arms sequence', 2, 'Weak leg drive, poor connection, fatigue', 'Practice legs-only drills, focus on staying connected through footplate', 1, 1, GETDATE(), 'system'),
('Opening Body Too Early', 'Body swings back before legs complete their drive', 2, 'Impatience, weak leg strength, poor sequencing understanding', 'Legs-body-arms sequence drills, strengthen leg drive', 1, 1, GETDATE(), 'system'),
('Washing Out', 'Blade lifts from water before completing full stroke', 3, 'Handle pulled down instead of through body, weak finish position', 'Draw handle to lower ribs, maintain body angle, clean extraction', 4, 1, GETDATE(), 'system'),
('Rushing the Slide', 'Moving too quickly during recovery, disrupting rhythm and boat balance', 4, 'Anxiety, lack of rhythm awareness, poor ratio understanding', 'Practice 1:2 drive to recovery ratio, focus on controlled movement forward', 1, 1, GETDATE(), 'system');

GO