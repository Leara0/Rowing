DROP TABLE IF EXISTS injury_prevention;
CREATE TABLE injury_prevention (
    prevention_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
    body_area NVARCHAR(50) NOT NULL,
    injury_type NVARCHAR(100),
    prevention_strategy NVARCHAR(MAX),
    strengthening_exercises NVARCHAR(MAX),
    critical_phase_id INT,
    is_verified BIT,
    created_at DATETIME2 DEFAULT GETDATE(), 
    created_by NVARCHAR(50),
    FOREIGN KEY (critical_phase_id) REFERENCES stroke_phases(phase_id)
);

INSERT INTO injury_prevention (body_area, injury_type, prevention_strategy, strengthening_exercises, critical_phase_id, is_verified, created_at, created_by) VALUES
('Back', 'Lumbar strain and pain', 'Keep chest open, avoid rounding back, proper hip hinge movement', 'Planks, deadlifts, back extensions, glute bridges', 2, 1, GETDATE(), 'system'),
('Knees', 'Patellofemoral pain, IT band friction', 'Knees stay in line with hips, vertical shins at catch, controlled compression', 'Single-leg squats, clamshells, wall sits', 1, 1, GETDATE(), 'system'),
('Wrists', 'Tenosynovitis, intersection syndrome', 'Flat wrists throughout stroke, fingers around handle, smooth blade work', 'Wrist curls, reverse wrist curls, finger extensions with rubber band', 4, 1, GETDATE(), 'system'),
('Shoulders', 'Impingement, rotator cuff strain', 'Shoulders down and back, avoid hunching, controlled arm movement', 'External rotations with resistance band, scapular wall slides, reverse flies', 3, 1, GETDATE(), 'system'),
('Ribs', 'Stress fractures', 'Smooth power application, avoid jerky movements, proper breathing', 'Bird dogs, dead bugs, pallof press', 2, 1, GETDATE(), 'system'),
('Hips', 'Femoroacetabular impingement (FAI)', 'Find individual optimal range, hip flexion at least 130 degrees', '90/90 hip stretches, cossack squats, hip flexor stretches', 1, 1, GETDATE(), 'system');